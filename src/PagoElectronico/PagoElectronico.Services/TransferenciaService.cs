using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using PagoElectronico.Repositories;


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

        public IEnumerable<Transferencia> getUltimasDiezTransferenciasByCuenta(string cuenta)
        {
            TransferenciaRepository transferenciaRepo = new TransferenciaRepository();
            return transferenciaRepo.getUltimasDiezTransferenciasByCuenta(cuenta);
        }

    }
}
