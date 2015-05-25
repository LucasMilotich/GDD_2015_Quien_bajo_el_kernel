using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico;
using PagoElectronico.Common;

namespace PagoElectronico.ABM_Cliente
{

    public partial class Form1 : Form
    {
        Validaciones validador = new Validaciones();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private bool validarCampos()
        {
            /*
            validador.validarCampoObligatorio(txtNombre);
            validador.validarCampoObligatorio(txtApellido);
            validarCampoObligatorio(txtMail);
            validarCampoObligatorio(txtPais);
            validarCampoObligatorio(txtCalle);
            validarCampoObligatorio(txtLocalidad);
            validarCampoObligatorio(txtNacionalidad);
            validarCampoObligatorio(txtNroDoc);


            validarCampoString(txtNombre);
            validarCampoString(txtApellido);
            validarCampoMail(txtMail);
            validarCampoString(txtPais);
            validarCampoString(txtCalle);
            validarCampoString(txtLocalidad);
            validarCampoString(txtNacionalidad);
            validarCampoNumericoEntero(txtNroDoc);

            if (!string.IsNullOrEmpty(txtPiso.Text))
            {
                validarCampoNumericoEntero(txtPiso);
            }
            if (!string.IsNullOrEmpty(txtDpto.Text  ))
            {
                validarCampoNumericoEntero(txtDpto);
            }
            */
            return true;
        }
    }
}
