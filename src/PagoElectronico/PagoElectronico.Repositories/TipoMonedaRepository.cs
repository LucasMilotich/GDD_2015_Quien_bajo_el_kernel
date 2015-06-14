using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PagoElectronico.Entities;

namespace PagoElectronico.Repositories
{
    public class TipoMonedaRepository : BaseRepository<TipoMoneda>
    {

        public override IEnumerable<TipoMoneda> GetAll()
        {
            List<TipoMoneda> tipoMonedasList = new List<TipoMoneda>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetTipoMoneda");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow row in collection)
            {
                TipoMoneda tipoMoneda = new TipoMoneda();
                tipoMoneda.codigo = Convert.ToInt32(row[0]);
                tipoMoneda.descripcion = row[1].ToString();
                tipoMonedasList.Add(tipoMoneda);
            }

            return tipoMonedasList;
        }

        public override TipoMoneda Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(TipoMoneda entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(TipoMoneda entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TipoMoneda entity)
        {
            throw new NotImplementedException();
        }

    }
}
