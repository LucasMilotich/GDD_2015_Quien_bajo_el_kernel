using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class TipoEstadoCuentaRepository : BaseRepository<TipoEstadoCuenta>
    {

        public override IEnumerable<TipoEstadoCuenta> GetAll()
        {
            List<TipoEstadoCuenta> tiposEstadoCuenta = new List<TipoEstadoCuenta>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetTiposEstadoCuenta");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow tipoEstado in collection)
            {
                TipoEstadoCuenta entity = this.CreateTipoEstadoCuenta(tipoEstado);
                tiposEstadoCuenta.Add(entity);
            }

            return tiposEstadoCuenta;
        }

        public TipoEstadoCuenta CreateTipoEstadoCuenta(DataRow reader)
        {
            TipoEstadoCuenta tipoEstado = new TipoEstadoCuenta();
            tipoEstado.codigo = Convert.ToInt32(reader["codigo"]);
            tipoEstado.descripcion = reader["descripcion"].ToString();

            return tipoEstado;

        }

        public override TipoEstadoCuenta Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(TipoEstadoCuenta entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(TipoEstadoCuenta entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TipoEstadoCuenta entity)
        {
            throw new NotImplementedException();
        }


    }
}
