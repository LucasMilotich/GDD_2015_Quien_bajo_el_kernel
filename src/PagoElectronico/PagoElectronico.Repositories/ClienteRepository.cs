using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PagoElectronico.Entities;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>
    {
        
        public override IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Cliente Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Cliente entity)
        {

            throw new NotImplementedException();
        }

        public override void Update(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
