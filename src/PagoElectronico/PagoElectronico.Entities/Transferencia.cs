using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    public class Transferencia
    {
        public long codigo { get; set; }

        public long origen { get; set; }

        public long destino { get; set; }

        public DateTime fecha { get; set; } 

        public double importe { get; set; }

        public double costo { get; set; }

        public int monedaTipo { get; set; }

        public long idTransaccion { get; set; }

    }
}
