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

        public Cliente getClienteByDNI(long tipoDoc, long nroDoc)
        {
            ClienteRepository repo = new ClienteRepository();
            return repo.getClienteByDNI(tipoDoc, nroDoc);
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

        public void updateCliente(Cliente cliente)
        {
            ClienteRepository repo = new ClienteRepository();
            repo.Update(cliente);
        }

        public void habilitarCliente(long tipoDoc, long nroDoc)
        {
            ClienteRepository repo = new ClienteRepository();
            repo.habilitarCliente(tipoDoc, nroDoc);
        }

        public void inhabilitarCliente(long tipoDoc, long nroDoc)
        {
            ClienteRepository repo = new ClienteRepository();
            repo.inhabilitarCliente(tipoDoc, nroDoc);
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

        public bool existeMailParaOtroCliente(string mail, Cliente cli)
        {
            ClienteRepository repo = new ClienteRepository();
            return repo.existeMailParaOtroCliente(mail, cli);
        }

      
    }

}