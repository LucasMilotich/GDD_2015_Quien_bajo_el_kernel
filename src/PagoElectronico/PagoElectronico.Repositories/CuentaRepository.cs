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
            List<Cuenta> cuentas = new List<Cuenta>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetAllCuentas");
            DataRowCollection collection = DBConnection.EjecutarComandoSelect(command).Rows;
            foreach (DataRow cuenta in collection)
            {
                cuentas.Add(CreateCuenta(cuenta));
            }
            return cuentas;
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

        public int InsertaCuenta(int codPais, int tipoMoneda, int tipoCuenta, long tipoDocCliente, long nroDocCliente, DateTime fecha)
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
                command.Parameters.AddWithValue("@ad_fecha", fecha);

                resultado = DBConnection.ExecuteNonQuery(command);
                command.Dispose();

                transaction.Complete();
            }
            return resultado;

        }

        public IEnumerable<Cuenta> getByCliente(long tipoDocCliente, long nroDocCliente)
        {
            List<Cuenta> cuentas = new List<Cuenta>();

            SqlCommand command = DBConnection.CreateCommand();
            command.CommandText = "select * from QUIEN_BAJO_EL_KERNEL.CUENTA where cliente_tipo_doc = " + tipoDocCliente + " and cliente_numero_doc= " + nroDocCliente + " ";
            DataRowCollection collection = DBConnection.EjecutarComandoSelect(command).Rows;
            foreach (DataRow cuenta in collection)
            {
                cuentas.Add(CreateCuenta(cuenta));
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

        public DataTable GetCuentas(long? pais, int? tipoEstado, int? moneda, int? tipoCuenta, long? nroDoc, long? tipoDoc)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("GetCuentas");
            command.Parameters.AddWithValue("@an_pais", pais);
            command.Parameters.AddWithValue("@an_estado", tipoEstado);
            command.Parameters.AddWithValue("@an_moneda", moneda);
            command.Parameters.AddWithValue("@an_tipo_cuenta", tipoCuenta);
            command.Parameters.AddWithValue("@an_doc", nroDoc);
            command.Parameters.AddWithValue("@an_tipo_doc", tipoDoc);
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
            Cuenta entity = new Cuenta();
            entity.numero = Convert.ToInt64(row["numero"]);
            entity.paisCodigo = Convert.ToInt64(row["pais_codigo"]);
            entity.monedaTipo = Convert.ToInt32(row["moneda_tipo"]);
            entity.tipoCuenta = string.IsNullOrEmpty(row["tipo_cuenta"].ToString()) ? 0 : Convert.ToInt32(row["tipo_cuenta"]);
            entity.nroDoc = Convert.ToInt64(row["cliente_numero_doc"]);
            entity.tipoDoc = Convert.ToInt64(row["cliente_tipo_doc"]);
            entity.saldo = Convert.ToDouble(row["saldo"]);

            return entity;

        }

        public int ModificaCuenta(long numCuenta, int tipoCuenta, DateTime fecha)
        {
            int resultado;
            using (var transaction = new TransactionScope())
            {
                SqlCommand command = DBConnection.CreateStoredProcedure("ModificaCuenta");
                command.Parameters.AddWithValue("@an_nro_cuenta", numCuenta);
                command.Parameters.AddWithValue("@an_cuenta_tipo", tipoCuenta);
                command.Parameters.AddWithValue("@ad_fecha", fecha);

                resultado = DBConnection.ExecuteNonQuery(command);
                command.Dispose();

                transaction.Complete();
            }

            return resultado;
        }

        public int CerrarCuenta(long numCuenta, DateTime fecha)
        {
            int resultado;
            using (var transaction = new TransactionScope())
            {
                SqlCommand command = DBConnection.CreateStoredProcedure("CerrarCuenta");
                command.Parameters.AddWithValue("@an_nro_cuenta", numCuenta);
                command.Parameters.AddWithValue("@ad_fecha", fecha);

                resultado = DBConnection.ExecuteNonQuery(command);
                command.Dispose();

                transaction.Complete();
            }

            return resultado;
        }

        public void HabilitarCuentas(List<ItemFactura> itemsApertura)
        {
            foreach (var item in itemsApertura)
            {
                SqlCommand command = DBConnection.CreateStoredProcedure("HabilitarCuenta");
                command.Parameters.AddWithValue("@cuenta", item.cuenta);
                command.Parameters.AddWithValue("@suscripcion", item.suscripcion);

                DBConnection.ExecuteNonQuery(command);
                DBConnection.CloseCommand(command);
            }
        }

        public void ActualizarCuentasModif(List<ItemFactura> itemsModificacion)
        {
            foreach (var item in itemsModificacion)
            {
                if (item.actualizarCuenta)
                {
                    SqlCommand command = DBConnection.CreateStoredProcedure("HabilitarCuenta");
                    command.Parameters.AddWithValue("@cuenta", item.cuenta);
                    command.Parameters.AddWithValue("@suscripcion", item.suscripcion);

                    DBConnection.ExecuteNonQuery(command);
                    DBConnection.CloseCommand(command);
                }
            }
        }

        public void inhabilitarCuenta(long cuenta, DateTime fecha)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("InhabilitarCuenta");
            command.Parameters.AddWithValue("@cuenta", cuenta);
            command.Parameters.AddWithValue("@fecha", fecha);
            DBConnection.ExecuteNonQuery(command);
        }
    }
}
