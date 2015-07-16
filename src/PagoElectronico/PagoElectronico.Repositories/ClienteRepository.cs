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

            SqlCommand command = DBConnection.CreateStoredProcedure("INSERT_CLIENTE");

            command.Parameters.AddWithValue("@nombre", entity.nombre);
            command.Parameters.AddWithValue("@apellido", entity.apellido);
            command.Parameters.AddWithValue("@mail", entity.mail);
            command.Parameters.AddWithValue("@paisCod", entity.paisCodigo);
            command.Parameters.AddWithValue("@dom_calle", entity.domCalle);
            command.Parameters.AddWithValue("@dom_nro", entity.domNro);
            command.Parameters.AddWithValue("@dom_piso", entity.domPiso);
            command.Parameters.AddWithValue("@dom_dpto", entity.domDpto);
            command.Parameters.AddWithValue("@localidad", entity.localidad);
            command.Parameters.AddWithValue("@tipoDocCod", entity.tipoDocumento);
            command.Parameters.AddWithValue("@dni", entity.numeroDocumento);
            command.Parameters.AddWithValue("@username", entity.username);
            command.Parameters.AddWithValue("@fechaNac", entity.fechaNacimiento);
           


        

         
            return DBConnection.ExecuteNonQuery(command);
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


        public IEnumerable<Cliente> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetClientes");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow cliente in collection)
            {
                Cliente entity = this.materializarCliente(cliente);
                clientes.Add(entity);
            }

            return clientes;
        }

        public DataTable getClientesByFiltros(String apellido, String nombre, String mail, long? tipoDoc, long? nroDoc) 
        {
           
            SqlCommand command = DBConnection.CreateStoredProcedure("getClientesByFiltros");
            command.Parameters.AddWithValue("@apellido", String.IsNullOrEmpty(apellido) ? null : apellido);
            command.Parameters.AddWithValue("@nombre", String.IsNullOrEmpty(nombre) ? null : nombre);
            command.Parameters.AddWithValue("@mail", String.IsNullOrEmpty(mail) ? null : mail);
            command.Parameters.AddWithValue("@tipoDoc", tipoDoc);
            command.Parameters.AddWithValue("@nroDoc", nroDoc);
            return DBConnection.EjecutarStoredProcedureSelect(command);

        }
    
        public bool existeDocumento( long documento, long  tipoDocumento){

            SqlCommand command = DBConnection.CreateStoredProcedure("SELECT_CLIENTE_BY_DNI ");
            command.Parameters.AddWithValue("@documento", documento);
            command.Parameters.AddWithValue("@tipoDocumento", tipoDocumento);
            if (DBConnection.EjecutarStoredProcedureSelect(command).Rows.Count > 0)
                return true;
            else 
                return false;        
        }

        
        public bool existeMail(string mail)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("getUsersByMail ");
            command.Parameters.AddWithValue("@mail", mail);
            if (DBConnection.EjecutarStoredProcedureSelect(command).Rows.Count > 0)
                return true;
            else
                return false;        
        }


    }
}
