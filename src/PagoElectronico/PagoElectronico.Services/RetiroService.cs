using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using PagoElectronico.Repositories;

namespace PagoElectronico.Services
{
    public class RetiroService
    {
        public IEnumerable<Retiro> getUltimosCincoRetirosByCuenta(string cuenta)
        {
            RetiroRepository retiroRepo = new RetiroRepository();
            return retiroRepo.getUltimosCincoRetirosByCuenta(cuenta);
        }
    }
}
