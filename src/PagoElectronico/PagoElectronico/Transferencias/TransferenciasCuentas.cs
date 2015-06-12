using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Common;
using System.Data.SqlClient;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;
using PagoElectronico.Services;

namespace PagoElectronico.Transferencias
{
    public partial class TransferenciasCuentas : Form
    {
        TransferenciaService transferenciaService = new TransferenciaService();

        public TransferenciasCuentas()
        {
            InitializeComponent();
            cargarComboCuentas();
            cargarComboTipoMoneda();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCuentaDestino.BackColor = System.Drawing.Color.White;
            txtImporte.BackColor = System.Drawing.Color.White;
            txtCuentaDestino.Text = String.Empty;
            txtImporte.Text = String.Empty;
            comboCuentaOrigen.SelectedIndex = 0;
        }

        private void cargarComboCuentas()
        {
            //TODO: select from cuentas where usuario..
            comboCuentaOrigen.Items.Add("");

        }

        private void cargarComboTipoMoneda()
        {
            comboTipoMoneda.Items.Add("$");
            comboTipoMoneda.Items.Add("U$S");
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            //  Validaciones.validarCampoNumericoDouble(txtImporte);
            //  Validaciones.validarCampoVacio(txtImporte);

            //**Las cuentas cerradas o pendientes de activacion no pueden recibir dinero
            //**Está permitido que las trasferencias puedan ser entre cuentas de distinto países.
            //**Las operaciones realizadas son con fecha del día y debe generarse un número de operación independiente de los depósitos y retiros.
            //
            //**Una característica importante de las transferencias es que las mismas tienen un costo fijo
            //que se cobra a la cuenta origen, dicho costo fijo dependerá del tipo de cuenta, pero si cuenta
            //origen y destino son del mismo usuario, estas transferencias no tienen costo.

            Transferencia transferencia = new Transferencia();
            //transferencia.origen = Convert.ToInt64(comboCuentaOrigen.Text);
            transferencia.origen = 50;
            transferencia.destino = Convert.ToInt64(txtCuentaDestino.Text);
            transferencia.fecha = DateTime.Now;
            transferencia.importe = Convert.ToInt64(txtImporte.Text);
            transferencia.costo = 0;
            transferencia.monedaTipo = 3;
            transferencia.idTransaccion = 1;
            
            transferenciaService.Save(transferencia);

            MessageBox.Show("Transferencia realizada exitosamente. Saldo actual: unNro", "Atencion !", MessageBoxButtons.OK, MessageBoxIcon.Information);
           


        }

        private void TransferenciasCuentas_Load(object sender, EventArgs e)
        {

        }

 


    }
}
