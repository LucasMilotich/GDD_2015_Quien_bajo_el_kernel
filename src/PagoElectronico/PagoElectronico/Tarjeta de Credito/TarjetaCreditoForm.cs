using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Common;
using PagoElectronico.Services;
using PagoElectronico.Entities;

namespace PagoElectronico.Tarjeta_de_Credito
{
    public partial class TarjetaCreditoForm : Form
    {
        //Declare your event
        public event EventHandler updateEvent;

        TarjetaService tarjetaService = new TarjetaService();
        ClienteService cliServ = new ClienteService();
        EmisorTarjetaService emisorTarjService = new EmisorTarjetaService();
        List<EmisorTarjeta> listaEmisoresTarjeta;

        Cliente clienteTarjeta;
        Boolean actualizarTarjeta = false;

        public TarjetaCreditoForm(long tipoDoc, long nroDoc)
        {
            InitializeComponent();
            clienteTarjeta = cliServ.getClienteByDNI(tipoDoc, nroDoc);
        }

        #region Eventos
        /*************    Metodos de componentes       *************/

        private void TarjetaCreditoForm_Load(object sender, EventArgs e)
        {
            setearCliente();
            cargarComboEmisores();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            realizarBusqueda();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            updateEvent(sender, e);
            this.Close();
        }

        private void btnHabilitarNuevaTarjeta_Click(object sender, EventArgs e)
        {
            groupBoxAsociarNuevaTarjeta.Visible = true;
        }

        private void btnAsociarTarjeta_Click(object sender, EventArgs e)
        {
            Boolean validador = Validaciones.validarCampoNumericoEntero(txtNumeroTarjeta) &
                                Validaciones.validarCampoNumericoEntero(txtCodSeguridad);
            if (validador)
            {
                try
                {
                    validarLengthCampos();
                    validarFechasEmisionVencimiento();
                    validarNumeroTarjetaDisponible();
                    Tarjeta tarjeta = new Tarjeta();
                    tarjeta.tarjetaNumero = txtNumeroTarjeta.Text;
                    tarjeta.fechaEmision = dtpFechaEmision.Value;
                    tarjeta.fechaVencimiento = dtpFechaVencimiento.Value;
                    tarjeta.codigoSeguridad = txtCodSeguridad.Text;
                    tarjeta.codEmisor = ((EmisorTarjeta)cmbEmisor.SelectedItem).ID;
                    tarjeta.tipoDoc = (long)cmbTipoDoc.SelectedItem;
                    tarjeta.nroDoc = Int64.Parse(txtNroDoc.Text);
                    if (actualizarTarjeta)
                    {
                        tarjetaService.updateTarjeta(tarjeta);
                        MessageBox.Show("Tarjeta re-asociada correctamente.", "Asociacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        actualizarTarjeta = false;
                    }
                    else
                    {
                        tarjetaService.insertarTarjeta(tarjeta);
                        MessageBox.Show("Tarjeta asociada correctamente.", "Asociacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    limpiarDatos();
                    realizarBusqueda();
                    groupBoxAsociarNuevaTarjeta.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al desasociar la tarjeta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dgvTarjetas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    if (MessageBox.Show("Desea desasociar la tarjeta seleccionada?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        var row = dgvTarjetas.Rows[e.RowIndex];
                        long tarjetaNumero = Convert.ToInt64(row.Cells["tarjetaNumero"].Value);
                        tarjetaService.desasociarTarjeta(tarjetaNumero);
                        MessageBox.Show("La desasociacion fue realizada correctamente.", "Desasociacion correcta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        realizarBusqueda();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al desasociar la tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        #endregion

        #region MetodosPrivados
        /*************    Metodos privados       *************/

        private void realizarBusqueda()
        {
            bool validador = true;

            long? tipoDoc = (long)cmbTipoDoc.SelectedItem <= 0 ? (long?)null : (long)cmbTipoDoc.SelectedItem;
            long? nroDoc = String.IsNullOrEmpty(txtNroDoc.Text) ? (long?)null : Int64.Parse(txtNroDoc.Text);

            if (txtNroDoc.Text.Length > 0)
            {
                validador = Validaciones.validarCampoNumericoEntero(txtNroDoc);
            }

            if (validador)
            {
                dgvTarjetas.AutoGenerateColumns = false;
                dgvTarjetas.DataSource = tarjetaService.getAllByCliente(clienteTarjeta.tipoDocumento, clienteTarjeta.numeroDocumento);
            }
        }

        private void setearCliente()
        {
            txtNroDoc.Text = clienteTarjeta.numeroDocumento.ToString();
            cmbTipoDoc.Items.Add(clienteTarjeta.tipoDocumento);
            cmbTipoDoc.SelectedIndex = 0;
        }

        private void limpiarDatos()
        {
            txtNumeroTarjeta.Text = String.Empty;
            txtCodSeguridad.Text = String.Empty;
            cmbEmisor.SelectedIndex = 0;

            txtNumeroTarjeta.BackColor = System.Drawing.Color.White;
            txtCodSeguridad.BackColor = System.Drawing.Color.White;
        }

        private void cargarComboEmisores()
        {
            listaEmisoresTarjeta = (List<EmisorTarjeta>)emisorTarjService.GetAll();
            cmbEmisor.DataSource = listaEmisoresTarjeta;
            cmbEmisor.SelectedIndex = 0;
        }

        #endregion


        #region ValidacionesPrivadas
        /*************    Validaciones privadas       *************/

        private void validarFechasEmisionVencimiento()
        {
            if (dtpFechaEmision.Value >= dtpFechaVencimiento.Value)
            {
                throw new Exception("La fecha de emision debe ser anterior a la de vencimiento");
            }

        }

        private void validarLengthCampos()
        {
            if (txtNumeroTarjeta.Text.Length != 16)
            {
                throw new Exception("El numero de tarjeta debe ser de longitud 16");
            }
            if (txtCodSeguridad.Text.Length != 3)
            {
                throw new Exception("El numero de tarjeta debe ser de longitud 3");
            }

        }

        private void validarNumeroTarjetaDisponible()
        {
            if (!tarjetaService.NumeroTarjetaDisponible(txtNumeroTarjeta.Text))
            {
                if (!tarjetaService.NumeroTarjetaFueDesasociada(txtNumeroTarjeta.Text, Convert.ToInt64(cmbTipoDoc.SelectedItem), Convert.ToInt64(txtNroDoc.Text)))
                {
                    throw new Exception("El numero de tarjeta ingresado pertenece a otra tarjeta del sistema");
                }
                else
                {
                    actualizarTarjeta = true;
                }

            }
        }
        
        #endregion

    }
}
