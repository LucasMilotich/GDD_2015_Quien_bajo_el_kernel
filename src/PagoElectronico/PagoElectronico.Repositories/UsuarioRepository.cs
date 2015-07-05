using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace PagoElectronico.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public override IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Usuario Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Usuario GetByUsernameAndPassword(string username, byte[] password)
        {
            RolRepository rolRepository = new RolRepository();
            Usuario usuario = null;
            bool loginSuccess = false;

            SqlCommand command = DBConnection.CreateStoredProcedure("GetUsuarioByUsernameAndPassword");
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow row in collection)
            {
                usuario = this.CreateUsuario(row);
                usuario.Roles = rolRepository.GetRolesByUsername(username);
                loginSuccess = true;

                command = DBConnection.CreateStoredProcedure("DeleteUsuarioLog");
                command.Parameters.AddWithValue("@username", username);
                DBConnection.ExecuteNonQuery(command);

            }

            command = DBConnection.CreateStoredProcedure("InsertUsuarioLog");
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@login_correcto", loginSuccess);
            DBConnection.ExecuteNonQuery(command);

            return usuario;
        }

        private Usuario CreateUsuario(DataRow reader)
        {
            Usuario usuario = new Usuario();
            usuario.Username = reader["username"].ToString();
            usuario.Activo = Convert.ToBoolean(reader["activo"]);
            usuario.PreguntaSecreta = reader["pregunta_secreta"].ToString();
            usuario.RespuestaSecreta = reader["respuesta_secreta"].ToString();

            return usuario;
        }
    }
}
