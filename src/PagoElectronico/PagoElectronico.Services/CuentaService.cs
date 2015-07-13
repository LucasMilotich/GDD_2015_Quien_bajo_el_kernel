using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;
using System.Data;

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

        public int InsertaCuenta(int codPais, int tipoMoneda, int tipoCuenta, long tipoDocCliente, long nroDocCliente)
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.InsertaCuenta(codPais, tipoMoneda, tipoCuenta, tipoDocCliente, nroDocCliente);

        }

        public DataTable GetCuentas(long? pais, int? tipoEstado, int? moneda, int? tipoCuenta)
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.GetCuentas( pais, tipoEstado, moneda, tipoCuenta);
        }

        public Cuenta GetCuentaByNumero(long nroCuenta)
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.GetCuentaByNumero(nroCuenta);
        }

        public int ModificaCuenta(long numCuenta, int tipoMoneda, int tipoCuenta, int codPais)
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.ModificaCuenta(numCuenta, tipoMoneda, tipoCuenta, codPais);
        }

        public int CerrarCuenta(long numCuenta)
        {
            CuentaRepository repository = new CuentaRepository();
            return repository.CerrarCuenta(numCuenta);
        }
    }
}
