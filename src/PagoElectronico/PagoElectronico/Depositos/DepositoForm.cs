using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Entities;
using PagoElectronico.Common;
using PagoElectronico.Services;
using System.Configuration;

namespace PagoElectronico.Depositos
{
    public partial class DepositoForm : Form
    {

        Cliente clienteLogueado;
        Usuario usuarioLogueado = Session.Usuario;

        CuentaService cuentaService = new CuentaService();
        ClienteService clienteService = new ClienteService();
        TipoMonedaService tipoMonedaService = new TipoMonedaService();
        TarjetaService tarjetaService = new TarjetaService();
        DepositoService depositoService = new DepositoService();

        List<Cuenta> listaCuentas;
        List<TipoMoneda> listaTiposMoneda;
        List<Tarjeta> listaTC;

        DateTime FECHA_ACTUAL = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);

        public DepositoForm()
        {
            InitializeComponent();
        }

        #region Eventos
        /*************    Metodos de componentes       *************/

        private void DepositoForm_Load(object sender, EventArgs e)
        {
            try
            {
                //clienteLogueado = Utils.obtenerCliente(usuarioLogueado);
                dateTimePicker1.Value = FECHA_ACTUAL;
                cargarComboCuentas();
                cargarComboTipoMoneda();
                cargarComboTC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            realizarDeposito();
            actualizarSaldoActual();
            recalcularSaldoPosterior();
        }

        private void comboCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarSaldoActual();
            cargarComboTC();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            recalcularSaldoPosterior();
        }


        #endregion

        #region MetodosPrivados
        /*************    Metodos privados       *************/

        private void realizarDeposito()
        {
            Boolean validador = Validaciones.validarCampoVacio(txtImporte) & Validaciones.validarCampoNumericoDouble(txtImporte);
            if (validador)
            {
                try
                {
                    validarImportePositivo();
                    validarCuentaHabilitada();
                    validarVencimientoTC();

                    Deposito deposito = new Deposito();
                    deposito.fecha = FECHA_ACTUAL;
                    deposito.importe = Double.Parse(txtImporte.Text);
                    deposito.cuentaNumero = Int64.Parse(comboCuentaOrigen.Text);
                    deposito.monedaTipo = ((TipoMoneda)comboTipoMoneda.SelectedItem).codigo;
                    deposito.tarjetaNumero = ((Tarjeta)comboTarjeta.SelectedItem).tarjetaNumero;

                    depositoService.Insert(deposito);
                    MessageBox.Show("Se ha realizado el deposito de saldo. ", "Deposito realizado satisfactoriamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarDatos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message , "Error en efectuar el deposito", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }
            }

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

                    saldoPosterior = saldoActual + importe;
                    lblSaldoPosterior.Text = saldoPosterior.ToString();

                }
            }
            catch (Exception) { }
        }

        private void mostrarComponentes(Boolean validate)
        {
            this.lblSaldoPosterior.Visible = validate;
            this.lblSaldoPosteriorRO.Visible = validate;
        }

        private void actualizarSaldoActual()
        {
            lblSaldoActual.Text = cuentaService.getSaldo(Convert.ToInt64(comboCuentaOrigen.Text.ToString())).ToString();
        }

        private void limpiarDatos()
        {
            txtImporte.BackColor = System.Drawing.Color.White;
            txtImporte.Text = String.Empty;
            comboCuentaOrigen.SelectedIndex = 0;
            comboTipoMoneda.SelectedIndex = 0;
            comboTarjeta.SelectedIndex = 0;
        }


        #endregion

        #region CargarCombos


        private void cargarComboCuentas()
        {
            if (Session.Usuario.SelectedRol.Id == (int)Entities.Enums.Roles.Admin)
            {
                if (Session.Cliente != null)
                {
                    listaCuentas = (List<Cuenta>)cuentaService.getByCliente(Session.Cliente.tipoDocumento, Session.Cliente.numeroDocumento);
                }
                else
                {
                    MessageBox.Show("Selecciones un cliente de Archivo -> Seleccion Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                clienteLogueado = clienteService.getClienteByUsername(usuarioLogueado.Username);
                listaCuentas = (List<Cuenta>)cuentaService.getByCliente(clienteLogueado.tipoDocumento, clienteLogueado.numeroDocumento);   
            }

            if (listaCuentas != null && listaCuentas.Count > 0)
            {
                comboCuentaOrigen.DataSource = listaCuentas;
            }
            else
            {
                throw new Exception("No posees cuentas para realizar retiros");

            }

        }

        private void cargarComboTipoMoneda()
        {
            listaTiposMoneda = (List<TipoMoneda>)tipoMonedaService.GetTiposMonedaByCuenta(comboCuentaOrigen.Text.ToString());
            comboTipoMoneda.DataSource = listaTiposMoneda;
            comboTipoMoneda.SelectedIndex = 0;
        }

        private void cargarComboTC()
        {
            long nroDocumento, tipoDocumento;
            nroDocumento = ((Cuenta)comboCuentaOrigen.SelectedItem).nroDoc;
            tipoDocumento = ((Cuenta)comboCuentaOrigen.SelectedItem).tipoDoc;
            //listaTC = (List<Tarjeta>)tarjetaService.getAllByCliente(clienteLogueado.tipoDocumento, clienteLogueado.numeroDocumento);
            listaTC = (List<Tarjeta>)tarjetaService.getAllByCliente(tipoDocumento, nroDocumento);
            comboTarjeta.DataSource = listaTC;
            comboTarjeta.SelectedIndex = 0;
        }


        #endregion

        #region Validaciones

        private void validarImportePositivo()
        {
            if (Double.Parse(txtImporte.Text) < 1)
            {
                throw new Exception("El importe debe ser mayor o igual a 1");
            }
        }

        private void validarCuentaHabilitada()
        {
            if (cuentaService.getEstado(Int64.Parse(comboCuentaOrigen.Text)) != (Int32)Entities.Enums.EstadosCuenta.Habilitada)
            {
                throw new OperationCanceledException("La cuenta no se encuentra habilitada");
            }
        }


        private void validarVencimientoTC()
        {
            Tarjeta tarjetaSeleccionada = ((Tarjeta)comboTarjeta.SelectedItem);

            if (DateTime.Compare(tarjetaSeleccionada.fechaVencimiento, FECHA_ACTUAL) <= 0)
            {
                throw new OperationCanceledException("La tarjeta seleccionada se encuentra vencida");
            }
        }
       
        #endregion


    }
}
