using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Services;
using PagoElectronico.Entities;

namespace PagoElectronico.ABM_Rol
{
    public partial class CreacionRolForm : Form
    {
        public CreacionRolForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            RolService rolServv = new RolService();
            Rol rol = new Rol();
            rol.Nombre = txtNombre.Text;
            rol.Activo = chkActivo.Checked;

            rolServv.crearRol(rol);
        }
    }
}
