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

namespace PagoElectronico.ABM_Rol
{
    public partial class ConsultaRolFrom : Form
    {
        public ConsultaRolFrom()
        {
            InitializeComponent();
        }

      

        private void ConsultaRol_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IRolService rolServ = new RolService();

            dgrRoles.DataSource = rolServ.getRoles(txtNombreRol.Text, chkActivo.Checked);
            
        }

        private void dgrRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreRol.Clear();
            chkActivo.Checked = false;
        }
    }
}
