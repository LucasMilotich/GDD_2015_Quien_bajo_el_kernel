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
            retiro.codigo = Convert.ToInt64(reader[0]);
            retiro.fecha = Convert.ToDateTime(reader[1]);
            retiro.importe = Convert.ToInt64(reader[2]);
            retiro.cuenta = Convert.ToInt64(reader[3]);
            retiro.cheque = Convert.ToInt64(reader[4]);

            return retiro;
        }

        public IEnumerable<Retiro> getUltimosCincoRetirosByCuenta(string cuenta)
        {
            List<Retiro> retiros = new List<Retiro>();

            SqlCommand command = DBConnection.CreateStoredProcedure("getUltimosCincoRetirosByCuenta");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow unRetiro in collection)
            {
                Retiro entity = this.CreateRetiro(unRetiro);
                retiros.Add(entity);
            }
            return retiros;
        }
    }
}
