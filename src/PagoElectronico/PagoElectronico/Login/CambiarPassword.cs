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
using System.Security.Cryptography;

namespace PagoElectronico.Login
{
    public partial class CambiarPassword : Form
    {
        UsuarioService userService = new UsuarioService();

        Usuario usuarioLogueado = Session.Usuario;
        
        public CambiarPassword()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validaciones.validarCampoVacio(txtPasswordNueva1) & Validaciones.validarCampoVacio(txtPasswordNueva2) & Validaciones.validarCampoVacio(txtPasswordActual))
            {
                try
                {
                    validarPasswordVieja();
                    validarPasswordsNuevasIguales();
                    usuarioLogueado.Password = txtPasswordActual.Text;
                    userService.update(usuarioLogueado);

                    MessageBox.Show("La contraseña se ha cambiado correctamente", "Contraseña actualizada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "No se pudo cambiar la contraseña !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
            }
        }

        private void validarPasswordsNuevasIguales()
        {
            if (txtPasswordNueva1.Text != txtPasswordNueva2.Text)
            {
                throw new Exception("Las contraseñas ingresadas no coinciden");
            }
        }

        private void validarPasswordVieja()
        {
            usuarioLogueado.Password = txtPasswordActual.Text;
            if (usuarioLogueado.HashedPassword.ToString() != userService.getPasswordHashedByUsername(usuarioLogueado.Username))
            {
                throw new Exception("La contraseña actual no es correcta ");
            }
        }
    }
}
