using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Common;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;
using PagoElectronico.Services;
using System.Data.SqlClient;
using System.Configuration;

namespace PagoElectronico.Retiros
{
    public partial class Retiro : Form
    {

        Cliente clienteLogueado;
        Usuario usuarioLogueado = Session.Usuario;

        ClienteService clienteService = new ClienteService();
        CuentaService cuentaService = new CuentaService();
        TipoMonedaService tipoMonedaService = new TipoMonedaService();
        TipoDocumentoService tipoDocumentoService = new TipoDocumentoService();
        BancoService bancoService = new BancoService();
        ChequeService chequeService = new ChequeService();
        RetiroService retiroService = new RetiroService();
        List<Cuenta> listaCuentas;
        List<TipoMoneda> listaTiposMoneda;
        List<TipoDocumento> listaTiposDocumentos;
        List<Banco> listaBancos;

        DateTime FECHA_ACTUAL = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);

        // ver el caso de un admin q no tenga cuentas, explota
        // un admin puede hacer retiro o trans de cualquier cuenta ??

        public Retiro()
        {
            InitializeComponent();   
        }

        #region Eventos
        /*************    Metodos de componentes       *************/
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            realizarRetiro();
            actualizarSaldoActual();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        private void comboCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarSaldoActual();
            recalcularSaldoPosterior();
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            recalcularSaldoPosterior();
        }

        private void Retiro_Load(object sender, EventArgs e)
        {
            try
            {
                //clienteLogueado = Utils.obtenerCliente(usuarioLogueado);
                cargarComboCuentas();
                cargarComboTipoDoc();
                cargarComboTipoMoneda();
                cargarComboBanco();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        #endregion

        #region MetodosPrivados
        /*************    Metodos privados       *************/
              
        private void realizarRetiro()
        {
            Boolean validador;
            validador = Validaciones.validarCampoVacio(txtNroDoc) & Validaciones.validarCampoVacio(txtImporte) & Validaciones.validarCampoVacio(txtNroCheque) & Validaciones.validarCampoVacio(txtNombreLibrar);
            validador = validador & Validaciones.validarCampoNumericoDouble(txtImporte) & Validaciones.validarCampoNumericoEntero(txtNroDoc) & Validaciones.validarCampoNumericoEntero(txtNroCheque) & Validaciones.validarCampoString(txtNombreLibrar);
            if (validador)
            {
                try
                {
                    validarCuentaHabilitada();
                    validarSaldoDisponible();
                    validarNumeroDocumento();
                    validarImporteEnDolares();


                    Cheque cheque = new Cheque();
                    cheque.numero = Int64.Parse(txtNroCheque.Text);
                    cheque.fecha = FECHA_ACTUAL;
                    cheque.importe = Double.Parse(txtImporte.Text);
                    cheque.codigoBanco = ((Banco)comboBanco.SelectedItem).codigo;
                    cheque.monedaTipo = ((TipoMoneda)comboTipoMoneda.SelectedItem).codigo;
                    cheque.nombreDestinatario = txtNombreLibrar.Text;

                    Entities.Retiro retiro = new Entities.Retiro();
                    retiro.cheque = cheque;

                    retiro.importe = cheque.importe;
                    retiro.fecha = cheque.fecha;
                    retiro.cuenta = Int64.Parse(comboCuentaOrigen.Text);
                    retiro.codigoCheque = cheque.numero;
                    

                    retiroService.GuardarRetiro(retiro);

                    MessageBox.Show("Se ha realizado el retiro de saldo. ", "Retiro realizado satisfactoriamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarDatos();
                    
                }
                catch (OperationCanceledException ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "No se pudo realizar el retiro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("El numero de cheque ya existe", "No se pudo realizar el retiro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void actualizarSaldoActual()
        {
            lblSaldoActual.Text = cuentaService.getSaldo(Convert.ToInt64(comboCuentaOrigen.Text.ToString())).ToString();
        }

        private void recalcularSaldoPosterior()
        {
            try
            {
                double saldoActual, saldoPosterior, importe;

                if (txtImporte.Text.Length == 0)
                {
                    mostrarComponentes(false);
                }
                else
                {
                    mostrarComponentes(true);

                    saldoActual = Convert.ToDouble(lblSaldoActual.Text);
                    importe = Convert.ToDouble(txtImporte.Text);

                    saldoPosterior = saldoActual - importe;
                    lblSaldoPosterior.Text = saldoPosterior.ToString();

                }
            }
            catch (Exception) { }
        }

        private void limpiarDatos()
        {
            txtNroDoc.BackColor = System.Drawing.Color.White;
            txtImporte.BackColor = System.Drawing.Color.White;
            txtNroCheque.BackColor = System.Drawing.Color.White;
            txtNombreLibrar.BackColor = System.Drawing.Color.White;

            txtNroDoc.Text = String.Empty;
            txtImporte.Text = String.Empty;
            txtNroCheque.Text = String.Empty;
            txtNroDoc.Text = String.Empty;

            comboCuentaOrigen.SelectedIndex = 0;
            comboTipoMoneda.SelectedIndex = 0;
            comboBanco.SelectedIndex = 0;
            //ocultarComponentes();
        }

        private void cargarComboCuentas()
        {
            if (Session.Usuario.SelectedRol.Id == (int)Entities.Enums.Roles.Admin)
            {
                listaCuentas = (List<Cuenta>)cuentaService.GetAll();
            }
            else
            {
                clienteLogueado = clienteService.getClienteByUsername(usuarioLogueado.Username);
                listaCuentas = (List<Cuenta>)cuentaService.getByCliente(clienteLogueado.tipoDocumento, clienteLogueado.numeroDocumento);
            }
            
            //listaCuentas = (List<Cuenta>)cuentaService.getByCliente(clienteLogueado.tipoDocumento, clienteLogueado.numeroDocumento);
            if (listaCuentas.Count > 0)
            {
                comboCuentaOrigen.DataSource = listaCuentas;
            }
            else
            {
                throw new Exception("No posees cuentas para realizar retiros");

            }

        }

        private void cargarComboTipoDoc()
        {
            listaTiposDocumentos = (List<TipoDocumento>)tipoDocumentoService.GetAll();
            comboTipoDoc.DataSource = listaTiposDocumentos;
            comboTipoDoc.SelectedIndex = 0;

        }

        private void cargarComboTipoMoneda()
        {
            listaTiposMoneda = (List<TipoMoneda>)tipoMonedaService.GetTiposMonedaByCuenta(comboCuentaOrigen.Text.ToString());
            comboTipoMoneda.DataSource = listaTiposMoneda;
            comboTipoMoneda.SelectedIndex = 0;
        }

        private void cargarComboBanco()
        {
            
            listaBancos = (List<Banco>)bancoService.GetAll(); ;
            comboBanco.DataSource = listaBancos;
            comboBanco.SelectedIndex = 0;
        }

        private void mostrarComponentes(Boolean validate)
        {
            lblSaldoPosterior.Visible = validate;
            lblSaldoPosteriorRO.Visible = validate;
        }

        #endregion

        #region Validaciones
        /*************    Validadores privados       *************/
        private void validarCuentaHabilitada()
        {
            if (cuentaService.getEstado(Int64.Parse(comboCuentaOrigen.Text)) != (Int32)Entities.Enums.EstadosCuenta.Habilitada)
            {

                throw new OperationCanceledException("La cuenta no se encuentra habilitada");
            }
        }

        private void validarNumeroDocumento()
        {
            Cliente cliente = new Cliente();

            if (Session.Usuario.SelectedRol.Id == (int)Entities.Enums.Roles.Admin)
            {
                long tipoDocCliente = ((Cuenta)comboCuentaOrigen.SelectedItem).tipoDoc;
                long nroDocCliente = ((Cuenta)comboCuentaOrigen.SelectedItem).nroDoc;
                cliente = clienteService.getClienteByDNI(tipoDocCliente, nroDocCliente);
            }
            else
            {
                cliente = clienteService.getClienteByUsername(usuarioLogueado.Username);
            }
            
            if (txtNroDoc.Text != cliente.numeroDocumento.ToString() | Convert.ToInt64(comboTipoDoc.SelectedValue) != cliente.tipoDocumento)
            {
                throw new OperationCanceledException("El documento ingresado no coincide");
            }
        }

        private void validarSaldoDisponible()
        {
            if (Double.Parse(lblSaldoActual.Text) <= 0)
            {
                throw new OperationCanceledException("La cuenta no posee fondos!");
            }

            if (Double.Parse(txtImporte.Text) > Double.Parse(lblSaldoActual.Text))
            {
                throw new OperationCanceledException("El saldo actual no es suficiente");
            }
        }

        private void validarImporteEnDolares()
        {
             if ( String.Compare(comboTipoMoneda.Text,"U$S")!=0)
            {
                throw new OperationCanceledException("El importe debe ser en dolares estadounidenses");
            }           
        }

        #endregion

    }
}
