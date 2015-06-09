using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Common;

namespace PagoElectronico.Transferencias
{
    public partial class TransferenciasCuentas : Form
    {
        public TransferenciasCuentas()
        {
            InitializeComponent();
            cargarComboBox();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCuentaDestino.BackColor = System.Drawing.Color.White;
            txtImporte.BackColor = System.Drawing.Color.White;
            txtCuentaDestino.Text = String.Empty;
            txtImporte.Text = String.Empty;
            comboCuentaOrigen.SelectedIndex = 0;
        }

        private void cargarComboBox()
        {
            comboCuentaOrigen.Items.Add("");
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            Validaciones.validarCampoNumericoDouble(txtImporte);
          //  Validaciones.validarCampoVacio(txtImporte);
        }

      
    }
}
