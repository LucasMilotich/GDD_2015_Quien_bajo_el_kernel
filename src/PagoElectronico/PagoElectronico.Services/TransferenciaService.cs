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
            int filasInsertadas;

            var repository = new TransferenciaRepository();
            filasInsertadas = repository.Insert(transferencia);

            return filasInsertadas;
        }

    }
}
