using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Services;
using PagoElectronico.Entities;
using PagoElectronico.Common;
using PagoElectronico.Tarjeta_de_Credito;
using PagoElectronico.Entities.Enums;

namespace PagoElectronico.ABM_Cliente
{
    public partial class ConsultaCliente : Form
    {
        ClienteService clienteService = new ClienteService();
        TipoDocumentoService tipoDocumentoService = new TipoDocumentoService();
        List<TipoDocumento> listaTiposDocumentos;

        public ConsultaCliente()
        {
            InitializeComponent();
        }

        #region Eventos
        /*************    Metodos de componentes       *************/

        private void ConsultaCliente_Load(object sender, EventArgs e)
        {
            cargarComboTipoDoc();
            dgvClientes.DataSource = null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtApellido.Text = String.Empty;
            this.txtNombre.Text = String.Empty;
            this.txtMail.Text = String.Empty;
            this.txtNroDoc.Text = String.Empty;

            this.txtApellido.BackColor = System.Drawing.Color.White;
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtMail.BackColor = System.Drawing.Color.White;
            this.txtNroDoc.BackColor = System.Drawing.Color.White;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            realizarBusqueda();

        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        //Handler for the event from formAltaCuenta
        void handleUpdateEvent(object sender, EventArgs e)
        {
            realizarBusqueda();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                var row = dgvClientes.Rows[e.RowIndex];
                var cellTipoDoc = row.Cells["tipoDocumento"];
                var cellNroDoc = row.Cells["numeroDocumento"];
                var formAltaCliente = new AltaCliente(Convert.ToInt64(cellTipoDoc.Value), Convert.ToInt64(cellNroDoc.Value));
                //Register the update event
                formAltaCliente.updateEvent += new EventHandler(handleUpdateEvent);
                //Register form closed event
                formAltaCliente.FormClosed += new FormClosedEventHandler(form_FormClosed);
                this.Visible = false;
                formAltaCliente.Show();
                formAltaCliente.MdiParent = this.MdiParent;
            }
            else if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Desea cambiar la habilitacion del cliente seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    var row = dgvClientes.Rows[e.RowIndex];
                    var cellTipoDoc = row.Cells["tipoDocumento"];
                    var cellNroDoc = row.Cells["numeroDocumento"];
                    try
                    {
                        if (Convert.ToBoolean(row.Cells["habilitado"].Value))
                        {
                            clienteService.inhabilitarCliente(Convert.ToInt64(cellTipoDoc.Value), Convert.ToInt64(cellNroDoc.Value));
                            MessageBox.Show("El cliente ha sido inhabilitado correctamente.", "Cliente inhabilitado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            realizarBusqueda();                                                     
                        }
                        else
                        {
                            clienteService.habilitarCliente(Convert.ToInt64(cellTipoDoc.Value), Convert.ToInt64(cellNroDoc.Value));
                            MessageBox.Show("El cliente ha sido habilitado correctamente.", "Cliente inhabilitado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            realizarBusqueda(); 
                        }                    
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al inhabilitar al cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (e.ColumnIndex == 2)
            {
                if (Session.Usuario.SelectedRol.Funcionalidades.Any(f => (FuncionalidadesEnum)f.Id == FuncionalidadesEnum.ASOCIAR_DESASOCIAR_TC))
                {
                    var row = dgvClientes.Rows[e.RowIndex];
                    var cellTipoDoc = row.Cells["tipoDocumento"];
                    var cellNroDoc = row.Cells["numeroDocumento"];
                    var formTarjetaCredito = new TarjetaCreditoForm(Convert.ToInt64(cellTipoDoc.Value), Convert.ToInt64(cellNroDoc.Value));
                    //Register the update event
                    formTarjetaCredito.updateEvent += new EventHandler(handleUpdateEvent);
                    //Register form closed event
                    formTarjetaCredito.FormClosed += new FormClosedEventHandler(form_FormClosed);
                    this.Visible = false;
                    formTarjetaCredito.Show();
                    formTarjetaCredito.MdiParent = this.MdiParent;
                }
                else
                {
                    MessageBox.Show("No tiene permisos para asociar/desasociar tarjetas de crédito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        #region MetodosPrivados
        /*************    Metodos Privados       *************/

        private void realizarBusqueda()
        {
            bool validador = true;

            long? tipoDoc = (long)cmbTipoDoc.SelectedValue <= 0 ? (long?)null : (long)cmbTipoDoc.SelectedValue;
            long? nroDoc = String.IsNullOrEmpty(txtNroDoc.Text) ? (long?)null : Int64.Parse(txtNroDoc.Text);

            if (txtNroDoc.Text.Length > 0)
            {
                validador = Validaciones.validarCampoNumericoEntero(txtNroDoc);
            }

            if (validador)
            {
                dgvClientes.AutoGenerateColumns = false;
                dgvClientes.DataSource = clienteService.getClientesByFiltros(txtApellido.Text, txtNombre.Text, txtMail.Text, tipoDoc, nroDoc);
            }
        }

        private void cargarComboTipoDoc()
        {
            listaTiposDocumentos = (List<TipoDocumento>)tipoDocumentoService.GetAll();
            cmbTipoDoc.DataSource = listaTiposDocumentos;
            cmbTipoDoc.SelectedIndex = 0;
        }

        #endregion
    }
}
