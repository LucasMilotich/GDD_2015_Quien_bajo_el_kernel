﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Services;
using PagoElectronico.Entities;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class ConsultaCuenta : Form
    {
        CuentaService cuentaService { get; set; }
        PaisService paisService { get; set; }
        TipoMonedaService tipoMonedaService { get; set; }
        TipoEstadoCuentaService tipoEstadoService { get; set; }
        Usuario usuario = Session.Usuario;

        public ConsultaCuenta()
        {
            cuentaService = new CuentaService();
            paisService = new PaisService();
            tipoMonedaService = new TipoMonedaService();
            tipoEstadoService = new TipoEstadoCuentaService();
            InitializeComponent();
        }


        private void cargarCampos()
        {
            var monedas = new List<TipoMoneda>();
            monedas.Add(new TipoMoneda { codigo = 0, descripcion = "Seleccionar" });
            monedas.AddRange(tipoMonedaService.GetAll());

            var tiposCuenta = new List<TipoCuenta>();
            tiposCuenta.Add(new TipoCuenta { codigo = 0, descripcion = "Seleccionar" });
            tiposCuenta.AddRange(cuentaService.GetTiposCuenta());

            var tiposEstado = new List<TipoEstadoCuenta>();
            tiposEstado.Add(new TipoEstadoCuenta { codigo = 0, descripcion = "Seleccionar" });
            tiposEstado.AddRange(tipoEstadoService.GetAll());

            var paises = new List<Pais>();
            paises.Add(new Pais { codigoPais = 0, descripcionPais = "Seleccione un país" });
            paises.AddRange(paisService.GetAll());

            cmbMoneda.DataSource = monedas;
            cmbTipoCuenta.DataSource = tiposCuenta;
            cmbEstado.DataSource = tiposEstado;
            cmbPaises.DataSource = paises;

        }

        private void ConsultaCuenta_Load(object sender, EventArgs e)
        {
            cargarCampos();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int? moneda = (int)cmbMoneda.SelectedValue <= 0 ? (int?)null : (int)cmbMoneda.SelectedValue;
            long? pais = (long)cmbPaises.SelectedValue <= 0 ? (long?)null : (long)cmbPaises.SelectedValue;
            int? estado = (int)cmbEstado.SelectedValue <= 0 ? (int?)null : (int)cmbEstado.SelectedValue;
            int? tipoCuenta = (int)cmbTipoCuenta.SelectedValue <= 0 ? (int?)null : (int)cmbTipoCuenta.SelectedValue;

            dgvCuentas.AutoGenerateColumns = false;
            dgvCuentas.DataSource = cuentaService.GetCuentas(pais, estado, moneda, tipoCuenta);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbMoneda.SelectedValue = 0;
            cmbPaises.SelectedValue = (long)(0);
            cmbTipoCuenta.SelectedValue = 0;
            cmbEstado.SelectedValue = 0;
        }

        private void dgvCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var row = dgvCuentas.Rows[e.RowIndex];
                var cell = row.Cells["Numero"];
                var form = new AltaCuenta(Convert.ToInt64(cell.Value));
                form.Show();
                form.MdiParent = this.MdiParent;
            }
        }
    }
}
