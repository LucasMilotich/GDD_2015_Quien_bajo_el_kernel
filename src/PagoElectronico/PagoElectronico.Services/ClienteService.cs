using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;
using System.Data;

namespace PagoElectronico.Services
{
    public class ClienteService
    {
        public int createCliente(Cliente cliente)
        {
            ClienteRepository repo = new ClienteRepository();
            return repo.Insert(cliente);
        }


        public Cliente getClienteByUsername(String usuario)
        {
            ClienteRepository repo = new ClienteRepository();
            return repo.getClienteByUsername(usuario);
        }


        public IEnumerable<Cliente> GetClientes()
        {
            ClienteRepository repository = new ClienteRepository();
            return repository.GetClientes();
        }


        public DataTable getClientesByFiltros(String apellido, String nombre, String mail, long? tipoDoc, long? nroDoc)
        {
            ClienteRepository repo = new ClienteRepository();
            return repo.getClientesByFiltros(apellido, nombre, mail, tipoDoc, nroDoc);   
        }

        public bool existeDocumento(long documento, long tipoDocumento)
        {
            ClienteRepository repo = new ClienteRepository();
            return repo.existeDocumento(documento, tipoDocumento);
        }

        public bool existeMail(string mail)
        {
            ClienteRepository repo = new ClienteRepository();
            return repo.existeMail(mail);
        }

    }

}