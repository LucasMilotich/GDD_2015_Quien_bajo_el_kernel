using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    public class Rol
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public IList<Funcionalidad> Funcionalidades { get; set; }
    }
}
