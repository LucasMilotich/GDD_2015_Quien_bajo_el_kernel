using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class RetiroRepository : BaseRepository<Retiro>
    {

        private Retiro CreateRetiro(DataRow reader)
        {
            Retiro retiro = new Retiro();
            retiro.codigo = String.IsNullOrEmpty(reader["codigo"].ToString()) ? 0 : Convert.ToInt64(reader[0]);
            retiro.fecha = Convert.ToDateTime(reader["fecha"]);
            retiro.importe = String.IsNullOrEmpty(reader["importe"].ToString()) ? 0 : Convert.ToDouble(reader[2]);
            retiro.cuenta = String.IsNullOrEmpty(reader["cuenta"].ToString()) ? 0 : Convert.ToInt64(reader[3]);
            retiro.codigoCheque = String.IsNullOrEmpty(reader["cheque"].ToString()) ? 0 : Convert.ToInt64(reader[4]);

            return retiro;
        }

        public IEnumerable<Retiro> getUltimosCincoRetirosByCuenta(string cuenta)
        {
            List<Retiro> retiros = new List<Retiro>();

            SqlCommand command = DBConnection.CreateStoredProcedure("getUltimosCincoRetirosByCuenta");
            command.Parameters.AddWithValue("@cuenta", cuenta);
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow unRetiro in collection)
            {
                Retiro entity = this.CreateRetiro(unRetiro);
                retiros.Add(entity);
            }
            return retiros;
        }

        public override IEnumerable<Retiro> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Retiro Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Retiro entity)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("Insert_Retiro");

            command.Parameters.AddWithValue("@fecha", entity.fecha);
            command.Parameters.AddWithValue("@importe", entity.importe);
            command.Parameters.AddWithValue("@cuenta", entity.cuenta);
            command.Parameters.AddWithValue("@cheque", entity.codigoCheque);

            return DBConnection.ExecuteNonQuery(command);
        }

        public override void Update(Retiro entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Retiro entity)
        {
            throw new NotImplementedException();
        }
    }
}
