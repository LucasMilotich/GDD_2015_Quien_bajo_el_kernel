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

        private Cliente cliente;
        private ClienteService cliService = new ClienteService();
        private UsuarioService usrService = new UsuarioService();
        ABM_Cliente.AltaCliente form;



        public AltaEdicion(Cliente cliente, ABM_Cliente.AltaCliente form)
        {
            InitializeComponent();
            if (cliente != null)
            {
                this.cliente = cliente;
                this.form = form;
            }
        }

        #region Eventos
        /*************    Metodos de componentes       *************/

        private void AltaEdicion_Load(object sender, EventArgs e)
        {
            RolService rolServ = new RolService();

            ((ListBox)this.chkRoles).DataSource = rolServ.getRoles(null, true);
            ((ListBox)this.chkRoles).DisplayMember = "Nombre";
            ((ListBox)this.chkRoles).ValueMember = "Id";
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarUsuario();
        }

        #endregion

        #region MetodosPrivados
        /*************    Metodos privados       *************/
        
        private void realizarTransaccion(Usuario usr, Cliente cliente)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (usrService.insert(usr) > 0)
                        MessageBox.Show("Se ha creado correctamente el usuario", "Creacion usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        throw new Exception("Error al crear usuario");

                    cliente.username = usr.Username;
                    usrService.insertRolesUsuario(usr);

                    if (cliService.createCliente(cliente) > 0)
                    {
                        this.Hide();
                        MessageBox.Show("Se ha creado correctamente el cliente", "Creacion cliente");
                        this.form.Hide();
                    }
                    else
                        throw new Exception("Error al crear usuario");

                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {

                    transaction.Dispose();
                }
            }
        }

        private void validarUsernameUnico()
        {
            if (usrService.existeUsername(txtUsername.Text))
            {
                throw new Exception("El usuario ingresado ya existe.");
            }
        }
        
        private void guardarUsuario()
        {
            if (Validaciones.validarCampoAlfaNumerico(this.txtUsername)
                & Validaciones.validarCampoVacio(this.txtPassword)
                & Validaciones.validarCampoString(this.txtPregunta)
                & Validaciones.validarCampoString(this.txtRespuesta))
            {
                try
                {
                    validarUsernameUnico();

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

                    usr.Activo = true;
                    usr.Habilitado = true;

                    realizarTransaccion(usr, cliente);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }


        #endregion

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsername.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtPregunta.Text = String.Empty;
            txtRespuesta.Text = String.Empty;

            txtUsername.BackColor = System.Drawing.Color.White;
            txtPassword.BackColor = System.Drawing.Color.White;
            txtPregunta.BackColor = System.Drawing.Color.White;
            txtRespuesta.BackColor = System.Drawing.Color.White;

        }




    }
}
