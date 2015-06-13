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
            return this.GetAll(null, null, null, null, null, null, null, null, null, null);
        }

        public override Usuario Get(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public override int Insert(Usuario entity)
        {
            int id;
            using (var transaction = new TransactionScope())
            {
                SqlCommand command = DBConnection.CreateStoredProcedure("InsertUsuario");
                InsertUsuarioParameters(entity, command);
                id = DBConnection.ExecuteScalar(command);

                //foreach (Hotel hotel in entity.Hoteles)
                //{
                //    command = DBConnection.CreateStoredProcedure("InsertUsuarioHotel");
                //    AddUsuarioHotelesParameters(id, hotel, command);
                //    DBConnection.ExecuteNonQuery(command);
                //}

                transaction.Complete();
            }

            return id;
        }

        public override void Update(Usuario entity)
        {
            using (var transaction = new TransactionScope())
            {
                SqlCommand command = DBConnection.CreateStoredProcedure("UpdateUsuario");
                UpdateUsuarioParameters(entity, command);
                DBConnection.ExecuteNonQuery(command);

                //foreach (Hotel hotel in entity.Hoteles)
                //{
                //    command = DBConnection.CreateStoredProcedure("InsertUsuarioHotel");
                //    AddUsuarioHotelesParameters(entity.Id, hotel, command);
                //    DBConnection.ExecuteNonQuery(command);
                //}

                transaction.Complete();
            }
        }

        public override void Delete(Usuario entity)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("DeleteUsuario");
            command.Parameters.AddWithValue("@username", entity.Username);
            DBConnection.ExecuteNonQuery(command);
        }

        public IEnumerable<Usuario> GetAll(string username, string nombre, string apellido, int? tipoDocumentoId, string numeroDocumento, string mail, string telefono, string direccion, DateTime? fechaNacimiento, int? rolId)
        {
            List<Usuario> usuarios = new List<Usuario>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetUsuarios");
            GetUsuariosParameters(username, nombre, apellido, tipoDocumentoId, numeroDocumento, mail, telefono, direccion, fechaNacimiento, rolId, command);
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow usuario in collection)
            {
                Usuario entity = this.CreateUsuario(usuario);

                command = DBConnection.CreateStoredProcedure("GetHotelesByIdUsuario");
                command.Parameters.AddWithValue("@usuarioId", entity.Id);
                collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
                foreach (DataRow hotel in collection)
                {
                    //entity.Hoteles.Add(this.CreateHotel(hotel));
                }

                usuarios.Add(entity);
            }

            return usuarios;
        }

        public Usuario GetByUsernameAndPassword(string username, byte[] password)
        {
            RolRepository rolRepository = new RolRepository();
            Usuario usuario = null;

            SqlCommand command = DBConnection.CreateStoredProcedure("GetUsuarioByUsernameAndPassword");
            command.Parameters.AddWithValue("@userName", username);
            command.Parameters.AddWithValue("@password", password);

            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow row in collection)
            {
                usuario = this.CreateUsuario(row);
                usuario.Roles = rolRepository.GetRolesByUsername(username);

                return usuario;
            }

            //command = DBConnection.CreateStoredProcedure("InsertUsuarioLog");
            //command.Parameters.AddWithValue("@userName", username);
            //DBConnection.ExecuteNonQuery(command);

            return usuario;
        }

        private Usuario CreateUsuario(SqlDataReader reader)
        {
            Usuario usuario = new Usuario();
            //usuario.Apellido = reader["apellido"].ToString();
            //usuario.FechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
            //usuario.Mail = reader["mail"].ToString();
            //usuario.Nombre = reader["nombre"].ToString();
            //usuario.NumeroDocumento = reader["numeroDocumento"].ToString();
            //usuario.Telefono = reader["telefono"].ToString();
            //usuario.TipoDocumento = new TipoDocumento { Id = Convert.ToInt32(reader["TipoDocumentoId"]), Nombre = reader["TipoDocumentoNombre"].ToString() };
            //usuario.Direccion = new Direccion { Calle = reader["direccion"].ToString() };
            //usuario.Id = Convert.ToInt32(reader["id"]);
            //usuario.Rol = new Rol { Id = Convert.ToInt32(reader["rolId"]), Nombre = reader["rol"].ToString() };
            //usuario.Username = reader["userName"].ToString();

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

        private static void InsertUsuarioParameters(Usuario usuario, SqlCommand command)
        {
            //command.Parameters.AddWithValue("@username", usuario.Username);
            //command.Parameters.AddWithValue("@password", usuario.HashedPassword);
            //command.Parameters.AddWithValue("@nombre", usuario.Nombre);
            //command.Parameters.AddWithValue("@apellido", usuario.Apellido);
            //command.Parameters.AddWithValue("@tipoDocumentoId", usuario.TipoDocumento.Id);
            //command.Parameters.AddWithValue("@numeroDocumento", usuario.NumeroDocumento);
            //command.Parameters.AddWithValue("@mail", usuario.Mail);
            //command.Parameters.AddWithValue("@telefono", usuario.Telefono);
            //command.Parameters.AddWithValue("@direccion", usuario.Direccion.Calle);
            //command.Parameters.AddWithValue("@fechaNacimiento", usuario.FechaNacimiento);
            //command.Parameters.AddWithValue("@rolId", usuario.Rol.Id);
            //command.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
        }

        private static void UpdateUsuarioParameters(Usuario usuario, SqlCommand command)
        {
            InsertUsuarioParameters(usuario, command);
            command.Parameters.AddWithValue("@username", usuario.Username);
        }

        private void GetUsuariosParameters(string username, string nombre, string apellido, int? tipoDocumentoId, string numeroDocumento, string mail, string telefono, string direccion, DateTime? fechaNacimiento, int? rolId, SqlCommand command)
        {
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@apellido", apellido);
            command.Parameters.AddWithValue("@tipoDocumentoId", tipoDocumentoId);
            command.Parameters.AddWithValue("@numeroDocumento", numeroDocumento);
            command.Parameters.AddWithValue("@mail", mail);
            command.Parameters.AddWithValue("@telefono", telefono);
            command.Parameters.AddWithValue("@direccion", direccion);
            command.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
            command.Parameters.AddWithValue("@rolId", rolId);
        }

        //private Hotel CreateHotel(DataRow row)
        //{
        //    return new Hotel
        //    {
        //        Id = Convert.ToInt32(row["Id"]),
        //        Nombre = !string.IsNullOrEmpty(row["Nombre"].ToString()) ? row["Nombre"].ToString() : "Hotel" + row["Id"].ToString(),
        //        Direccion = row["Direccion"].ToString(),
        //        Ciudad = new Ciudad
        //        {
        //            Id = Convert.ToInt32(row["CiudadId"]),
        //            Nombre = row["CiudadNombre"].ToString(),
        //            Pais = new Pais
        //            {
        //                Id = Convert.ToInt32(row["PaisId"]),
        //                Nombre = row["PaisNombre"].ToString(),
        //                Nacionalidad = row["PaisNacionalidad"].ToString()
        //            }
        //        },
        //        Estrellas = Convert.ToInt32(row["Estrellas"]),
        //        FechaCreacion = Convert.ToDateTime(row["FechaCreacion"]),
        //        Mail = row["Mail"].ToString()
        //    };
        //}

        public bool IsValidUserName(string userName)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("GetCountUsuarioByUserName");
            command.Parameters.AddWithValue("@userName", userName);
            int count = DBConnection.ExecuteScalar(command);

            return count == 0;
        }
    }
}
