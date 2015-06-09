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

namespace PagoElectronico.Consulta_Saldos
{
    public partial class ConsultaSaldos : Form
    {
        public ConsultaSaldos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Validaciones.validarCampoAlfaNumerico(txtCuenta) && Validaciones.validarCampoVacio(txtCuenta))
            {
                SqlCommand command = DBConnection.CreateCommand();
                if (rbDepositos.Checked)
                {
                    command.CommandText = "select top 5* from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].DEPOSITO  where cuenta_numero=" + txtCuenta.Text.ToString() + "  order by fecha desc ";
                }
                if (rbRetiros.Checked)
                {
                    command.CommandText = "select top 5 * from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].RETIRO  where cuenta= " + txtCuenta.Text.ToString() + " order by fecha desc";
                }
                if (rbTransferencias.Checked)
                {
                    command.CommandText = "  select *  from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].TRANSFERENCIA  where origen=" + txtCuenta.Text.ToString() + " or destino=" + txtCuenta.Text.ToString() + "  order by fecha desc  ";
                }

                DataGridViewListado.DataSource = DBConnection.EjecutarComandoSelect(command);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCuenta.Text = String.Empty;
            txtCuenta.BackColor = System.Drawing.Color.White;
        }
    }
}
