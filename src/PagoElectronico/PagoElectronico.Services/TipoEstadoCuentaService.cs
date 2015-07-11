using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;
using System.Data;

namespace PagoElectronico.Services
{
    public class TipoEstadoCuentaService
    {
        public IEnumerable<TipoEstadoCuenta> GetAll()
        {
            TipoEstadoCuentaRepository tipoEstadoCuentaRepo = new TipoEstadoCuentaRepository();
            return tipoEstadoCuentaRepo.GetAll().ToList();
        }

    }
}
