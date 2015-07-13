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
using System.Transactions;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class AltaEdicion : Form
    {
        private int IdUsuario { get; set; }
        private IUsuarioService UsuarioService { get; set; }
        private IRolService RolService { get; set; }
        private Cliente cliente;
        private ClienteService cliServ;
        ABM_Cliente.Alta form;
        public AltaEdicion(Cliente cliente, ClienteService cliServ, ABM_Cliente.Alta form)
        {

            InitializeComponent();
            if (cliente != null)
            {
                this.cliente = cliente;
                this.cliServ = cliServ;
                this.form = form;
            }
        }

        private void AltaEdicion_Load(object sender, EventArgs e)
        {
            RolService rolServ = new RolService();

            ((ListBox)this.chkRoles).DataSource = rolServ.getRoles(null, true);
            ((ListBox)this.chkRoles).DisplayMember = "Nombre";
            ((ListBox)this.chkRoles).ValueMember = "Id";
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
                usr.Roles = new List<Rol>();
                foreach (var item in this.chkRoles.CheckedItems.Cast<Rol>().ToList())
                {
                    usr.Roles.Add((Rol)item);
                }
             //   usr.Roles = .Cast<Rol>().ToList();
                
                usr.Activo = true;
                usr.Habilitado = true;

                UsuarioService usrServ = new UsuarioService();

                using (var transaction = new TransactionScope())
                {
                    try
                    {
                        if (usrServ.insert(usr) > 0)
                        {
                            MessageBox.Show("Se ha creado correctamente el usuario", "Creacion usuario");
                            cliente.username = usr.Username;
                            usrServ.insertRolesUsuario(usr);
                            if (cliServ.createCliente(cliente) > 0)
                            {
                                
                                this.Hide();
                                MessageBox.Show("Se ha creado correctamente el cliente", "Creacion cliente");
                                this.form.Hide();
                            }
                            else
                                MessageBox.Show("Hubo un error en la creacion del cliente", "Error");
                        }
                        else
                            MessageBox.Show("Hubo un error en la creacion del usuario", "Error");

                        transaction.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally 
                    {
                      
                        transaction.Dispose();
                    }
                }
            }
        }
    }
}
