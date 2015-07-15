using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class TipoTransaccionRepository : BaseRepository<TipoTransaccion>
    {

        public override IEnumerable<TipoTransaccion> GetAll()
        {
            List<TipoTransaccion> tiposTransac = new List<TipoTransaccion>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetTiposTransaccion");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow tipoTransac in collection)
            {
                TipoTransaccion entity = this.CreateTipoTransaccion(tipoTransac);
                tiposTransac.Add(entity);
            }

            return tiposTransac;
        }

        private TipoTransaccion CreateTipoTransaccion(DataRow tipoTransac)
        {
            TipoTransaccion entity = new TipoTransaccion();
            entity.ID = Convert.ToInt64(tipoTransac["id_transaccion"]);
            entity.descripcion = Convert.ToString(tipoTransac["descripcion"]);
            entity.costo = Convert.ToDouble(tipoTransac["costo"]);
            return entity;
        }

        public override TipoTransaccion Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(TipoTransaccion entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(TipoTransaccion entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TipoTransaccion entity)
        {
            throw new NotImplementedException();
        }
    }
}
