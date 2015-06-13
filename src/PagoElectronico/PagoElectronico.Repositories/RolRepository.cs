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

       

        public void bindAtributos(Rol rol, SqlCommand command)
        {

            command.Parameters.AddWithValue("@nombre", rol.Nombre);
            command.Parameters.AddWithValue("@activo", rol.Activo);


        }
    }
}
