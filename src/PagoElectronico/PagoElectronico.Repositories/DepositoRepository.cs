using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class DepositoRepository : BaseRepository<Deposito>
    {

        private Deposito CreateDeposito(DataRow reader)
        {
            Deposito deposito = new Deposito();
            deposito.depositoCodigo = Convert.ToInt64(reader[0]);
            deposito.fecha = Convert.ToDateTime(reader[1]);
            deposito.importe = String.IsNullOrEmpty(reader[2].ToString()) ? 0 : Convert.ToDouble(reader[2]);
            deposito.cuentaNumero = String.IsNullOrEmpty(reader[3].ToString()) ? 0 : Convert.ToInt64(reader[3]);
            deposito.monedaTipo = String.IsNullOrEmpty(reader[4].ToString()) ? 0 : Convert.ToInt32(reader[4]);
            deposito.tarjetaNumero = reader[5].ToString();
            deposito.codigoSeguridad = reader[6].ToString();

            return deposito;
        }

        public IEnumerable<Deposito> getUltimosCincoDepositosByCuenta(string cuenta)
        {

            List<Deposito> depositos = new List<Deposito>();

            SqlCommand command = DBConnection.CreateStoredProcedure("getUltimosCincoDepositosByCuenta");
            command.Parameters.AddWithValue("@cuenta", cuenta); 
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow unDeposito in collection)
            {
                Deposito entity = this.CreateDeposito(unDeposito);
                depositos.Add(entity);
            }

            return depositos;

        }

        public override IEnumerable<Deposito> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Deposito Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Deposito entity)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("Insert_Deposito");

            command.Parameters.AddWithValue("@fecha", entity.fecha);
            command.Parameters.AddWithValue("@importe", entity.importe);
            command.Parameters.AddWithValue("@cuenta_numero", entity.cuentaNumero);
            command.Parameters.AddWithValue("@moneda_tipo", entity.monedaTipo);
            command.Parameters.AddWithValue("@tarjeta_numero", entity.tarjetaNumero);
            command.Parameters.AddWithValue("@codigo_seguridad", entity.codigoSeguridad);


            return DBConnection.ExecuteNonQuery(command);
        }

        public override void Update(Deposito entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Deposito entity)
        {
            throw new NotImplementedException();
        }



    }
}
