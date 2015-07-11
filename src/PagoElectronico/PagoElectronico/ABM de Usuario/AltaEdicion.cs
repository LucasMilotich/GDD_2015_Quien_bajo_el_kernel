using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Entities;
using PagoElectronico.Services.Interfaces;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class AltaEdicion : Form
    {
        private int IdUsuario { get; set; }
        private IUsuarioService UsuarioService { get; set; }
        private IRolService RolService { get; set; }

        public AltaEdicion()
        {
            InitializeComponent();
        }

        private void AltaEdicion_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario
            {
                Username = txtUsername.Text
            };
        }
    }
}
