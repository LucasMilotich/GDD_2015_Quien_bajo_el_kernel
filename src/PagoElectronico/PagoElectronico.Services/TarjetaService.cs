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


    }
}
