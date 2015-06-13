using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Transactions;

namespace PagoElectronico.Repositories
{
    public class TransferenciaRepository : BaseRepository<Transferencia>
    {

        public override int Insert(Transferencia entity)
        {
            int resultado;
             using (var transaction = new TransactionScope())
            {
                SqlCommand unCommand = DBConnection.CreateCommand();
                unCommand.CommandText = "insert into [QUIEN_BAJO_EL_KERNEL].TRANSFERENCIA (origen, destino, fecha, importe, costo, moneda_tipo, id_transaccion) values (" + entity.origen + ", " + entity.destino + ", \'" + entity.fecha.ToShortDateString() + "\', " + entity.importe + ", " + entity.costo + ", " + entity.monedaTipo + ", " + entity.idTransaccion + ")";
                resultado=DBConnection.ExecuteNonQuery(unCommand);
                unCommand.Dispose();

                transaction.Complete();
            }
             return resultado;
        }
        

        public override IEnumerable<Transferencia> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Transferencia Get(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Transferencia entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Transferencia entity)
        {
            throw new NotImplementedException();
        }
    }
}
