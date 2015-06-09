using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Common;

namespace PagoElectronico.Listados
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
            cargarComboBoxTrimestres();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!(Validaciones.validarCampoVacio(txtCuenta) || Validaciones.validarCampoString(txtCuenta)))
            {
                //
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCuenta.Text = String.Empty;
            txtCuenta.BackColor = System.Drawing.Color.White;
            comboTrimestres.SelectedIndex = 0;
        }

        private void cargarComboBoxTrimestres()
        {
            comboTrimestres.Items.Add("Trimestre 1");
            comboTrimestres.Items.Add("Trimestre 2");
            comboTrimestres.Items.Add("Trimestre 3");
            comboTrimestres.Items.Add("Trimestre 4");
            comboTrimestres.SelectedIndex = 0;
        }

    }
}
