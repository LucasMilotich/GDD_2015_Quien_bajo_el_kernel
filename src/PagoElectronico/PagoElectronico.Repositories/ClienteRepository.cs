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
        public IEnumerable<Cliente> getByMayorTransacciones(DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("ClientesConMayorTransacciones");
            command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@fechaHasta", fechaHasta);

            DataRowCollection clientes = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            List<Cliente> listaClientes = new List<Cliente>();

            foreach (DataRow unCliente in clientes)
            {
                Cliente entity = new Cliente();
                entity.tipoDocumento = Convert.ToInt64(unCliente[0]);
                entity.numeroDocumento = Convert.ToInt64(unCliente[1]);
                entity.apellido = unCliente[2].ToString();
                entity.nombre = unCliente[3].ToString();

                listaClientes.Add(entity);
            }

            return listaClientes;
        }

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
