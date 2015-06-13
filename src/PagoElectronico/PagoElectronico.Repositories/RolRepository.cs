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
    public class RolRepository : BaseRepository<Rol>
    {



        public override IEnumerable<Rol> GetAll() { return null; }
        public override Rol Get(int id) { return new Rol(); }
        public override void Delete(Rol rol) { }
        public override void Update(Rol rol) { }

        public override int Insert(Rol rol)
        {
           
            using (var transaction = new TransactionScope())
            {
                //Rol
                SqlCommand command = DBConnection.CreateStoredProcedure("INSERT_ROL");
                this.bindAtributos(rol, command);
                 rol.Id = DBConnection.ExecuteScalar(command);
              
                //Rol_funciones
                  
                {
                    foreach (var item in rol.Funcionalidades)
                    {

                        command = DBConnection.CreateStoredProcedure("INSERT_ROL_FUNCIONALIDAD");
                        command.Parameters.AddWithValue("id_rol", rol.Id);
                        command.Parameters.AddWithValue("id_funcionalidad", item.Id);
                         DBConnection.ExecuteNonQuery(command);
                    }


                    transaction.Complete();
                }

            }
            return rol.Id;
        }


        public List<Rol> getRoles(String nombre, bool activo)
        {
            Rol rol;
            List<Rol> roles = new List<Rol>();
            SqlCommand command = DBConnection.CreateStoredProcedure("SELECT_ROL");
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@activo", activo);
            DataRowCollection collection =  DBConnection.EjecutarComandoSelect(command).Rows;
            foreach (DataRow item in collection)

            {
                rol = new Rol();
                rol.Activo = Convert.ToBoolean(item["activo"]);
                rol.Nombre = item["nombre"].ToString();
                rol.Id = Convert.ToInt32(item["id"]);
                roles.Add(rol);
            }
            return roles;
        }





        private void bindAtributos(Rol rol, SqlCommand command)
        {

            command.Parameters.AddWithValue("@nombre", rol.Nombre);
            command.Parameters.AddWithValue("@activo", rol.Activo);


        }
    }
}
