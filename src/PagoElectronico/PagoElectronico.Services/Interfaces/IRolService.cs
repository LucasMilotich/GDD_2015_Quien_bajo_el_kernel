using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;

namespace PagoElectronico.Services.Interfaces
{
    public class IRolService
    {
        Rol Get(int idRol);

        int Save(Rol rol);

        void Delete(Rol rol);

    }
}
