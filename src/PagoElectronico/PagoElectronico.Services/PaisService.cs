using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;

namespace PagoElectronico.Services
{
    public class PaisService
    {
        public IEnumerable<Pais> getByMayorIngresosEgresos(DateTime fechaDesde, DateTime fechaHasta)
        {
            PaisRepository paisRepo = new PaisRepository();
            return paisRepo.getByMayorIngresosEgresos(fechaDesde, fechaHasta);
        }

        public IEnumerable<Pais> GetAll()
        {
            PaisRepository paisRepo = new PaisRepository();
            return paisRepo.GetAll().ToList();
        }

    }
}
