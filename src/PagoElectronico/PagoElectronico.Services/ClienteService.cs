﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;

namespace PagoElectronico.Services
{
    public class ClienteService
    {
        public int  createCliente(Cliente cliente)
        {
            ClienteRepository repo = new ClienteRepository();
            return repo.Insert(cliente);

        }
    }
}
