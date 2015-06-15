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
            deposito.cuentaNumero = Convert.ToInt64(reader[0]);
            deposito.fecha = Convert.ToDateTime(reader[1]);
            deposito.importe = Convert.ToDouble(reader[2]);
            deposito.cuentaNumero = Convert.ToInt64(reader[3]);
            deposito.monedaTipo = Convert.ToInt32(reader[4]);
            deposito.tarjetaNumero = reader[5].ToString();

            return deposito;
        }

        public IEnumerable<Deposito> getUltimosCincoDepositosByCuenta(string cuenta)
        {

            List<Deposito> depositos = new List<Deposito>();

            SqlCommand command = DBConnection.CreateStoredProcedure("getUltimosCincoDepositosByCuenta");
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
            throw new NotImplementedException();
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
