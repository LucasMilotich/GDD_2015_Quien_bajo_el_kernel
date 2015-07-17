using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Common;
using System.Data.SqlClient;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;
using PagoElectronico.Services;
using PagoElectronico.Entities.Enums;
using System.Configuration;


namespace PagoElectronico.Transferencias
{
    public partial class TransferenciasCuentas : Form
    {
        TransferenciaService transferenciaService = new TransferenciaService();
        CuentaService cuentaService = new CuentaService();
        ClienteService clienteService = new ClienteService();
        TipoMonedaService tipoMonedaService = new TipoMonedaService();
        TransaccionService transaccionService = new TransaccionService();
        List<TipoMoneda> listaTiposMoneda;
        List<Cuenta> listaCuentas;

        Cliente clienteLogueado;
        Usuario usuarioLogueado = Session.Usuario;

        // ver el caso de un admin q no tenga cuentas, explota
        // un admin puede hacer retiro o trans de cualquier cuenta ??

        DateTime FECHA_ACTUAL = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);

        public TransferenciasCuentas()
        {
            InitializeComponent();
            obtenerCliente();
            cargarComboCuentas();
        }

        #region Eventos
        /*************    Metodos de componentes       *************/
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            realizarTransferencia();
            actualizarSaldoActual();
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            recalcularSaldoPosterior();
        }

        private void txtCuentaDestino_TextChanged(object sender, EventArgs e)
        {
            recalcularSaldoPosterior();
        }

        private void comboCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarSaldoActual();
            recalcularSaldoPosterior();
            cargarComboTipoMoneda();
        }

        #endregion

        #region metodosPrivados
        /*************    Metodos privados       *************/
        private void obtenerCliente()
        {
            try
            {
                if (Session.Usuario.SelectedRol.Id == (int)Entities.Enums.Roles.Admin)
                {
                    clienteLogueado = Session.Cliente;
                    if (clienteLogueado == null)
                    {
                        MessageBox.Show("Selecciones un cliente de Archivo -> Seleccion Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                    }
                }
                else
                {
                    clienteLogueado = clienteService.getClienteByUsername(usuarioLogueado.Username);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario actual no posee cuentas asociadas ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void realizarTransferencia()
        {
            if (Validaciones.validarCampoVacio(txtImporte) & Validaciones.validarCampoVacio(txtCuentaDestino) & Validaciones.validarCampoNumericoDouble(txtImporte) & Validaciones.validarCampoNumericoDouble(txtCuentaDestino))
            {
                try
                {
                    double saldoActual = Convert.ToDouble(lblSaldoActual.Text.ToString());
                    double importe = Convert.ToDouble(txtImporte.Text.ToString());
                    double saldoPosterior = Convert.ToDouble(lblSaldoPosterior.Text.ToString());
                    double costo = calcularCosto(importe);
                    long origen = Convert.ToInt64(comboCuentaOrigen.Text);
                    long destino = Convert.ToInt64(txtCuentaDestino.Text);

                    validarEstadoCuentaOrigen(origen);
                    validarEstadoCuentaDestino(destino);
                    validarSaldoDisponible(saldoPosterior);

                    Transferencia transferencia = new Transferencia();
                    transferencia.origen = origen;
                    transferencia.destino = destino;
                    transferencia.fecha = FECHA_ACTUAL;
                    transferencia.importe = importe;
                    transferencia.costo = costo;
                    transferencia.monedaTipo = cuentaService.getMonedaTipo(origen);

                    transferenciaService.GuardarTransferencia(transferencia);
                    MessageBox.Show("Transferencia realizada exitosamente. Saldo actual: " + lblSaldoPosterior.Text.ToString(), "Atencion !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    inhabilitarCuentaSiCorresponde();
                    limpiarDatos();
                }
                catch (OperationCanceledException ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "No se pudo realizar la transferencia. !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La cuenta destino no existe", "No se pudo realizar la transferencia. !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void inhabilitarCuentaSiCorresponde()
        {
            long cuenta = Convert.ToInt64(comboCuentaOrigen.Text);
            if (transaccionService.GetCountTransaccionesByCuenta(cuenta) > 5)
            {
                cuentaService.inhabilitarCuenta(cuenta, FECHA_ACTUAL);
                MessageBox.Show("La cuenta fue inhabilitada por superar las 5 transacciones sin facturar", "Cuenta inhabilitada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double calcularCosto(double importe)
        {
            Cuenta cuentaSeleccionada = ((Cuenta)comboCuentaOrigen.SelectedItem);
            if (listaCuentas.Any(x => x.numero == Int64.Parse(txtCuentaDestino.Text)))
            {
                return 0;                       // Transferencias entre sus cuentas no tiene costo
            }
            if (cuentaSeleccionada.tipoCuenta == (int)TiposCuentaEnum.Gratis)
            {
                return (importe * Convert.ToDouble(ConfigurationManager.AppSettings["PorcentajeTipoGratis"]));
            }
            else if (cuentaSeleccionada.tipoCuenta == (int)TiposCuentaEnum.Bronce)
            {
                return (importe * Convert.ToDouble(ConfigurationManager.AppSettings["PorcentajeTipoBronce"]));
            }
            else if (cuentaSeleccionada.tipoCuenta == (int)TiposCuentaEnum.Plata)
            {
                return (importe * Convert.ToDouble(ConfigurationManager.AppSettings["PorcentajeTipoPlata"]));
            }
            else if (cuentaSeleccionada.tipoCuenta == (int)TiposCuentaEnum.Oro)
            {
                return (importe * Convert.ToDouble(ConfigurationManager.AppSettings["PorcentajeTipoOro"]));
            }
            else
            {
                throw new Exception("El tipo de cuenta de la cuenta seleccionada no es correcto");
            }
        }

        private void recalcularSaldoPosterior()
        {
            try
            {
                double saldoActual, saldoPosterior, costo, importe;

                if (txtImporte.Text.Length == 0 || txtCuentaDestino.Text.Length == 0)
                {
                    ocultarComponentes();
                }
                else
                {
                    mostrarComponentes();

                    saldoActual = Convert.ToDouble(lblSaldoActual.Text);
                    importe = Convert.ToDouble(txtImporte.Text);
                    costo = calcularCosto(importe);
                    lblCosto.Text = costo.ToString();

                    if (String.Equals(comboCuentaOrigen.Text.ToString(), txtCuentaDestino.Text.ToString()))
                    {
                        lblSaldoPosterior.Text = lblSaldoActual.Text;
                    }
                    else
                    {
                        saldoPosterior = saldoActual - importe;
                        lblSaldoPosterior.Text = saldoPosterior.ToString();
                    }
                }
            }
            catch (Exception) { ocultarComponentes(); }
        }

        private void actualizarSaldoActual()
        {
            lblSaldoActual.Text = cuentaService.getSaldo(Convert.ToInt64(comboCuentaOrigen.Text.ToString())).ToString();
        }

        private void cargarComboCuentas()
        {
            if (clienteLogueado != null)
            {

                listaCuentas = (List<Cuenta>)cuentaService.getByCliente(clienteLogueado.tipoDocumento, clienteLogueado.numeroDocumento);
                if (listaCuentas.Count > 0)
                {
                    comboCuentaOrigen.DataSource = listaCuentas;
                }
                else
                {
                    MessageBox.Show("No posees cuentas para realizar transferencias", "Atencion !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void cargarComboTipoMoneda()
        {
            listaTiposMoneda = (List<TipoMoneda>)tipoMonedaService.GetTiposMonedaByCuenta(comboCuentaOrigen.Text.ToString());
            foreach (var item in listaTiposMoneda)
            {
                comboTipoMoneda.Items.Add(item.descripcion);
            }

            comboTipoMoneda.SelectedIndex = 0;
        }

        private void ocultarComponentes()
        {
            lblSaldoPosterior.Visible = false;
            lblSaldoPosteriorRO.Visible = false;
            lblCostoRO.Visible = false;
            lblCosto.Visible = false;
        }

        private void mostrarComponentes()
        {
            lblSaldoPosterior.Visible = true;
            lblSaldoPosteriorRO.Visible = true;
            lblCostoRO.Visible = true;
            lblCosto.Visible = true;
        }

        private void limpiarDatos()
        {
            txtCuentaDestino.BackColor = System.Drawing.Color.White;
            txtImporte.BackColor = System.Drawing.Color.White;
            txtCuentaDestino.Text = String.Empty;
            txtImporte.Text = String.Empty;
            comboCuentaOrigen.SelectedIndex = 0;
            comboTipoMoneda.SelectedIndex = 0;
            ocultarComponentes();
        }

        #endregion

        #region validacionesPrivadas
        /*************    Validadores privados       *************/
        private void validarEstadoCuentaOrigen(long unaCuenta)
        {
            int estadoDeCuenta = cuentaService.getEstado(unaCuenta);
            if (estadoDeCuenta == (Int32)Entities.Enums.EstadosCuenta.Cerrada || estadoDeCuenta == (Int32)Entities.Enums.EstadosCuenta.PendienteActivacion || estadoDeCuenta == (Int32)Entities.Enums.EstadosCuenta.Inhabilitada)
            {
                throw new OperationCanceledException("La cuenta origen se encuentra inhabilitada, cerrada o pendiente de activacion");
            }
        }

        private void validarEstadoCuentaDestino(long unaCuenta)
        {
            int estadoDeCuenta = cuentaService.getEstado(unaCuenta);
            if (estadoDeCuenta == (Int32)Entities.Enums.EstadosCuenta.Cerrada || estadoDeCuenta == (Int32)Entities.Enums.EstadosCuenta.PendienteActivacion)
            {
                throw new OperationCanceledException("La cuenta destino se encuentra cerrada o pendiente de activacion");
            }
        }

        private void validarSaldoDisponible(double saldoPosterior)
        {
            if (saldoPosterior < 0)
            {
                throw new OperationCanceledException("El saldo actual no es suficiente");
            }
        }

        #endregion
    }
}
