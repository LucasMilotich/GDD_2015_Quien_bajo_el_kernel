using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class CuentaRepository : BaseRepository<Cuenta>
    {

        public override IEnumerable<Cuenta> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Cuenta Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Cuenta entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Cuenta entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Cuenta entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<long> getByCliente(long tipoDocCliente, long nroDocCliente)
        {
            List<long> cuentas = new List<long>();

            SqlCommand command = DBConnection.CreateCommand();
            command.CommandText = "select numero from QUIEN_BAJO_EL_KERNEL.CUENTA where cliente_tipo_doc = " + tipoDocCliente + " and cliente_numero_doc= " + nroDocCliente + " ";
            DataRowCollection collection = DBConnection.EjecutarComandoSelect(command).Rows;
            foreach (DataRow cuenta in collection)
            {
                cuentas.Add(Convert.ToInt64(cuenta[0]));
            }
            return cuentas;
        }

        public double getSaldo(long numeroCuenta)
        {
            SqlCommand command = DBConnection.CreateCommand();
            command.CommandText = "select saldo from [QUIEN_BAJO_EL_KERNEL].[CUENTA] where numero=" + numeroCuenta.ToString();
            return DBConnection.ExecuteScalarDouble(command);
        }

        public int getEstado(long numeroCuenta)
        {
            SqlCommand command = DBConnection.CreateCommand();
            command.CommandText = "select estado_codigo from [QUIEN_BAJO_EL_KERNEL].[CUENTA] where numero=" + numeroCuenta.ToString();
            return DBConnection.ExecuteScalar(command);

        }

        public int getMonedaTipo(long numeroCuenta)
        {
            SqlCommand command = DBConnection.CreateCommand();
            command.CommandText = "select moneda_tipo from [QUIEN_BAJO_EL_KERNEL].[CUENTA] where numero=" + numeroCuenta.ToString();
            return DBConnection.ExecuteScalar(command);
        }
    }
}
