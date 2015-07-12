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
            command.Parameters.AddWithValue("@calle", entity.domCalle);
            command.Parameters.AddWithValue("@piso", entity.domPiso);
            command.Parameters.AddWithValue("@dpto", entity.domDpto);
            command.Parameters.AddWithValue("@localidad", entity.localidad);
            command.Parameters.AddWithValue("@nacionalidad", entity.nacionalidad);
            command.Parameters.AddWithValue("@tipoDocCod", entity.tipoDocumento);
            command.Parameters.AddWithValue("@dni", entity.numeroDocumento);
            command.Parameters.AddWithValue("@username", entity.username);
           

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
