using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class PaisRepository : BaseRepository<Pais>
    {

        public override IEnumerable<Pais> GetAll()
        {
            List<Pais> paises = new List<Pais>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetPaises");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow pais in collection)
            {
                Pais entity = this.CreatePais(pais);
                paises.Add(entity);
            }

            return paises;
        }

        public override Pais Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Pais entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Pais entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Pais entity)
        {
            throw new NotImplementedException();
        }

        private Pais CreatePais(DataRow reader)
        {
            Pais pais = new Pais();
            pais.codigoPais = Convert.ToInt64(reader["codigo_pais"]);
            pais.descripcionPais = reader["descripcion_pais"].ToString();

            return pais;
        }
    }
}
