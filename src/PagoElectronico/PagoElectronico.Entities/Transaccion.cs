using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    public class Transaccion
    {
        public long codigo { get; set; }
        public double costo { get; set; }
        public string tipo { get; set; }
    }
}
