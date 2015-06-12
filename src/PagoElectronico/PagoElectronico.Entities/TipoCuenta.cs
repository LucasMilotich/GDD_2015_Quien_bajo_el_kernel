using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    public class TipoCuenta
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public long duracion { get; set; }
        public double costo { get; set; }
    }
}
