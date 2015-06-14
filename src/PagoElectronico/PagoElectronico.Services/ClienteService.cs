using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;

namespace PagoElectronico.Services
{
    public class ClienteService
    {
        public IEnumerable<Cliente> getByMayorIngresosEgresos(DateTime fechaDesde, DateTime fechaHasta)
        {
            ClienteRepository clienteRepo = new ClienteRepository();
            return clienteRepo.getByMayorTransacciones(fechaDesde, fechaHasta);
        }
    }

}
