using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using PagoElectronico.Repositories;
using PagoElectronico.Services.Interfaces;

namespace PagoElectronico.Services
{
    public class TransferenciaService
    {
        public int Save(Transferencia transferencia)
        {
            int id;

            var repository = new TransferenciaRepository();

            id = repository.Insert(transferencia);
  
            return id;
        }

    }
}
