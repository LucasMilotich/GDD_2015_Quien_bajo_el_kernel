using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class BancoRepository : BaseRepository<Banco>
    {
        public override IEnumerable<Banco> GetAll()
        {
            List<Banco> bancoList = new List<Banco>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetBancos");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow row in collection)
            {
                Banco banco = new Banco();
                banco.codigo= Convert.ToInt32(row[0]);
                banco.nombre = row[1].ToString();
                banco.direccion = row[2].ToString();
                bancoList.Add(banco);
            }

            return bancoList;
        }


        public override Banco Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Banco entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Banco entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Banco entity)
        {
            throw new NotImplementedException();
        }
    }
}
