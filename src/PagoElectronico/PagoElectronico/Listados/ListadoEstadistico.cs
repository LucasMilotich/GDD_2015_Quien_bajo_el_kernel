using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Common;
using PagoElectronico.Entities;
using PagoElectronico.Services;

namespace PagoElectronico.Listados
{
    public partial class ListadoEstadistico : Form
    {
        PaisService paisService = new PaisService();
        ClienteService clienteService = new ClienteService();

        public ListadoEstadistico()
        {
            InitializeComponent();
            cargarComboBoxTrimestres();
            dataGridViewListado.ReadOnly = true;
            groupBoxListado.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if ((Validaciones.validarCampoVacio(txtAnio) & Validaciones.validarCampoNumericoEntero(txtAnio)))
            {
                realizarBusqueda();
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtAnio.Text = String.Empty;
            txtAnio.BackColor = System.Drawing.Color.White;
            comboTrimestres.SelectedIndex = 0;
            dataGridViewListado.DataSource = null;
            groupBoxListado.Visible = false;
        }

        private void cargarComboBoxTrimestres()
        {
            comboTrimestres.Items.Add("Trimestre 1");
            comboTrimestres.Items.Add("Trimestre 2");
            comboTrimestres.Items.Add("Trimestre 3");
            comboTrimestres.Items.Add("Trimestre 4");
            comboTrimestres.SelectedIndex = 0;
        }

        private void realizarBusqueda()
        {
            DateTime fechaDesde, fechaHasta;
            int anio = Convert.ToInt32(txtAnio.Text);

            switch (comboTrimestres.SelectedIndex)
            {
                case 0:
                    fechaDesde = new DateTime(anio, 1, 1);
                    break;
                case 1:
                    fechaDesde = new DateTime(anio, 4, 1);
                    break;
                case 2:
                    fechaDesde = new DateTime(anio, 7, 1);
                    break;
                case 3:
                    fechaDesde = new DateTime(anio, 10, 1);
                    break;
                default:
                    throw new Exception("Eror en la selecion del trimestre");
            }
            fechaHasta = fechaDesde.AddMonths(3).AddDays(-1);

            if (rbClientesCantComisiones.Checked == true)
            {

            }
            else if (rbClientesCantTransacciones.Checked == true)
            {
                dataGridViewListado.DataSource = clienteService.getByMayorIngresosEgresos(fechaDesde, fechaHasta);
            }
            else if (rbClientesCuentasInhabilitadas.Checked == true)
            {

            }
            else if (rbPaisesCantMovimientos.Checked == true)
            {
                dataGridViewListado.DataSource = paisService.getByMayorIngresosEgresos(fechaDesde, fechaHasta);
            }
            else if (rbTotalFacturado.Checked == true)
            {

            }
            else
            {
                throw new Exception("Eror en la selecion del radioButton");
            }
            groupBoxListado.Visible = true;
        }

    }
}
