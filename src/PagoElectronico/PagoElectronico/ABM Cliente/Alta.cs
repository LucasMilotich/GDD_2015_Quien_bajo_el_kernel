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
                  && cmbPais.SelectedValue != null
                  && Validaciones.validarCampoString(this.txtCalle)
                  && Validaciones.validarCampoNumericoEntero(this.txtNumCalle)
                  && Validaciones.validarCampoNumericoEntero(this.txtPiso)
                  && Validaciones.validarCampoString(this.txtLocalidad)
                  && Validaciones.validarCampoNumericoEntero(this.txtNroDoc))
             {



                 cliente.nombre = this.txtNombre.Text;
                 cliente.apellido = this.txtApellido.Text;
                 cliente.fechaNacimiento = Convert.ToDateTime(dateTimePicker1.Text);
                 cliente.tipoDocumento = Convert.ToInt32(this.cmbTipoDoc.SelectedValue);
                 cliente.numeroDocumento = Convert.ToInt32(this.txtNroDoc.Text);
                 cliente.mail = this.txtMail.Text;
                 cliente.paisCodigo = ((Pais)this.cmbPais.SelectedItem).codigoPais;
                 cliente.domCalle = this.txtCalle.Text;
                 cliente.domNro = Convert.ToInt32(this.txtNumCalle.Text);
                 cliente.domDpto = this.txtDpto.Text;
                 cliente.domPiso = Convert.ToInt32(this.txtPiso.Text);
                 cliente.localidad = this.txtLocalidad.Text;


                 ClienteService cliServ = new ClienteService();


                 var form = new ABM_de_Usuario.AltaEdicion(cliente,cliServ,this);
                 form.Show();
                 form.MdiParent = this.MdiParent;
                
                 
                 
                 

             }
             else MessageBox.Show("Error","Error",MessageBoxButtons.OK);
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

        private void groupBox1_Enter(object sensder, EventArgs e)
        {

        }

        private void Alta_Load(object sender, EventArgs e)
        {

            cmbPais.DataSource = new PaisService().GetAll();
            cmbTipoDoc.DataSource = new TipoDocumentoService().GetAll();
        }
    }
}


