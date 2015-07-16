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

        private void ConsultaCliente_Load(object sender, EventArgs e)
        {
            cargarComboTipoDoc();
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

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 0)
            {
                var row = dgvClientes.Rows[e.RowIndex];
                var cell = row.Cells["Numero"];
                var form = new AltaCuenta(Convert.ToInt64(cell.Value));
                form.Show();
                form.MdiParent = this.MdiParent;
            }
            else if (e.ColumnIndex == 1)
            {/*

                if (MessageBox.Show("Desea cerrar la cuenta seleccionada? La misma no podrá volver a activarse", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    var row = dgvCuentas.Rows[e.RowIndex];
                    var cell = row.Cells["Numero"];
                    try
                    {
                        int resp = cuentaService.CerrarCuenta(Convert.ToInt64(cell.Value));
                        if (resp == -1)
                        {
                            MessageBox.Show("La cuenta no se podrá cerrar mientras haya transacciones pendientes de pago", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("Cuenta cerrada!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (OperationCanceledException ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al cerrar la cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }*/
        }





    }
}
