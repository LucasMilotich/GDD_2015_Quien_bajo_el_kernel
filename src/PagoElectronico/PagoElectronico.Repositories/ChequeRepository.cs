using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;

namespace PagoElectronico.Repositories
{
    public class ChequeRepository : BaseRepository<Cheque>
    {
        
        public override IEnumerable<Cheque> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Cheque Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Cheque entity)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("Insert_Cheque");

            command.Parameters.AddWithValue("@numero", entity.numero);
            command.Parameters.AddWithValue("@fecha", entity.fecha);
            command.Parameters.AddWithValue("@importe", entity.importe);            
            command.Parameters.AddWithValue("@codigo_banco", entity.codigoBanco);
            command.Parameters.AddWithValue("@moneda_tipo", entity.monedaTipo);
            command.Parameters.AddWithValue("@nombre_destinatario", entity.nombreDestinatario);

            return DBConnection.ExecuteNonQuery(command);
        }

        public override void Update(Cheque entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Cheque entity)
        {
            throw new NotImplementedException();
        }
    }
}
