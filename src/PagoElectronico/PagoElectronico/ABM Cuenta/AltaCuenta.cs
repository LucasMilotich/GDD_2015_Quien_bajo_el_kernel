using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Services.Interfaces;
using PagoElectronico.Services;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class AltaCuenta : Form
    {
        CuentaService cuentaService { get; set; }
        PaisService paisService { get; set; }
        TipoMonedaService tipoMonedaService { get; set; }


        public AltaCuenta()
        {
            cuentaService = new CuentaService();
            paisService = new PaisService();
            tipoMonedaService = new TipoMonedaService();
            InitializeComponent();
        }

        private void AltaCuenta_Load(object sender, EventArgs e)
        {
            cargarCampos();
        }

        private void cargarCampos() 
        {
            var paises = paisService.GetAll();
            var monedas = tipoMonedaService.GetAll();
            var tiposCuenta = cuentaService.GetTiposCuenta();
            var nroCuenta = cuentaService.GetMaxNroCuenta();

            txtCuenta.Text = nroCuenta.ToString();
            cmbPaises.DataSource = paises;
            cmbMonedas.DataSource = monedas;
            cmbTiposCuenta.DataSource = tiposCuenta;

        }

    }
}
