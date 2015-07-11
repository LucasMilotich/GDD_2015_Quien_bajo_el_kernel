using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;

namespace PagoElectronico.Services
{
    public class ClienteService
    {
        public void createCliente(Cliente cliente)
        {
            ClienteRepository repo = new ClienteRepository();
            repo.Insert(cliente);

        }

    }

}
