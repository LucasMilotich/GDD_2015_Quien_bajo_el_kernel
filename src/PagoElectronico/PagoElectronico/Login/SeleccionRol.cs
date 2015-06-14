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

namespace PagoElectronico.Login
{
    public partial class SeleccionRol : Form
    {
        public FuncionalidadService funcionalidadService { get; set; }

        public SeleccionRol()
        {
            this.funcionalidadService = new FuncionalidadService();
            InitializeComponent();
        }

        private void SeleccionRol_Load(object sender, EventArgs e)
        {
            cmbRoles.DataSource = Session.Usuario.Roles;
            btnAceptar.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedValue != null && Convert.ToInt32(cmbRoles.SelectedValue) > 0)
            {
                var funcionalidades = funcionalidadService.GetByRolId(Convert.ToInt32(cmbRoles.SelectedValue)).ToList();
                Session.Usuario.SelectedRol = new Rol
                {
                    Id = Convert.ToInt32(cmbRoles.SelectedValue),
                    Nombre = cmbRoles.SelectedText,
                    Activo = true,
                    Funcionalidades = funcionalidades
                };

                this.DisplayForm(new Home());
            }
            else 
            {
                MessageBox.Show("Rol seleccionado no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
