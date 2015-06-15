using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;

namespace PagoElectronico.Services
{
    public class DepositoService
    {
        public IEnumerable<Deposito> getUltimosCincoDepositosByCuenta(string cuenta)
        {
            DepositoRepository depositoRepo = new DepositoRepository();
            return depositoRepo.getUltimosCincoDepositosByCuenta(cuenta);
        }

    }
}
