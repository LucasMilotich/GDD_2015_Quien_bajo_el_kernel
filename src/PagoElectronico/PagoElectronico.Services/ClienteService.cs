using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;
using System;

namespace PagoElectronico.Services
{
    public class ClienteService
    {
        public void createCliente(Cliente cliente)
        {
            ClienteRepository repo = new ClienteRepository();
            repo.Insert(cliente);
        }

        public Cliente getClienteByUsername(String usuario)
        {
            ClienteRepository repo = new ClienteRepository();
            return repo.getClienteByUsername(usuario);
        }


    }

}