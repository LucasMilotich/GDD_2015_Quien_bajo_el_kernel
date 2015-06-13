using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data;
using System.Data.SqlClient;

namespace PagoElectronico.Repositories 
{
    public class FuncionesRepository : BaseRepository<Funcionalidad>
    {
        public override IEnumerable<Funcionalidad> GetAll() {
           List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            SqlCommand command = DBConnection.CreateStoredProcedure("SELECT_FUNCIONALIDAD");
          //  command.Parameters.AddWithValue("@id", null);
           // command.Parameters.AddWithValue("@descripcion", null);
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow row in collection)
            {
               funcionalidades.Add(this.CreateFuncionalidad(row));
            }
            return funcionalidades;
            }

        public override Funcionalidad Get(int id) {
            
            
            
            return new Funcionalidad();
        
        }

        public override int Insert(Funcionalidad entity) { return 0; }

        public override void Update(Funcionalidad entity) { }

        public override void Delete(Funcionalidad entity) { }

        public Funcionalidad CreateFuncionalidad(DataRow row) {
            Funcionalidad funcionalidad = new Funcionalidad();
            funcionalidad.Id = Convert.ToInt32(row["id_funcionalidad"]);
            funcionalidad.Nombre = row["descripcion"].ToString();
            return funcionalidad;

        
        } 

    }
}
