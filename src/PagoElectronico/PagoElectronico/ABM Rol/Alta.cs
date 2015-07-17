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
        public int id_rol;
        Rol rol; 
        public Alta(int id)
        {
            InitializeComponent();
            IRolService rolserv = new RolService();
            var funciones = rolserv.Getfunciones();
            ((ListBox)chkLFuncionalidades).DataSource = funciones;
            ((ListBox)chkLFuncionalidades).DisplayMember = "Nombre";
            ((ListBox)chkLFuncionalidades).ValueMember = "Id";
            this.id_rol = id;



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            RolService rolServv = new RolService();
            if (this.id_rol > 0)
            {
                this.rol.Nombre = this.txtNombre.Text;
                this.rol.Activo = this.chkActivo.Checked;
               this.rol.Funcionalidades = new List<Funcionalidad>();
                foreach (var item in chkLFuncionalidades.CheckedItems)
                {

                   this.rol.Funcionalidades.Add((Funcionalidad)item);
                }
               if( rolServv.modificarRol(this.rol)>0 )
                   MessageBox.Show("Se modifico correctamente", "OK");
               else MessageBox.Show("NO se modifico correctamente", "ERROR");
            }

            else
            {
               
                Rol rol = new Rol();
                rol.Nombre = txtNombre.Text;
                rol.Activo = chkActivo.Checked;
                rol.Funcionalidades = new List<Funcionalidad>();
                foreach (var item in chkLFuncionalidades.CheckedItems)
                {

                    rol.Funcionalidades.Add((Funcionalidad)item);
                }
                if (rolServv.crearRol(rol) != 0)
                    MessageBox.Show("Se creeo correctamente", "OK");
                else MessageBox.Show("NO se creeo correctamente", "ERROR");

            }

        }

        private void CreacionRolForm_Load(object sender, EventArgs e)
        {
            FuncionalidadService funcService = new FuncionalidadService();
            if (this.id_rol > 0)
            {
                RolService rolser = new RolService();
                Rol rol = rolser.getRolByID(id_rol);
                this.txtNombre.Text = rol.Nombre;
                this.chkActivo.Checked = rol.Activo;
                this.Text = "Modificar rol";
                rol.Funcionalidades = funcService.GetByRolId(rol.Id).ToList();

                for (int i = 0; i < chkLFuncionalidades.Items.Count; i++)
                {
                    var func = (Funcionalidad)chkLFuncionalidades.Items[i];
                    var isChecked = rol.Funcionalidades.Any(f => f.Id == func.Id);
                    chkLFuncionalidades.SetItemChecked(i, isChecked);
                }

                this.rol = rol;
            }
        }

        private void chkLFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
