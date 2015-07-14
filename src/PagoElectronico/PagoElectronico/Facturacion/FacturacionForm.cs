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
using PagoElectronico.Entities.Enums;

namespace PagoElectronico.Facturacion
{
    public partial class FacturacionForm : Form
    {
        Cliente clienteLogueado;
        Usuario usuarioLogueado = Session.Usuario;

        TipoDocumentoService tipoDocumentoService = new TipoDocumentoService();
        TransaccionService transaccionService = new TransaccionService();
        TipoTransaccionService tipoTransaccionService = new TipoTransaccionService();

        List<TipoDocumento> listaTiposDocumentos;
        List<TipoTransaccion> listaTiposTransaccion;

        List<Transaccion> todosSinFacturar = new List<Transaccion>();
        List<Transaccion> transferenciasSinFacturar;
        List<Transaccion> aperturaCuentasSinFacturar;
        List<Transaccion> modifCuentasSinFacturar;

        List<Transaccion> elementosSeleccionados = new List<Transaccion>();
        List<Transaccion> elementosAfacturar = new List<Transaccion>();


        public FacturacionForm()
        {
            try
            {
                InitializeComponent();
                clienteLogueado = Utils.obtenerCliente(usuarioLogueado);
                cargarComboTipoDoc();
                cargarTiposTransaccion();
                cargarTransacciones();
                refreshTodosSinFacturar();
                refreshDataGridWith(todosSinFacturar);

                dataGridView1.ReadOnly = true;
                dgridFacurable.ReadOnly = true;
                //  dataGridView1.DataSource = elementosSeleccionados;
                //  dataGridView2.DataSource = elementosAfacturar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region eventos
        /*************    Metodos de componentes       *************/
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Boolean validator;
            validator = Validaciones.validarCampoVacio(txtNombre) & Validaciones.validarCampoVacio(txtApellido) & Validaciones.validarCampoVacio(txtNroDoc);
            validator = validator & Validaciones.validarCampoString(txtApellido) & Validaciones.validarCampoString(txtNombre) & Validaciones.validarCampoNumericoEntero(txtNroDoc);

            if (validator)
            {
                realizarFacturacion();
            }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgridFacurable.DataSource = elementosAfacturar;
            dataGridView1.DataSource = elementosSeleccionados;
            dgridFacurable.Refresh();
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = null;
            // dgridFacurable.DataSource = null;
            Transaccion obj = elementosSeleccionados[e.RowIndex];
            elementosAfacturar.Add(obj);
            elementosSeleccionados.Remove(obj);
            refreshDataGridWith(elementosSeleccionados);

        }


        private void dgridFacurable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgridFacurable.DataSource = null;
            Transaccion obj = elementosAfacturar[e.RowIndex];
            elementosSeleccionados.Add(obj);
            elementosAfacturar.Remove(obj);            
        }


        #endregion

        #region metodosPrivados
        /*************    Metodos privados       *************/
        private void realizarFacturacion()
        {
            throw new NotImplementedException();
        }

        private void cargarComboTipoDoc()
        {
            listaTiposDocumentos = (List<TipoDocumento>)tipoDocumentoService.GetAll();
            comboTipoDoc.DataSource = listaTiposDocumentos;
            comboTipoDoc.SelectedIndex = 0;
        }

        private void cargarTiposTransaccion()
        {
            listaTiposTransaccion = (List<TipoTransaccion>)tipoTransaccionService.GetAll();
            comboTipoTransaccion.DataSource = listaTiposTransaccion;
            comboTipoTransaccion.SelectedIndex = 0;
        }

        private void cargarTransacciones()
        {
            aperturaCuentasSinFacturar = (List<Transaccion>)transaccionService.getAperturaCuentasSinFacturar(clienteLogueado.tipoDocumento, clienteLogueado.numeroDocumento);
            modifCuentasSinFacturar = (List<Transaccion>)transaccionService.getModifCuentasSinFacturar(clienteLogueado.tipoDocumento, clienteLogueado.numeroDocumento);
            transferenciasSinFacturar = (List<Transaccion>)transaccionService.getTransferenciasSinFacturar(clienteLogueado.tipoDocumento, clienteLogueado.numeroDocumento);
        }


        private void comboTipoTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoTransaccion tipo = (TipoTransaccion)comboTipoTransaccion.SelectedValue;
            if (tipo.ID == (long)TiposTransaccionEnum.AperturaCuenta)
            {
                refreshDataGridWith(aperturaCuentasSinFacturar);
            }
            else if (tipo.ID == (long)TiposTransaccionEnum.ModifCuenta)
            {
                refreshDataGridWith(modifCuentasSinFacturar);
            }
            else if (tipo.ID == (long)TiposTransaccionEnum.Transferencia)
            {
                refreshDataGridWith(transferenciasSinFacturar);
            }

        }

        private void chkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionarTodos.Checked)
            {
                comboTipoTransaccion.Enabled = false;

                if (todosSinFacturar.Count > 0)
                {
                    todosSinFacturar.Clear();
                }
                refreshTodosSinFacturar();
                refreshDataGridWith(todosSinFacturar);

            }
            else
            {
                comboTipoTransaccion.Enabled = true;
                comboTipoTransaccion.SelectedIndex = 0;
                refreshDataGridWith(aperturaCuentasSinFacturar);
            }
        }


        #endregion

        private void refreshTodosSinFacturar()
        {
            todosSinFacturar.AddRange(aperturaCuentasSinFacturar);
            todosSinFacturar.AddRange(modifCuentasSinFacturar);
            todosSinFacturar.AddRange(transferenciasSinFacturar);
        }

        private void refreshDataGridWith(List<Transaccion> listSinFacturar)
        {
            elementosSeleccionados = listSinFacturar;

            dataGridView1.DataSource = elementosSeleccionados;
            //     dgridFacurable.DataSource = elementosAfacturar;
        }



    }
}
