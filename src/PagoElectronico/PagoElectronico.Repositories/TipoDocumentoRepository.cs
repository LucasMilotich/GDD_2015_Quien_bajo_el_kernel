using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class TipoDocumentoRepository : BaseRepository<TipoDocumento>
    {
        public override IEnumerable<TipoDocumento> GetAll()
        {
            List<TipoDocumento> tipoDocumentoList = new List<TipoDocumento>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetTipoDocumento");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow row in collection)
            {
                TipoDocumento tipoDocumento = new TipoDocumento();
                tipoDocumento.codigo = Convert.ToInt32(row[0]);
                tipoDocumento.descripcion = row[1].ToString();
                tipoDocumentoList.Add(tipoDocumento);
            }

            return tipoDocumentoList;
        }


        public override TipoDocumento Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(TipoDocumento entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(TipoDocumento entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TipoDocumento entity)
        {
            throw new NotImplementedException();
        }
    }
}
