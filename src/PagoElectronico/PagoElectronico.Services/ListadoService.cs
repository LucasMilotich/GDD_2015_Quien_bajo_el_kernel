using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PagoElectronico.Repositories;

namespace PagoElectronico.Services
{
    public class ListadoService
    {
        public DataTable getByMayorTransacciones(DateTime fechaDesde, DateTime fechaHasta)
        {
            ListadoRepository listadoRepo = new ListadoRepository();
            return listadoRepo.getByMayorTransacciones(fechaDesde, fechaHasta);
        }

        public DataTable getByMayorComisionesFacturadas(DateTime fechaDesde, DateTime fechaHasta)
        {
            ListadoRepository listadoRepo = new ListadoRepository();
            return listadoRepo.getByMayorComisionesFacturadas(fechaDesde, fechaHasta);
        }

        public DataTable getByCuentasInhabilitadas(DateTime fechaDesde, DateTime fechaHasta)
        {
            ListadoRepository listadoRepo = new ListadoRepository();
            return listadoRepo.getByCuentasInhabilitadas(fechaDesde, fechaHasta);
        }

        public DataTable getByMayorIngresosEgresos(DateTime fechaDesde, DateTime fechaHasta)
        {
            ListadoRepository listadoRepo = new ListadoRepository();
            return listadoRepo.getByMayorIngresosEgresos(fechaDesde, fechaHasta);
        }

        public DataTable getByTotalFacturado(DateTime fechaDesde, DateTime fechaHasta)
        {
            ListadoRepository listadoRepo = new ListadoRepository();
            return listadoRepo.getByTotalFacturado(fechaDesde, fechaHasta);
        }

    }
}
