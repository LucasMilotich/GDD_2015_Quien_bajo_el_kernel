using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;

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

        public int getMonedaTipo(long numeroCuenta)
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.getMonedaTipo(numeroCuenta);
        }

        public IEnumerable<TipoCuenta> GetTiposCuenta()
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.getTiposCuenta();
        }

        public long GetMaxNroCuenta()
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.GetMaxNroCuenta();
        }

        public int InsertaCuenta(long numeroCuenta, int codPais, int tipoMoneda, int tipoCuenta, long tipoDocCliente, long nroDocCliente)
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.InsertaCuenta(numeroCuenta, codPais, tipoMoneda, tipoCuenta, tipoDocCliente, nroDocCliente);

        }
    }
}
