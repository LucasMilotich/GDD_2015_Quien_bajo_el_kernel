using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Services.Interfaces;
using PagoElectronico.Services;
using PagoElectronico.Entities;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class AltaCuenta : Form
    {
        CuentaService cuentaService { get; set; }
        PaisService paisService { get; set; }
        TipoMonedaService tipoMonedaService { get; set; }
        ClienteService clienteService { get; set; }
        long NroCuenta { get; set; }
        Usuario usuario = Session.Usuario;
        //Para probar hasta q este el login: 10002 and cliente_numero_doc=45622098
        long tipoDocCliente = 10002, nroDocCliente = 45622098;

        public AltaCuenta(long nroCuenta)
        {
            cuentaService = new CuentaService();
            paisService = new PaisService();
            tipoMonedaService = new TipoMonedaService();
            clienteService = new ClienteService();
            InitializeComponent();
            this.NroCuenta = nroCuenta;
        }

        private void AltaCuenta_Load(object sender, EventArgs e)
        {
            cargarCampos();

            if (NroCuenta > 0)
            {
                Cuenta cuenta = cuentaService.GetCuentaByNumero(NroCuenta);
                cmbPaises.SelectedValue = cuenta.paisCodigo;
                cmbTiposCuenta.SelectedValue = cuenta.tipoCuenta;
                cmbMonedas.SelectedValue = cuenta.monedaTipo;
                txtCuenta.Text = cuenta.numero.ToString();
                this.Text = "Edición de Cuenta";
            }
            else
            {
                if (Session.Usuario.SelectedRol.Id == (int)Entities.Enums.Roles.Admin)
                {
                    lblCliente.Visible = true;
                    cmbClientes.Visible = true;
                    var clientes = clienteService.GetClientes();
                    cmbClientes.DataSource = clientes;
                }
            }
        }

        private void cargarCampos() 
        {
            var paises = paisService.GetAll();
            var monedas = tipoMonedaService.GetAll();
            var tiposCuenta = cuentaService.GetTiposCuenta();

            cmbPaises.DataSource = paises;
            cmbMonedas.DataSource = monedas;
            cmbTiposCuenta.DataSource = tiposCuenta;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int codPais = Convert.ToInt32(cmbPaises.SelectedValue.ToString());
            int tipoMoneda = Convert.ToInt32(cmbMonedas.SelectedValue.ToString());
            int tipoCuenta = Convert.ToInt32(cmbTiposCuenta.SelectedValue.ToString());
            //Aca iria el get del tipoDocCliente
            //y aca el del nroDocCliente

            if (txtCuenta.Text == "")
            {

                try
                {
                    cuentaService.InsertaCuenta(codPais, tipoMoneda, tipoCuenta, tipoDocCliente, nroDocCliente);
                    MessageBox.Show("Cuenta creada exitosamente. Recuerde que la misma permanecerá pendiente de activación hasta que abone el costo de apertura", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (OperationCanceledException ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "No se pudo crear la cuenta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo crear la cuenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                long numCuenta = Convert.ToInt64(txtCuenta.Text);
                try
                {
                    cuentaService.ModificaCuenta(numCuenta, tipoMoneda, tipoCuenta, codPais);
                    MessageBox.Show("Cuenta modificada exitosamente!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                catch (OperationCanceledException ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "No se pudo modificar la cuenta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error", "No se pudo modificar la cuenta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

    }
}
