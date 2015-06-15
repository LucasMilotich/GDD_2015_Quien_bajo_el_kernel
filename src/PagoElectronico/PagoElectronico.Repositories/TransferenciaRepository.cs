using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class TransferenciaRepository : BaseRepository<Transferencia>
    {

        private Transferencia CreateTransferencia(DataRow reader)
        {
            Transferencia transferencia = new Transferencia();
            transferencia.codigo = Convert.ToInt64(reader[0]);
            transferencia.origen = Convert.ToInt64(reader[1]);
            transferencia.destino = Convert.ToInt64(reader[2]);
            transferencia.fecha = Convert.ToDateTime(reader[3]);
            transferencia.importe = Convert.ToDouble(reader[4]);
            transferencia.costo = Convert.ToDouble(reader[5]);
            transferencia.monedaTipo = Convert.ToInt32(reader[6]);
            transferencia.idTransaccion = Convert.ToInt64(reader[7]);

            return transferencia;
        }

        public IEnumerable<Transferencia> getUltimasDiezTransferenciasByCuenta(string cuenta)
        {
            List<Transferencia> transferencias = new List<Transferencia>();

            SqlCommand command = DBConnection.CreateStoredProcedure("getUltimasDiezTransferenciasByCuenta");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow unaTransferencia in collection)
            {
                Transferencia entity = this.CreateTransferencia(unaTransferencia);
                transferencias.Add(entity);
            }
            return transferencias;
        }

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
