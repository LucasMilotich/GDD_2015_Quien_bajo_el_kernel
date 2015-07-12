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
using PagoElectronico.Services;
using PagoElectronico.Entities;

namespace PagoElectronico.ABM_Cliente
{

    public partial class Alta : Form
    {
        Validaciones validador = new Validaciones();

        public Alta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             Cliente cliente = new Cliente();
           if (Validaciones.validarCampoString(this.txtNombre)
                && Validaciones.validarCampoString(this.txtApellido)
                && this.dateTimePicker1.Text != null
                && this.cmbTipoDoc.SelectedValue != null
                && Validaciones.validarCampoString(this.txtMail)
                && Validaciones.validarCampoString(this.txtPais)
                && Validaciones.validarCampoString(this.txtCalle)
                && Validaciones.validarCampoString(this.txtNumCalle)
                && Validaciones.validarCampoString(this.txtPiso)
                && Validaciones.validarCampoString(this.txtLocalidad)
                && Validaciones.validarCampoString(this.txtNacionalidad)
                && Validaciones.validarCampoString(this.txtNroDoc))
            {


                cliente.nombre = this.txtNombre.Text;
                cliente.apellido = this.txtApellido.Text;
                cliente.fechaNacimiento = Convert.ToDateTime(dateTimePicker1.Text);
                cliente.tipoDocumento = Convert.ToInt32(this.cmbTipoDoc.SelectedValue);
                cliente.numeroDocumento = Convert.ToInt32(this.txtNroDoc.Text);
                cliente.mail = this.txtMail.Text;
               // this.txtPais.Text;
                cliente.domCalle = this.txtCalle.Text;
                cliente.domNro = this.txtNumCalle.Text;
                cliente.domPiso = this.txtPiso.Text;
                cliente.localidad = this.txtLocalidad.Text;
                cliente.nacionalidad = this.txtNacionalidad.Text;

                Show(new ABM_de_Usuario.AltaEdicion(cliente));
                ClienteService cliServ = new ClienteService();
                cliServ.createCliente(cliente);

            }
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

        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Alta_Load(object sender, EventArgs e)
        {

            foreach (var item in new TipoDocumentoService().GetAll())
            {
                this.cmbTipoDoc.Items.Add(item);
            }
        }
    }
}
