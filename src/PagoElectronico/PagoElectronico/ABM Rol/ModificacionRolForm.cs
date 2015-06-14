using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Services;
using PagoElectronico.Services.Interfaces;

namespace PagoElectronico.ABM_Rol
{
    public partial class ModificacionRolForm : Form
    {
        public ModificacionRolForm()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IRolService rolServ = new RolService();
            dgrRoles.DataSource = rolServ.getRoles(txtNombreRol.Text, chkActivo.Checked);
        }
    }
}
