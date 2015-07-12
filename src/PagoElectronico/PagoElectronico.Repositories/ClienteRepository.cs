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

        public Cliente getClienteByUsername(String usuario)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("getClienteByUsername");
            command.Parameters.AddWithValue("@username", usuario);

            Cliente cliente = materializarCliente(DBConnection.EjecutarStoredProcedureSelect(command).Rows[0]);
            return cliente;
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

        public Cliente materializarCliente (DataRow dataRow)
        {
            Cliente cliente = new Cliente();
            cliente.tipoDocumento = Int64.Parse(dataRow["tipo_documento"].ToString());
            cliente.numeroDocumento= Int64.Parse(dataRow["numero_documento"].ToString());
            cliente.paisCodigo = Int64.Parse(dataRow["pais_codigo"].ToString());
            cliente.nombre = dataRow["nombre"].ToString();
            cliente.apellido = dataRow["apellido"].ToString();
            cliente.domCalle = dataRow["dom_calle"].ToString();
            cliente.domNro = Int64.Parse(dataRow["dom_nro"].ToString());
            cliente.domPiso = Int64.Parse(dataRow["dom_piso"].ToString());
            cliente.domDpto = dataRow["dom_dpto"].ToString();
            cliente.fechaNacimiento = DateTime.Parse(dataRow["fecha_nacimiento"].ToString());
            cliente.mail = dataRow["mail"].ToString();
            cliente.localidad = dataRow["localidad"].ToString();
            cliente.username = dataRow["username"].ToString();

            return cliente;

        }

    }
}
