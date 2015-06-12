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

        //Para probar hasta q este el login: 10002 and cliente_numero_doc=45622098
        long tipoDocCliente = 10002, nroDocCliente = 45622098;

        public TransferenciasCuentas()
        {
            InitializeComponent();
            cargarComboCuentas();
            cargarComboTipoMoneda();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCuentaDestino.BackColor = System.Drawing.Color.White;
            txtImporte.BackColor = System.Drawing.Color.White;
            txtCuentaDestino.Text = String.Empty;
            txtImporte.Text = String.Empty;
            comboCuentaOrigen.SelectedIndex = 0;
            comboTipoMoneda.SelectedIndex = 0;
            ocultarComponentes();
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

        private void comboCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarSaldoActual();
            recalcularSaldoPosterior();
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
                //deberia salir del form, no se como hacerlo
            }

        }

        private void cargarComboTipoMoneda()
        {
            listaTiposMoneda = (List<TipoMoneda>)tipoMonedaService.getAll();
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

                if (txtImporte.Text.Length == 0)
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
            catch (Exception)
            {
            }
        }

        private void actualizarSaldoActual()
        {
            lblSaldoActual.Text = cuentaService.getSaldo(Convert.ToInt64(comboCuentaOrigen.Text.ToString())).ToString();
        }

        private void realizarTransferencia()
        {
            if (Validaciones.validarCampoVacio(txtImporte) & Validaciones.validarCampoVacio(txtCuentaDestino) & Validaciones.validarCampoNumericoDouble(txtImporte) & Validaciones.validarCampoNumericoDouble(txtCuentaDestino))
            {
                //**Las cuentas cerradas o pendientes de activacion no pueden recibir dinero
                //Falta implementar esto
                int estadoDeCuenta = 0;//int estadoDeCuenta = cuentaService.getEstado(Convert.ToInt64(txtCuentaDestino.Text.ToString()));
                if (estadoDeCuenta == 1)
                {
                    //falta implementar!!
                }
                else
                {
                    try
                    {
                        Transferencia transferencia = new Transferencia();
                        transferencia.origen = Convert.ToInt64(comboCuentaOrigen.Text);
                        transferencia.destino = Convert.ToInt64(txtCuentaDestino.Text);
                        transferencia.fecha = DateTime.Now;
                        transferencia.importe = Convert.ToInt64(txtImporte.Text);
                        transferencia.costo = calcularCosto();
                        transferencia.monedaTipo = listaTiposMoneda.Find(x => string.Equals(x.descripcion, comboTipoMoneda.Text.ToString())).codigo; //esta mal esto en realidad uan cuenta ya tiene su tipo de moneda prefijada

                        transferenciaService.Save(transferencia);
                        MessageBox.Show("Transferencia realizada exitosamente. Saldo actual:" + lblSaldoPosterior.Text.ToString(), "Atencion !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo realizar la transferencia. ERROR: " + ex.Message.ToString(), "Atencion !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtCuentaDestino_TextChanged(object sender, EventArgs e)
        {
            recalcularSaldoPosterior();
        }

    }
}
