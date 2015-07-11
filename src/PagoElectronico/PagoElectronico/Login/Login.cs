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
using PagoElectronico.Entities;
using PagoElectronico.Common;

namespace PagoElectronico.Login
{
    public partial class Login : Form
    {
        public ILoginService loginService { get; set; }
        public FuncionalidadService funcionalidadService { get; set; }

        public Login()
        {
            this.loginService = new LoginService();
            this.funcionalidadService = new FuncionalidadService();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = null;
                bool isValid = Validaciones.validarCampoVacio(txtUsername);
                isValid = Validaciones.validarCampoVacio(txtPassword) && isValid;
                if (isValid)
                {
                    usuario = this.loginService.Login(txtUsername.Text, txtPassword.Text);

                    if (usuario != null)
                    {
                        if (usuario.Habilitado)
                        {
                            Session.Usuario = usuario;
                            if (usuario.Roles.Count > 1)
                            {
                                this.DisplayForm(new SeleccionRol());
                            }
                            else
                            {
                                usuario.SelectedRol = usuario.Roles.FirstOrDefault();
                                usuario.SelectedRol.Funcionalidades = this.funcionalidadService.GetByRolId(usuario.SelectedRol.Id).ToList();
                                this.DisplayForm(new Home());
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Su usuario ha sido inhabilitado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario ingresado no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else 
                {
                    MessageBox.Show("Debe ingresar ambos campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK);
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

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Environment.Exit(1);
            }
        }
    }
}
