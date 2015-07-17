using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;
using System.Configuration;

namespace PagoElectronico.Services
{
    public class TransaccionService
    {
        public IEnumerable<Transaccion> getTransferenciasSinFacturar(long tipoDoc, long numeroDoc)
        {
            TransaccionRepository repo = new TransaccionRepository();
            return repo.getTransferenciasSinFacturar(tipoDoc, numeroDoc);
        }

        public IEnumerable<Transaccion> getModifCuentasSinFacturar(long tipoDoc, long numeroDoc)
        {
            TransaccionRepository repo = new TransaccionRepository();
            return repo.getModifCuentasSinFacturar(tipoDoc, numeroDoc);
        }

        public IEnumerable<Transaccion> getAperturaCuentasSinFacturar(long tipoDoc, long numeroDoc)
        {
            TransaccionRepository repo = new TransaccionRepository();
            return repo.getAperturaCuentasSinFacturar(tipoDoc, numeroDoc);
        }
        public int GetCountTransaccionesByCuenta(long cuenta)
        {
            TransaccionRepository repo = new TransaccionRepository();
            return repo.GetCountTransaccionesByCuenta(cuenta);
        }
    }
}
