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
using PagoElectronico.Services;
using PagoElectronico.Common;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class AltaEdicion : Form
    {
        private int IdUsuario { get; set; }
        private IUsuarioService UsuarioService { get; set; }
        private IRolService RolService { get; set; }
        private Cliente cliente;
        public AltaEdicion(Cliente cliente)
        {
            
            InitializeComponent();
            if (cliente != null)
                this.cliente = cliente;
        }

        private void AltaEdicion_Load(object sender, EventArgs e)
        {
            RolService rolServ = new RolService();
            foreach (var item in rolServ.getRoles("*", true))
            {
                this.checkedListBox1.Items.Add(item);
            }
            
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validaciones.validarCampoString(this.txtUsername)
                && Validaciones.validarCampoString(this.txtPassword)
                && Validaciones.validarCampoString(this.txtPregunta)
                && Validaciones.validarCampoString(txtRespuesta))
            {
                Usuario usr = new Usuario();
                usr.Username = this.txtUsername.Text;
                usr.Password = this.txtPassword.Text;
                usr.PreguntaSecreta = this.txtPregunta.Text;
                usr.RespuestaSecreta = this.txtRespuesta.Text;
                foreach (var item in this.checkedListBox1.SelectedItems)
	                {
                        usr.Roles.Add((Rol) item);
	                }
                usr.Activo = true;
                usr.Habilitado = true;
                UsuarioService usrServ = new UsuarioService();
                
            }

        }
               
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
