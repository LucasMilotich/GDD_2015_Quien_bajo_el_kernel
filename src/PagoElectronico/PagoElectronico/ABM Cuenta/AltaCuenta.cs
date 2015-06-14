using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Services.Interfaces;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class AltaCuenta : Form
    {
        public AltaCuenta()
        {
            InitializeComponent();
        }

        private void AltaCuenta_Load(object sender, EventArgs e)
        {
            cargarCampos();
        }

        private void cargarCampos() 
        {
            //IRolService rolServ = new IRolService();


        }

    }
}
