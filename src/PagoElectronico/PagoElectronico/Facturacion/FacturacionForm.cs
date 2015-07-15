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

        List<Transaccion> transferenciasSinFacturar;
        List<Transaccion> aperturaCuentasSinFacturar;
        List<Transaccion> modifCuentasSinFacturar;

        List<Transaccion> elementosFiltrados;
        List<Transaccion> elementosAfacturar;
        BindingSource sourceDgridFiltro;
        BindingSource sourceDgridFacturable;

        public FacturacionForm()
        {
            InitializeComponent();
        }

        #region eventos
        /*************    Metodos de componentes       *************/
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            //Boolean validator;
            //validator = Validaciones.validarCampoVacio(txtNombre) & Validaciones.validarCampoVacio(txtApellido) & Validaciones.validarCampoVacio(txtNroDoc);
            //validator = validator & Validaciones.validarCampoString(txtApellido) & Validaciones.validarCampoString(txtNombre) & Validaciones.validarCampoNumericoEntero(txtNroDoc);

            //if (validator)
            //{
            //    realizarFacturacion();
            //}

            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in grdTransacciones.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    rows_with_checked_column.Add(row);
                }
            }

        }

        private void btnLimpiarLista_Click(object sender, EventArgs e)
        {
            limpiarGridFactur();
        }


        //private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex == -1)
        //    {
        //        return;
        //    }

        //    Transaccion obj = elementosFiltrados[e.RowIndex];
        //    elementosAfacturar.Add(obj);
        //    elementosFiltrados.Remove(obj);

        //    sourceDgridFacturable.ResetBindings(false);
        //    sourceDgridFiltro.ResetBindings(false);
        //}

        private void dgridFacurable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            Transaccion obj = elementosAfacturar[e.RowIndex];
            elementosFiltrados.Add(obj);
            elementosAfacturar.Remove(obj);

            sourceDgridFiltro.ResetBindings(false);
            sourceDgridFacturable.ResetBindings(false);
        }


        private void comboTipoTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoTransaccion tipo = (TipoTransaccion)comboTipoTransaccion.SelectedValue;
            if (tipo.ID == (long)TiposTransaccionEnum.AperturaCuenta)
            {
                refreshGridFiltros(aperturaCuentasSinFacturar);
            }
            else if (tipo.ID == (long)TiposTransaccionEnum.ModifCuenta)
            {
                refreshGridFiltros(modifCuentasSinFacturar);
            }
            else if (tipo.ID == (long)TiposTransaccionEnum.Transferencia)
            {
                refreshGridFiltros(transferenciasSinFacturar);
            }

        }

        private void chkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionarTodos.Checked)
            {
                comboTipoTransaccion.Enabled = false;
                refreshGridFiltros(getAllTransaccionesSinFacturar());
            }
            else
            {
                comboTipoTransaccion.Enabled = true;
                comboTipoTransaccion.SelectedIndex = 0;
                refreshGridFiltros(aperturaCuentasSinFacturar);
            }
        }
        

        #endregion

        #region metodosPrivados
        /*************    Metodos privados       *************/
        private void initializeDatagrids()
        {
            //sourceDgridFiltro = new BindingSource();
            //sourceDgridFacturable = new BindingSource();
            //elementosFiltrados = new List<Transaccion>();
            //elementosAfacturar = new List<Transaccion>();

            //sourceDgridFiltro.DataSource = elementosFiltrados;
            //sourceDgridFacturable.DataSource = elementosAfacturar;

            //grdTransacciones.DataSource = sourceDgridFiltro;
            //dgridFacturable.DataSource = sourceDgridFacturable;

            //grdTransacciones.ReadOnly = true;
            //grdTransacciones.MultiSelect = false;
            //dgridFacturable.ReadOnly = true;
            //dgridFacturable.MultiSelect = false;

            //refreshGridFiltros(getAllTransaccionesSinFacturar());

            grdTransacciones.DataSource = getAllTransaccionesSinFacturar();

        }

        private void realizarFacturacion()
        {
            throw new NotImplementedException();
        }


        private List<Transaccion> getAllTransaccionesSinFacturar()
        {
            List<Transaccion> todosSinFacturar = new List<Transaccion>();

            todosSinFacturar.AddRange(aperturaCuentasSinFacturar);
            todosSinFacturar.AddRange(modifCuentasSinFacturar);
            todosSinFacturar.AddRange(transferenciasSinFacturar);
            return todosSinFacturar;
        }

        private void refreshGridFiltros(List<Transaccion> listSinFacturar)
        {
            if (listSinFacturar != null)
            {
                elementosFiltrados = listSinFacturar;
                sourceDgridFiltro.ResetBindings(false);
            }
        }

        private void limpiarGridFactur()
        {
            elementosAfacturar.Clear();
            sourceDgridFacturable.ResetBindings(false);
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

   
        #endregion

        private void FacturacionForm_Load(object sender, EventArgs e)
        {
            try
            {
                clienteLogueado = Utils.obtenerCliente(usuarioLogueado);
                cargarComboTipoDoc();
                cargarTiposTransaccion();
                cargarTransacciones();
                initializeDatagrids();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
        }
    }
}
