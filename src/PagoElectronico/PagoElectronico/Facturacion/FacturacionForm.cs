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
        Cliente cliente;
        Usuario usuarioLogueado = Session.Usuario;

        TipoDocumentoService tipoDocumentoService = new TipoDocumentoService();
        TransaccionService transaccionService = new TransaccionService();
        FacturacionService facturacionService = new FacturacionService();
        TipoTransaccionService tipoTransaccionService = new TipoTransaccionService();

        List<TipoDocumento> listaTiposDocumentos;
        List<TipoTransaccion> listaTiposTransaccion;

        List<Transaccion> transferenciasSinFacturar;
        List<Transaccion> aperturaCuentasSinFacturar;
        List<Transaccion> modifCuentasSinFacturar;

        List<Transaccion> transaccionesSinFacturar;
        List<Transaccion> transaccionesAFacturar;

        public FacturacionForm()
        {
            InitializeComponent();
        }

        #region eventos
        /*************    Metodos de componentes       *************/

        private void FacturacionForm_Load(object sender, EventArgs e)
        {
            try
            {
                cliente = Utils.obtenerCliente(usuarioLogueado);
                cargarComboTipoDoc();
                cargarTiposTransaccion();
                cargarTransacciones();
                initializeDatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdTransacciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var row = grdTransacciones.Rows[e.RowIndex];
            if (e.ColumnIndex == 6)
            {
                if ((TiposTransaccionEnum)int.Parse(row.Cells[2].Value.ToString()) == TiposTransaccionEnum.Transferencia)
                {
                    ((DataGridViewComboBoxCell)(row.Cells[6])).ReadOnly = true;
                    ((DataGridViewComboBoxCell)(row.Cells[6])).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarItems(false);
        }

        private void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            AgregarItems(true);
        }

        private void AgregarItems(bool todos)
        {
            foreach (DataGridViewRow row in grdTransacciones.Rows)
            {
                if (todos || (row.Cells[0] != null && Convert.ToBoolean(row.Cells[0].Value)))
                {
                    var transaccion = new Transaccion
                    {
                        codigo = Convert.ToInt64(row.Cells[1].Value),
                        tipo = Convert.ToInt32(row.Cells[2].Value),
                        cuenta = Convert.ToInt64(row.Cells[3].Value),
                        costo = Convert.ToDouble(row.Cells[5].Value),
                        suscripcion = Convert.ToInt32(row.Cells[6].Value)
                    };

                    if (transaccion.suscripcion == 0 && (TiposTransaccionEnum)transaccion.tipo != TiposTransaccionEnum.Transferencia)
                    {
                        string mensaje = string.Format("Debe especificar la cantidad de suscripciones a pagar para agregar la {0} con Nro. de cuenta: {1}", transaccion.TipoDescription, transaccion.cuenta).ToString();
                        MessageBox.Show(mensaje, "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        continue;
                    }

                    transaccionesAFacturar.Add(transaccion);
                    var item = transaccionesSinFacturar.FirstOrDefault(a => a.codigo == transaccion.codigo && a.tipo == transaccion.tipo);
                    if (item != null)
                    {
                        transaccionesSinFacturar.Remove(item);
                    }
                }
            }

            grdTransacciones.DataSource = null;
            grdTransacciones.Rows.Clear();
            grdTransacciones.DataSource = transaccionesSinFacturar.OrderBy(t => t.cuenta).ToList();

            grdItemsAPagar.AutoGenerateColumns = false;
            grdItemsAPagar.DataSource = null;
            grdItemsAPagar.Rows.Clear();
            grdItemsAPagar.DataSource = transaccionesAFacturar.OrderBy(t => t.cuenta).ToList();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                if (transaccionesAFacturar.Any())
	            {
		             IList<ItemFactura> items = transaccionesAFacturar.Select(t => new ItemFactura
                            {
                                cuenta = t.cuenta,
                                descripcion = t.TipoDescription,
                                importe = t.costo,
                                numeroItem = t.codigo
                            }).ToList();

                     this.facturacionService.Facturar(items, cliente);
	            }
            }
            catch 
            {
                MessageBox.Show("Ha ocurrido un error al generar la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnLimpiarLista_Click(object sender, EventArgs e)
        {
            grdTransacciones.DataSource = null;
            grdTransacciones.Rows.Clear();

            grdItemsAPagar.DataSource = null;
            grdItemsAPagar.Rows.Clear();

            comboTipoTransaccion.SelectedIndex = 0;
            comboTipoTransaccion.Enabled = false;
            chkSeleccionarTodos.Checked = true;

            cargarTransacciones();
            initializeDatagrid();
        }

        private void comboTipoTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoTransaccion tipo = (TipoTransaccion)comboTipoTransaccion.SelectedValue;
            if (transaccionesSinFacturar != null && transaccionesSinFacturar.Any())
            {
                if (tipo.ID == (long)TiposTransaccionEnum.AperturaCuenta)
                {
                    refreshGridFiltros(transaccionesSinFacturar.Where(t => (TiposTransaccionEnum)t.tipo == TiposTransaccionEnum.AperturaCuenta).OrderBy(t => t.cuenta).ToList());
                }
                else if (tipo.ID == (long)TiposTransaccionEnum.ModifCuenta)
                {
                    refreshGridFiltros(transaccionesSinFacturar.Where(t => (TiposTransaccionEnum)t.tipo == TiposTransaccionEnum.ModifCuenta).OrderBy(t => t.cuenta).ToList());
                }
                else if (tipo.ID == (long)TiposTransaccionEnum.Transferencia)
                {
                    refreshGridFiltros(transaccionesSinFacturar.Where(t => (TiposTransaccionEnum)t.tipo == TiposTransaccionEnum.Transferencia).OrderBy(t => t.cuenta).ToList());
                }
            }
        }

        private void chkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionarTodos.Checked)
            {
                comboTipoTransaccion.Enabled = false;
                comboTipoTransaccion.SelectedIndex = 0;
                refreshGridFiltros(transaccionesSinFacturar.OrderBy(t => t.cuenta).ToList());
            }
            else
            {
                comboTipoTransaccion.Enabled = true;
                comboTipoTransaccion.SelectedIndex = 0;
                refreshGridFiltros(transaccionesSinFacturar.Where(t => (TiposTransaccionEnum)t.tipo == TiposTransaccionEnum.AperturaCuenta).OrderBy(t => t.cuenta).ToList());
            }
        }

        #endregion

        #region metodosPrivados
        /*************    Metodos privados       *************/
        private void initializeDatagrid()
        {
            transaccionesAFacturar = new List<Transaccion>();
            grdTransacciones.AutoGenerateColumns = false;
            grdTransacciones.DataSource = getAllTransaccionesSinFacturar();
        }

        private List<Transaccion> getAllTransaccionesSinFacturar()
        {
            transaccionesSinFacturar = new List<Transaccion>();
            transaccionesSinFacturar.AddRange(aperturaCuentasSinFacturar);
            transaccionesSinFacturar.AddRange(modifCuentasSinFacturar);
            transaccionesSinFacturar.AddRange(transferenciasSinFacturar);
            return transaccionesSinFacturar.OrderBy(t => t.cuenta).ToList();
        }

        private void refreshGridFiltros(List<Transaccion> listSinFacturar)
        {
            if (listSinFacturar != null)
            {
                grdTransacciones.DataSource = null;
                grdTransacciones.Rows.Clear();
                grdTransacciones.DataSource = listSinFacturar;
            }
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
            aperturaCuentasSinFacturar = (List<Transaccion>)transaccionService.getAperturaCuentasSinFacturar(cliente.tipoDocumento, cliente.numeroDocumento);
            modifCuentasSinFacturar = (List<Transaccion>)transaccionService.getModifCuentasSinFacturar(cliente.tipoDocumento, cliente.numeroDocumento);
            transferenciasSinFacturar = (List<Transaccion>)transaccionService.getTransferenciasSinFacturar(cliente.tipoDocumento, cliente.numeroDocumento);
        }

        #endregion
    }
}
