using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Services;
using PagoElectronico.Entities;
using PagoElectronico.Services.Interfaces;

namespace PagoElectronico.ABM_Rol
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
            IRolService rolserv = new RolService();
            var funciones = rolserv.Getfunciones();
            ((ListBox)chkLFuncionalidades).DataSource = funciones;
            ((ListBox)chkLFuncionalidades).DisplayMember = "Nombre";
            ((ListBox)chkLFuncionalidades).ValueMember = "Id";
        
          
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            IRolService rolServv = new RolService();
            Rol rol = new Rol();
            rol.Nombre = txtNombre.Text;
            rol.Activo = chkActivo.Checked;
            rol.Funcionalidades = new List<Funcionalidad>();
            foreach (var item in chkLFuncionalidades.CheckedItems)
            {
                
                rol.Funcionalidades.Add((Funcionalidad)item);
            }
            if (rolServv.crearRol(rol) !=0)
                MessageBox.Show("Se creeo correctamente","OK");
            else MessageBox.Show("NO se creeo correctamente", "ERROR");

                

        }

        private void CreacionRolForm_Load(object sender, EventArgs e)
        {

        }

        private void chkLFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
