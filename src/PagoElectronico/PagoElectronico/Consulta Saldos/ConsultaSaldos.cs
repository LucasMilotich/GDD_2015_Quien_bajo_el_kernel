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
            if (Validaciones.validarCampoString(txtCuenta) && Validaciones.validarCampoVacio(txtCuenta))
            {
                SqlCommand command = DBConnection.CreateCommand();
                command.CommandText = " select top 10 * from [GD1C2015].[QUIEN_BAJO_EL_KERNEL].[CUENTA] ";
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
