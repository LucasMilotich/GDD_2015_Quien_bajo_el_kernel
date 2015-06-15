using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;

namespace PagoElectronico.Services
{
    public class TipoMonedaService
    {
        public IEnumerable<TipoMoneda> GetAll()
        {
            TipoMonedaRepository tipoMonedaRepo = new TipoMonedaRepository();
            return tipoMonedaRepo.GetAll();
        }

        public IEnumerable<TipoMoneda> GetTiposMonedaByCuenta(string cuenta)
        {
            TipoMonedaRepository tipoMonedaRepo = new TipoMonedaRepository();
            return tipoMonedaRepo.GetTiposMonedaByCuenta(cuenta);
        }
    }
}
