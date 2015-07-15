using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class TransaccionRepository : BaseRepository<Transaccion>
    {
        public IEnumerable<Transaccion> getTransferenciasSinFacturar(long tipoDoc, long numeroDoc)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("GetTransferenciasSinFacturar");
            command.Parameters.AddWithValue("@tipoDoc", tipoDoc);
            command.Parameters.AddWithValue("@numeroDoc", numeroDoc);
            return getTransacciones(command);
        }

        public IEnumerable<Transaccion> getAperturaCuentasSinFacturar(long tipoDoc, long numeroDoc)
        {
            List<Transaccion> transacciones = new List<Transaccion>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetAperturaCuentasSinFacturar");
            command.Parameters.AddWithValue("@tipoDoc", tipoDoc);
            command.Parameters.AddWithValue("@numeroDoc", numeroDoc);
            return getTransacciones(command);
        }

        public IEnumerable<Transaccion> getModifCuentasSinFacturar(long tipoDoc, long numeroDoc)
        {
            List<Transaccion> transacciones = new List<Transaccion>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetModifCuentasSinFacturar");
            command.Parameters.AddWithValue("@tipoDoc", tipoDoc);
            command.Parameters.AddWithValue("@numeroDoc", numeroDoc);
            return getTransacciones(command);
        }

        private IEnumerable<Transaccion> getTransacciones(SqlCommand command)
        {
            List<Transaccion> transacciones = new List<Transaccion>();
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow transaccion in collection)
            {
                Transaccion entity = this.CreateTransaccion(transaccion);
                transacciones.Add(entity);
            }

            return transacciones;
        }

        private Transaccion CreateTransaccion(DataRow transaccion)
        {
            Transaccion entity = new Transaccion();
            //entity.codigo = Convert.ToInt64(transaccion["Codigo"]);
            entity.codigo = String.IsNullOrEmpty(transaccion["Codigo"].ToString()) ? 0 : Convert.ToInt64(transaccion["Codigo"]);
            entity.cuenta = Convert.ToInt64(transaccion["Cuenta"]);
            entity.costo = Convert.ToDouble(transaccion["Costo"]);
            entity.tipo = Convert.ToInt32(transaccion["TipoTransaccion"]);
            return entity;
        }

        public override IEnumerable<Transaccion> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Transaccion Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Transaccion entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Transaccion entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Transaccion entity)
        {
            throw new NotImplementedException();
        }
    }
}
