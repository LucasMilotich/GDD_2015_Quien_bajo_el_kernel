using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Entities;

namespace PagoElectronico.Login
{
    public partial class SeleccionRol : Form
    {
        //public IFuncionalidadService funcionalidadService { get; set; }

        public SeleccionRol()
        {
            InitializeComponent();
        }

        private void SeleccionRol_Load(object sender, EventArgs e)
        {
            cmbRoles.DataSource = Session.Usuario.Roles;
            btnAceptar.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Session.Usuario.SelectedRol = new Rol 
            {
                Id = Convert.ToInt32(cmbRoles.SelectedValue),
                Nombre = cmbRoles.SelectedText,
                Activo = true
            };

            this.DisplayForm(new Home());
        }

        private void DisplayForm(Form form)
        {
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormClosing += delegate { this.Show(); };
            form.Show();
            this.Hide();
        }
    }
}
