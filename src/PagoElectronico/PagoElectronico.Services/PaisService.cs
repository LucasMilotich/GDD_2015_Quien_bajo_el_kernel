using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;
using System.Data;

namespace PagoElectronico.Services
{
    public class PaisService
    {
        public IEnumerable<Pais> GetAll()
        {
            PaisRepository paisRepo = new PaisRepository();
            return paisRepo.GetAll().ToList();
        }

    }
}
