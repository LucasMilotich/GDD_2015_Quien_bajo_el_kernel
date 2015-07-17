using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    public class Deposito
    {
        public long depositoCodigo { get; set; }

        public DateTime fecha { get; set; }

        public double importe { get; set; }

        public long cuentaNumero { get; set; }

        public int monedaTipo { get; set; }

        public string tarjetaNumero { get; set; }

        public string codigoSeguridad { get; set; }

    }
}
