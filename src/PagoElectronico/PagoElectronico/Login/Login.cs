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

namespace PagoElectronico.Login
{
    public partial class Login : Form
    {
        public ILoginService loginService { get; set; }

        public Login()
        {
            this.loginService = new LoginService();
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {

                Usuario usuario = this.loginService.Login(txtUsername.Text, txtPassword.Text);

                if (usuario != null)
                {
                    //usuario.Rol.Funcionalidades = this.FuncionalidadService.GetByRolId(usuario.Rol.Id);
                    Session.Usuario = usuario;
                    this.Hide();
                    Home formHome = new Home();
                    formHome.Show();
                }
                else
                {
                    MessageBox.Show("El usuario ingresado no existe", "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK);
            }            
        }
    }
}
