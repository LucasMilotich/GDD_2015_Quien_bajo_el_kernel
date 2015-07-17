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

    public partial class AltaCliente : Form
    {
        //Declare your event
        public event EventHandler updateEvent;
        
        ClienteService cliServ = new ClienteService();
        TipoDocumentoService tipoDocumentoService = new TipoDocumentoService();
        PaisService paisService = new PaisService();

        List<TipoDocumento> listaTiposDocumentos;
        List<Pais> listaPaises;

        Boolean esAltaCliente;
        Cliente clienteParaModificar;

        public AltaCliente()
        {
            InitializeComponent();
            esAltaCliente = true;
        }

        public AltaCliente(long tipoDoc, long nroDoc)
        {
            InitializeComponent();
            esAltaCliente = false;
            clienteParaModificar = cliServ.getClienteByDNI(tipoDoc, nroDoc);
        }

        #region Eventos
        /*************    Metodos de componentes       *************/

        private void Alta_Load(object sender, EventArgs e)
        {
            cargarComboTipoDoc();
            cargarComboPaises();
            cargarComboEstado();
            habilitarModo(esAltaCliente);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarDatos();
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
                    Cliente client;
                    if (esAltaCliente)
                    {
                        validarExisteDocumento();
                        validarExisteMail(txtMail.Text);
                        client = materializarCliente();
                        altaCliente(client);
                    }
                    else
                    {
                        client = materializarCliente();
                        validarExisteMailParaCliente(txtMail.Text, client);                        
                        updateCliente(client);
                        MessageBox.Show("Cliente actualizado correctamente", "Actualizacion terminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        updateEvent(sender, e);
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error en efectuar el alta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region MetodosPrivados
        /*************    Metodos privados       *************/

        private void altaCliente(Cliente cli)
        {
            var form = new ABM_de_Usuario.AltaEdicion(cli, this);
            form.Show();
            form.MdiParent = this.MdiParent;
        }

        private Cliente materializarCliente()
        {
            Cliente clienteMaterializado = new Cliente();

            clienteMaterializado.nombre = this.txtNombre.Text;
            clienteMaterializado.apellido = this.txtApellido.Text;
            clienteMaterializado.mail = this.txtMail.Text;
            clienteMaterializado.domCalle = this.txtCalle.Text;
            clienteMaterializado.domDpto = this.txtDpto.Text;
            clienteMaterializado.localidad = this.txtLocalidad.Text;
            clienteMaterializado.domNro = Int64.Parse(this.txtNumCalle.Text);
            clienteMaterializado.domPiso = Int64.Parse(this.txtPiso.Text);
            clienteMaterializado.fechaNacimiento = dateTimePicker1.Value;
            clienteMaterializado.numeroDocumento = Int64.Parse(this.txtNroDoc.Text);
            clienteMaterializado.tipoDocumento = ((TipoDocumento)this.cmbTipoDoc.SelectedItem).codigo;
            clienteMaterializado.paisCodigo = ((Pais)this.cmbPais.SelectedItem).codigoPais;
            if (cmbEstado.SelectedItem == "Habilitado")
                clienteMaterializado.habilitado = true;
            else
                clienteMaterializado.habilitado = false;

            return clienteMaterializado;
        }


        private void updateCliente(Cliente cli)
        {
            cliServ.updateCliente(cli);
    }

        private void habilitarModo(bool esAltaCliente)
        {
            if (esAltaCliente)
            {
                limpiarDatos();

            }
            else
            {
                this.txtApellido.Text = clienteParaModificar.apellido;
                this.txtNombre.Text = clienteParaModificar.nombre;
                this.txtMail.Text = clienteParaModificar.mail;
                this.txtCalle.Text = clienteParaModificar.domCalle;
                this.txtDpto.Text = clienteParaModificar.domDpto;
                this.txtPiso.Text = clienteParaModificar.domPiso.ToString();
                this.txtNumCalle.Text = clienteParaModificar.domNro.ToString();
                this.txtLocalidad.Text = clienteParaModificar.localidad;
                this.dateTimePicker1.Value = clienteParaModificar.fechaNacimiento;
                this.cmbPais.SelectedItem = listaPaises.Find(x => x.codigoPais == clienteParaModificar.paisCodigo);

                this.cmbTipoDoc.SelectedItem = listaTiposDocumentos.Find(x => x.codigo == clienteParaModificar.tipoDocumento);
                this.txtNroDoc.Text = clienteParaModificar.numeroDocumento.ToString();

            }
            this.cmbTipoDoc.Enabled = esAltaCliente;
            this.txtNroDoc.Enabled = esAltaCliente;

        }

        private void limpiarDatos()
        {
            if (esAltaCliente)
            {
                this.txtNroDoc.Text = String.Empty;
            }
            this.txtApellido.Text = String.Empty;
            this.txtNombre.Text = String.Empty;
            this.txtMail.Text = String.Empty;
            this.txtCalle.Text = String.Empty;
            this.txtDpto.Text = String.Empty;
            this.txtPiso.Text = String.Empty;
            this.txtNumCalle.Text = String.Empty;
            this.txtLocalidad.Text = String.Empty;

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

        private void validarExisteMail(String mail)
        {
            if (cliServ.existeMail(mail))
            {
                throw new Exception("El mail ingresado ya pertenece a un Cliente !");
            }
        }

        private void validarExisteMailParaCliente(String mail, Cliente cli)
        {
            if (cliServ.existeMailParaOtroCliente(mail, cli))
            {
                throw new Exception("El mail ingresado pertenece a otro Cliente !");
            }
        }


        #endregion

        #region CargarCombos
        /*************   Cargar combos      *************/

        private void cargarComboTipoDoc()
        {
            listaTiposDocumentos = (List<TipoDocumento>)tipoDocumentoService.GetAll();
            cmbTipoDoc.DataSource = listaTiposDocumentos;
            cmbTipoDoc.SelectedIndex = 0;
        }

        private void cargarComboPaises()
        {
            listaPaises = (List<Pais>)paisService.GetAll();
            cmbPais.DataSource = listaPaises;
            cmbPais.SelectedIndex = 0;
        }

        private void cargarComboEstado()
        {
            cmbEstado.Items.Add("Habilitado");
            cmbEstado.Items.Add("Inhabilitado");
            cmbEstado.SelectedIndex = 0;
        }

        #endregion


    }
}


