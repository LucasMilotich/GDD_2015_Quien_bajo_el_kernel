using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;

namespace PagoElectronico.Services
{
    public class TipoTransaccionService
    {
        public IEnumerable<TipoTransaccion> GetAll()
        {
            TipoTransaccionRepository repo = new TipoTransaccionRepository();
            return repo.GetAll();
        }
    }
}
