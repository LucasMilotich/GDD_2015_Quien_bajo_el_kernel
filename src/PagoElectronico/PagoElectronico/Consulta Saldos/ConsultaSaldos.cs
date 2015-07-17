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
using System.Data.SqlClient;
using PagoElectronico.Services;
using PagoElectronico.Entities;


namespace PagoElectronico.Consulta_Saldos
{
    public partial class ConsultaSaldos : Form
    {
        CuentaService cuentaService = new CuentaService();
        TransferenciaService transferenciaService = new TransferenciaService();
        RetiroService retiroService = new RetiroService();
        DepositoService depositoService = new DepositoService();
        ClienteService clienteService = new ClienteService();

        public ConsultaSaldos()
        {
            InitializeComponent();
        }


        /*************    Metodos de componentes       *************/

        private void ConsultaSaldos_Load(object sender, EventArgs e)
        {
            DataGridViewListado.ReadOnly = true;
            ocultarComponentes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bool validator = Validaciones.validarCampoNumericoEntero(txtCuenta) && Validaciones.validarCampoVacio(txtCuenta);
            if (validator)
            {
                try
                {
                    obtenerSaldo();
                    llenarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Atencion !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCuenta.Text = String.Empty;
            txtCuenta.BackColor = System.Drawing.Color.White;
            ocultarComponentes();
        }


        /*************    Metodos privados       *************/
        private void llenarGrilla()
        {
            if (rbDepositos.Checked)
            {
                DataGridViewListado.DataSource = depositoService.getUltimosCincoDepositosByCuenta(txtCuenta.Text);
            }
            if (rbRetiros.Checked)
            {
                DataGridViewListado.DataSource = retiroService.getUltimosCincoRetirosByCuenta(txtCuenta.Text);
            }
            if (rbTransferencias.Checked)
            {
                DataGridViewListado.DataSource = transferenciaService.getUltimasDiezTransferenciasByCuenta(txtCuenta.Text);
            }
        }

        private void obtenerSaldo()
        {
            var clienteLogueado = clienteService.getClienteByUsername(Session.Usuario.Username);
            if (clienteLogueado != null)
            {
                Session.Cliente = clienteLogueado;
                long cuenta = Convert.ToInt64(txtCuenta.Text.ToString());
                lblSaldo.Text = cuentaService.getSaldoByCliente(cuenta, Session.Cliente.numeroDocumento).ToString();
                if (String.Equals("0", lblSaldo.Text.ToString()))
                {
                    throw new Exception("No se encontro la cuenta buscada");
                }
                mostrarComponentes();
            }
            else
            {
                throw new Exception("Seleccione un cliente");
            }
        }

        private void mostrarComponentes()
        {
            if (txtCuenta.Text != String.Empty)
            {
                groupBoxListado.Visible = true;
                lblSaldoReadOnly.Visible = true;
                lblSaldo.Visible = true;
            }
        }

        private void ocultarComponentes()
        {
            groupBoxListado.Visible = false;
            lblSaldoReadOnly.Visible = false;
            lblSaldo.Visible = false;

        }



    }
}
