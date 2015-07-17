using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Entities;
using PagoElectronico.Services;
using PagoElectronico.Common;

namespace PagoElectronico.Login
{
    public partial class SeleccionCliente : Form
    {
        public TipoDocumentoService tipoDocumentoService { get; set; }
        ClienteService clienteService = new ClienteService();

        public SeleccionCliente()
        {
            this.tipoDocumentoService = new TipoDocumentoService();
            InitializeComponent();
        }

        private void SeleccionCliente_Load(object sender, EventArgs e)
        {
            var listaTiposDocumentos = (List<TipoDocumento>)tipoDocumentoService.GetAll();
            comboTipoDoc.DataSource = listaTiposDocumentos;
            comboTipoDoc.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validaciones.validarCampoVacio(txtNroDoc))
            {
                var cliente = clienteService.getClienteByDNI(Convert.ToInt64(comboTipoDoc.SelectedValue), Convert.ToInt64(txtNroDoc.Text));
                if (cliente != null)
                {
                    Session.Cliente = cliente;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Documento no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else 
            {
                MessageBox.Show("Documento no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
