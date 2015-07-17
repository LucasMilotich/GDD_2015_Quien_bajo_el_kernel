using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;

namespace PagoElectronico.Services
{
    public class TarjetaService
    {
        public IEnumerable<Tarjeta> getAllByCliente(long tipoDoc, long numeroDoc)
        {
            TarjetaRepository repo = new TarjetaRepository();
            return repo.getAllByCliente(tipoDoc, numeroDoc);            
        }


        public void desasociarTarjeta(long tarjetaNumero)
        {
            TarjetaRepository repo = new TarjetaRepository();
            repo.desasociarTarjeta(tarjetaNumero); 
        }

        public void insertarTarjeta(Tarjeta tarjeta)
        {
            TarjetaRepository repo = new TarjetaRepository();
            repo.Insert(tarjeta);
        }


        public void updateTarjeta(Tarjeta tarjeta)
        {
            TarjetaRepository repo = new TarjetaRepository();
            repo.Update(tarjeta);
        }

        public bool NumeroTarjetaDisponible(String nroTarjeta)
        {
            TarjetaRepository repo = new TarjetaRepository();
            return repo.NumeroTarjetaDisponible(nroTarjeta);
        }

        public bool NumeroTarjetaFueDesasociada(String nroTarjeta, long tipoDoc, long nroDoc)
        {
            TarjetaRepository repo = new TarjetaRepository();
            return repo.NumeroTarjetaFueDesasociada(nroTarjeta, tipoDoc, nroDoc);
        }
    }
}
