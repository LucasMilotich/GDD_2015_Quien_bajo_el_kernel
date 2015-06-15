using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Consulta_Saldos;
using PagoElectronico.Listados;
using PagoElectronico.Transferencias;
using PagoElectronico.ABM_Rol;
using PagoElectronico.Entities;
using PagoElectronico.ABM_Cuenta;

namespace PagoElectronico
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Está seguro que desea salir?", "Pago Electrónico",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information) == DialogResult.OK)
                    Environment.Exit(1);
                else
                    e.Cancel = true; // to don't close form is user change his mind
            }
        }

        private void consultarSaldoDeCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new ConsultaSaldos());
        }

        private void listadoEstadisticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new ListadoEstadistico());
        }


        private void transferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new TransferenciasCuentas());
        }

        private void crearNuevoRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new Alta());
        }

        private void showForm(Form unForm)
        {
            this.Cursor = Cursors.WaitCursor;
            unForm.Location = this.Location;
            unForm.StartPosition = FormStartPosition.CenterScreen;
            unForm.MdiParent = this;
            unForm.Show();
            this.Cursor = Cursors.Default;
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.Usuario = null;
            var form = new Login.Login();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Hide();
        }

        private void buscarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rolBusquedaForm = new ConsultaRol();
            rolBusquedaForm.MdiParent = this;
            showForm(rolBusquedaForm);

        }

        private void altaDeCuenta_Click(object sender, EventArgs e)
        {
            showForm(new AltaCuenta());
        }
        private void modificarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rolModificacionForm = new Modificacion();
            rolModificacionForm.MdiParent = this;
            showForm(rolModificacionForm);

        }
    }
}