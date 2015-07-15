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
        ClienteService cliServ = new ClienteService();

        public Alta()
        {
            InitializeComponent();
        }

        #region Eventos
        /*************    Metodos de componentes       *************/

        private void Alta_Load(object sender, EventArgs e)
        {
            cmbPais.DataSource = new PaisService().GetAll();
            cmbTipoDoc.DataSource = new TipoDocumentoService().GetAll();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtApellido.Text = String.Empty;
            this.txtNombre.Text = String.Empty;
            this.txtMail.Text = String.Empty;
            this.txtCalle.Text = String.Empty;
            this.txtDpto.Text = String.Empty;
            this.txtPiso.Text = String.Empty;
            this.txtNumCalle.Text = String.Empty;
            this.txtLocalidad.Text = String.Empty;
            this.txtNroDoc.Text = String.Empty;
            this.dateTimePicker1.Value = DateTime.Now;

            this.txtApellido.BackColor = System.Drawing.Color.White;
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtMail.BackColor = System.Drawing.Color.White;
            this.txtCalle.BackColor = System.Drawing.Color.White;
            this.txtDpto.BackColor = System.Drawing.Color.White;
            this.txtPiso.BackColor = System.Drawing.Color.White;
            this.txtNumCalle.BackColor = System.Drawing.Color.White; ;
            this.txtLocalidad.BackColor = System.Drawing.Color.White;
            this.txtNroDoc.BackColor = System.Drawing.Color.White;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validaciones.validarCampoString(this.txtNombre)
                & Validaciones.validarCampoString(this.txtApellido)               
                & Validaciones.validarCampoMail(this.txtMail)
                & Validaciones.validarCampoString(this.txtCalle)
                & Validaciones.validarCampoAlfaNumerico(this.txtDpto)
                & Validaciones.validarCampoNumericoEntero(this.txtNumCalle)
                & Validaciones.validarCampoNumericoEntero(this.txtPiso)
                & Validaciones.validarCampoString(this.txtLocalidad)
                & Validaciones.validarCampoNumericoEntero(this.txtNroDoc)
                & this.cmbPais.SelectedValue != null)
            {
                try
                {
                    validarExisteDocumento();
                    validarExisteMail();
                    altaUsuario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error en efectuar el alta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        #region MetodosPrivados
        /*************    Metodos privados       *************/

        private void altaUsuario()
        {
            Cliente cliente = new Cliente();

            cliente.nombre = this.txtNombre.Text;
            cliente.apellido = this.txtApellido.Text;
            cliente.mail = this.txtMail.Text;
            cliente.domCalle = this.txtCalle.Text;
            cliente.domDpto = this.txtDpto.Text;
            cliente.localidad = this.txtLocalidad.Text;
            cliente.domNro = Int64.Parse(this.txtNumCalle.Text);
            cliente.domPiso = Int64.Parse(this.txtPiso.Text);
            cliente.fechaNacimiento = dateTimePicker1.Value;
            cliente.numeroDocumento = Int64.Parse(this.txtNroDoc.Text);
            cliente.tipoDocumento = ((TipoDocumento)this.cmbTipoDoc.SelectedItem).codigo;
            cliente.paisCodigo = ((Pais)this.cmbPais.SelectedItem).codigoPais;


            var form = new ABM_de_Usuario.AltaEdicion(cliente, this);
            form.Show();
            form.MdiParent = this.MdiParent;
        }
        
        #endregion

        #region ValidacionesPrivadas
        /*************   Validaciones privadas      *************/
        private void validarExisteDocumento()
        {
            long numeroDocu = Int64.Parse(this.txtNroDoc.Text);
            long tipoDocu = ((TipoDocumento)this.cmbTipoDoc.SelectedItem).codigo;

            if (cliServ.existeDocumento(numeroDocu, tipoDocu))
            {
                throw new Exception("El documento ingresado ya pertenece para un Cliente !");
            }
        }

        private void validarExisteMail()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}


