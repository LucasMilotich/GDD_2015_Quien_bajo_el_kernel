using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data;
using System.Data.SqlClient;

namespace PagoElectronico.Repositories
{
    public class FuncionalidadRepository : BaseRepository<Funcionalidad>
    {
        public override IEnumerable<Funcionalidad> GetAll()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            SqlCommand command = DBConnection.CreateStoredProcedure("SELECT_FUNCIONALIDAD");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow row in collection)
            {
                funcionalidades.Add(this.CreateFuncionalidad(row));
            }
            return funcionalidades;
        }

        public override Funcionalidad Get(int id) { throw new NotImplementedException(); }

        public override int Insert(Funcionalidad entity) { throw new NotImplementedException(); }

        public override void Update(Funcionalidad entity) { throw new NotImplementedException(); }

        public override void Delete(Funcionalidad entity) { throw new NotImplementedException(); }

        public IEnumerable<Funcionalidad> GetByRolId(int rolId)
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            SqlCommand command = DBConnection.CreateStoredProcedure("GetFuncionalidadesByRol");
            command.Parameters.AddWithValue("@rolId", rolId);
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow row in collection)
            {
                funcionalidades.Add(this.CreateFuncionalidad(row));
            }
            return funcionalidades;
        }

        private Funcionalidad CreateFuncionalidad(DataRow row)
        {
            Funcionalidad funcionalidad = new Funcionalidad();
            funcionalidad.Id = Convert.ToInt32(row["id_funcionalidad"]);
            funcionalidad.Nombre = row["descripcion"].ToString();
            return funcionalidad;
        }
    }
}
