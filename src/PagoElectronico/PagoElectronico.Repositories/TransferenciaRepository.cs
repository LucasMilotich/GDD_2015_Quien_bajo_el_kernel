using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;
using System.Globalization;

namespace PagoElectronico.Repositories
{
    public class TransferenciaRepository : BaseRepository<Transferencia>
    {

        private Transferencia CreateTransferencia(DataRow reader)
        {
            Transferencia transferencia = new Transferencia();
            transferencia.codigo = String.IsNullOrEmpty(reader[0].ToString()) ? 0 : Convert.ToInt64(reader[0]);
            transferencia.origen = String.IsNullOrEmpty(reader[1].ToString()) ? 0 : Convert.ToInt64(reader[1]);
            transferencia.destino = String.IsNullOrEmpty(reader[2].ToString()) ? 0 : Convert.ToInt64(reader[2]);
            transferencia.fecha = Convert.ToDateTime(reader[3]);
            transferencia.importe = String.IsNullOrEmpty(reader[4].ToString()) ? 0 : Convert.ToDouble(reader[4]);
            transferencia.costo = String.IsNullOrEmpty(reader[5].ToString()) ? 0 : Convert.ToDouble(reader[5]);
            transferencia.monedaTipo = String.IsNullOrEmpty(reader[6].ToString()) ? 0 : Convert.ToInt32(reader[6]);

            return transferencia;
        }

        public IEnumerable<Transferencia> getUltimasDiezTransferenciasByCuenta(string cuenta)
        {
            List<Transferencia> transferencias = new List<Transferencia>();

            SqlCommand command = DBConnection.CreateStoredProcedure("getUltimasDiezTransferenciasByCuenta");
            command.Parameters.AddWithValue("@cuenta", cuenta); 
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

                SqlCommand unCommand = DBConnection.CreateStoredProcedure("insertTransferencia");
                unCommand.Parameters.AddWithValue("@origen",entity.origen);
                unCommand.Parameters.AddWithValue("@destino",entity.destino);
                unCommand.Parameters.AddWithValue("@importe",entity.importe);
                unCommand.Parameters.AddWithValue("@costo",entity.costo);
                unCommand.Parameters.AddWithValue("@moneda_tipo", entity.monedaTipo);

                resultado = DBConnection.ExecuteNonQuery(unCommand);
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
