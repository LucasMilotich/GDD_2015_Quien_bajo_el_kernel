using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using PagoElectronico.Repositories;

namespace PagoElectronico.Services
{
    public class FuncionalidadService
    {
        public IEnumerable<Funcionalidad> GetAll()
        {
            FuncionalidadRepository repo = new FuncionalidadRepository();
            return repo.GetAll();
        }

        public IEnumerable<Funcionalidad> GetByRolId(int rolId)
        {
            FuncionalidadRepository repo = new FuncionalidadRepository();
            return repo.GetByRolId(rolId);
        }
    }
}
