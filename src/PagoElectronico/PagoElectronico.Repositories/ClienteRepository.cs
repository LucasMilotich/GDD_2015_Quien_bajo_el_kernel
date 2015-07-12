using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PagoElectronico.Entities;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>
    {
        
        public override IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Cliente Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Cliente entity)
        {

            SqlCommand command = DBConnection.CreateStoredProcedure("INSERT_USUARIO");

            command.Parameters.AddWithValue("@nombre", entity.nombre);
            command.Parameters.AddWithValue("@apellido", entity.apellido);
            command.Parameters.AddWithValue("@mail", entity.mail);
         //   command.Parameters.AddWithValue("@pais_desc", entity.paisCodigo);
            command.Parameters.AddWithValue("@calle", entity.Activo);
            command.Parameters.AddWithValue("@piso", entity.Habilitado);
            command.Parameters.AddWithValue("@dpto", entity.Habilitado);
            command.Parameters.AddWithValue("@localidad", entity.Habilitado);
            command.Parameters.AddWithValue("@nacionalidad", entity.Habilitado);
            command.Parameters.AddWithValue("@tipoDocCod", entity.Habilitado);
            command.Parameters.AddWithValue("@dni", entity.Habilitado);
            command.Parameters.AddWithValue("@username", entity.Habilitado);
           

            return DBConnection.ExecuteNonQuery(command);
        }

        public override void Update(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
