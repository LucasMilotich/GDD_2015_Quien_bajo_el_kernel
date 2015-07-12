<<<<<<< HEAD
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
=======
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
        public void createCliente(Cliente cliente)
        {
            ClienteRepository repo = new ClienteRepository();
            repo.Insert(cliente);

        }
    }
}
>>>>>>> 44308c990146fe0d0292da428add15f925ee16ac
