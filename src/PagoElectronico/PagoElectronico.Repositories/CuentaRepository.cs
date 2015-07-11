using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

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

        public int InsertaCuenta(int codPais, int tipoMoneda, int tipoCuenta, long tipoDocCliente, long nroDocCliente)
        {
            int resultado;
            using (var transaction = new TransactionScope())
            {
                SqlCommand command = DBConnection.CreateStoredProcedure("InsertaCuenta");
                command.Parameters.AddWithValue("@an_cod_pais", codPais);
                command.Parameters.AddWithValue("@an_moneda_tipo", tipoMoneda);
                command.Parameters.AddWithValue("@an_cuenta_tipo", tipoCuenta);
                command.Parameters.AddWithValue("@an_cliente_tipo_doc", tipoDocCliente);
                command.Parameters.AddWithValue("@an_cliente_doc", nroDocCliente);

                resultado = DBConnection.ExecuteNonQuery(command);
                command.Dispose();

                transaction.Complete();
            }
            return resultado;

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

        public IEnumerable<TipoCuenta> getTiposCuenta()
        {
            List<TipoCuenta> tipoCuentas = new List<TipoCuenta>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetTiposCuenta");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow tipo in collection)
            {
                TipoCuenta entity = this.CreateTipoCuenta(tipo);
                tipoCuentas.Add(entity);
            }

            return tipoCuentas;

        }


        private TipoCuenta CreateTipoCuenta(DataRow reader)
        {
            TipoCuenta tipo = new TipoCuenta();
            tipo.codigo = Convert.ToInt32(reader["codigo"]);
            tipo.costo = Convert.ToDouble(reader["costo"]);
            tipo.descripcion = reader["descripcion"].ToString();
            tipo.duracion = Convert.ToInt64(reader["duracion"]);

            return tipo;
        }

        public long GetMaxNroCuenta()
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("GetMaxNroCuenta");
            return DBConnection.ExecuteScalarLong(command);
        }

        public DataTable GetCuentas(long? pais, int? tipoEstado, int? moneda, int? tipoCuenta)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("GetCuentas");
            command.Parameters.AddWithValue("@an_pais", pais);
            command.Parameters.AddWithValue("@an_estado", tipoEstado);
            command.Parameters.AddWithValue("@an_moneda", moneda);
            command.Parameters.AddWithValue("@an_tipo_cuenta", tipoCuenta);
            return DBConnection.EjecutarStoredProcedureSelect(command);
           
        }

        public Cuenta GetCuentaByNumero(long nroCuenta)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("GetCuentaByNumero");
            command.Parameters.AddWithValue("@an_nro_cuenta", nroCuenta);

            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            Cuenta cuenta = null;
            foreach (DataRow row in collection)
            {
                cuenta = this.CreateCuenta(row);
            }

            return cuenta;
        }

        private Cuenta CreateCuenta(DataRow row)
        {
            Cuenta cuenta = new Cuenta();
            cuenta.numero = Convert.ToInt64(row["numero"]);
            cuenta.paisCodigo = Convert.ToInt64(row["pais_codigo"]);
            cuenta.monedaTipo = Convert.ToInt32(row["moneda_tipo"]);
            cuenta.tipoCuenta = string.IsNullOrEmpty(row["tipo_cuenta"].ToString()) ? 0 : Convert.ToInt32(row["tipo_cuenta"]);
            cuenta.nroDoc = Convert.ToInt64(row["cliente_numero_doc"]);
            cuenta.tipoDoc = Convert.ToInt64(row["cliente_tipo_doc"]);

            return cuenta;

        }

        public int ModificaCuenta(long numCuenta, int tipoMoneda, int tipoCuenta, int codPais)
        {
            int resultado;
            using (var transaction = new TransactionScope())
            {
                SqlCommand command = DBConnection.CreateStoredProcedure("ModificaCuenta");
                command.Parameters.AddWithValue("@an_nro_cuenta", numCuenta);
                command.Parameters.AddWithValue("@an_moneda_tipo", tipoMoneda);
                command.Parameters.AddWithValue("@an_cuenta_tipo", tipoCuenta);
                command.Parameters.AddWithValue("@an_cod_pais", codPais);

                resultado = DBConnection.ExecuteNonQuery(command);
                command.Dispose();

                transaction.Complete();
            }

            return resultado;
        }
    }
}
