using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Common;

namespace PagoElectronico.Login
{
    public partial class CambiarPassword : Form
    {
        public CambiarPassword()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validaciones.validarCampoVacio(txtPasswordNueva1) & Validaciones.validarCampoVacio(txtPasswordNueva2) & Validaciones.validarCampoVacio(txtPasswordActual))
            {
                validarPasswordVieja();
                validarPasswordsNuevasIguales(); 
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
            
        }
    }
}
