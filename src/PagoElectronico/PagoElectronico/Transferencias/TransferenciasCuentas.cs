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


namespace PagoElectronico.Transferencias
{
    public partial class TransferenciasCuentas : Form
    {
        TransferenciaService transferenciaService = new TransferenciaService();
        CuentaService cuentaService = new CuentaService();
        TipoMonedaService tipoMonedaService = new TipoMonedaService();
        List<TipoMoneda> listaTiposMoneda;
        List<long> listaCuentas;

        Usuario usuario = Session.Usuario;
        //Para probar hasta q este el login: 10002 and cliente_numero_doc=45622098
        long tipoDocCliente = 10002, nroDocCliente = 45622098;

        public TransferenciasCuentas()
        {
            InitializeComponent();
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


        /*************    Metodos privados       *************/
        private void realizarTransferencia()
        {
            if (Validaciones.validarCampoVacio(txtImporte) & Validaciones.validarCampoVacio(txtCuentaDestino) & Validaciones.validarCampoNumericoDouble(txtImporte) & Validaciones.validarCampoNumericoDouble(txtCuentaDestino))
            {
                try
                {
                    double saldoActual = Convert.ToDouble(lblSaldoActual.Text.ToString());
                    double importe = Convert.ToDouble(txtImporte.Text.ToString());
                    double saldoPosterior = Convert.ToDouble(lblSaldoPosterior.Text.ToString());
                    double costo = calcularCosto();
                    long origen = Convert.ToInt64(comboCuentaOrigen.Text);
                    long destino = Convert.ToInt64(txtCuentaDestino.Text);

                    validarEstadoCuenta(destino);
                    validarSaldoDisponible(saldoPosterior);

                    Transferencia transferencia = new Transferencia();
                    transferencia.origen = origen;
                    transferencia.destino = destino;
                    transferencia.fecha = DateTime.Now;
                    transferencia.importe = importe;
                    transferencia.costo = calcularCosto();
                    transferencia.monedaTipo = cuentaService.getMonedaTipo(origen);

                    transferenciaService.GuardarTransferencia(transferencia);
                    MessageBox.Show("Transferencia realizada exitosamente. Saldo actual: " + lblSaldoPosterior.Text.ToString(), "Atencion !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarDatos();
                }
                catch (OperationCanceledException ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "No se pudo realizar la transferencia. !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("La cuenta destino no existe", "No se pudo realizar la transferencia. !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private double calcularCosto()
        {
            if (listaCuentas.Contains(Convert.ToInt64(txtCuentaDestino.Text.ToString())))
            {
                return 0;
            }
            return 2;
            //como calculo esto?????
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
                    costo = calcularCosto();
                    lblCosto.Text = costo.ToString();

                    if (String.Equals(comboCuentaOrigen.Text.ToString(), txtCuentaDestino.Text.ToString()))
                    {
                        lblSaldoPosterior.Text = lblSaldoActual.Text;
                    }
                    else
                    {
                        saldoPosterior = saldoActual - importe - costo;
                        lblSaldoPosterior.Text = saldoPosterior.ToString();
                    }
                }
            }
            catch (Exception) { }
        }

        private void actualizarSaldoActual()
        {
            lblSaldoActual.Text = cuentaService.getSaldo(Convert.ToInt64(comboCuentaOrigen.Text.ToString())).ToString();
        }

        private void cargarComboCuentas()
        {
            listaCuentas = (List<long>)cuentaService.getByCliente(tipoDocCliente, nroDocCliente);
            if (listaCuentas.Count > 0)
            {
                comboCuentaOrigen.DataSource = listaCuentas;
            }
            else
            {
                MessageBox.Show("No posees cuentas para realizar transferencias", "Atencion !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
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


        /*************    Validadores privados       *************/
        private void validarEstadoCuenta(long cuentaDestino)
        {
            int estadoDeCuenta = cuentaService.getEstado(cuentaDestino);
            if (estadoDeCuenta == 1 || estadoDeCuenta == 2)
            {
                throw new OperationCanceledException("La cuenta destino se encuentra en cerrada o pendiente de activacion");
            }
        }

        private void validarSaldoDisponible(double saldoPosterior)
        {
            if (saldoPosterior < 0)
            {
                throw new OperationCanceledException("El saldo actual no es suficiente");
            }
        }

    }
}
