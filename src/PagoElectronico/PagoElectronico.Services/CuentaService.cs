using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;

namespace PagoElectronico.Services
{
    public class CuentaService
    {
        public IEnumerable<long> getByCliente(long tipoDocCliente, long nroDocCliente)
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.getByCliente(tipoDocCliente, nroDocCliente);
        }

        public double getSaldo(long numeroCuenta)
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.getSaldo(numeroCuenta);
        }

        public int getEstado(long numeroCuenta)
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.getEstado(numeroCuenta);
        }

    }
}
