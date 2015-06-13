using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Services.Interfaces;
using PagoElectronico.Entities;
using PagoElectronico.Repositories;

namespace PagoElectronico.Services
{
    public class RolService : IRolService
    {
        public void crearRol(Rol rol) {

            RolRepository repo = new RolRepository();
            repo.Insert(rol);

        
        }


     

    }
}
