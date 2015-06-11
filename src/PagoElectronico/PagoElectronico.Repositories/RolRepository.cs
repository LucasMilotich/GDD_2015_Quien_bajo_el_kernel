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
    class RolRepository : BaseRepository<Rol>
    {
        public override IEnumerable<Rol> GetAll() { return this.GetAll(); }
        public override Rol Get(int id) {return  new Rol();}
        public override void Delete(Rol rol) { }
        public override void Update(Rol rol) { }

        public override int Insert(Rol rol)
        {
            int id;
            using (var transaction = new TransactionScope())
            {
                SqlCommand command = DBConnection.CreateStoredProcedure("QUIEN_BAJO_EL_KERNEL.ROL_INSERTAR");
                this.bindAtributos(rol, command);
                id = DBConnection.ExecuteScalar(command);
                transaction.Complete();
            }
            return id;
        }

        public void bindAtributos(Rol rol, SqlCommand command)
        {

            command.Parameters.AddWithValue("@nombre", rol.Nombre);
            command.Parameters.AddWithValue("@activo", rol.Activo);


        }
    }
}
