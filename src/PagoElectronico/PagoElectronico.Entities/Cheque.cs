using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    class Cheque
    {
        public long numero { get; set; }

        public DateTime fecha { get; set; }

        public double importe { get; set; }

        public long codigoBanco { get; set; }

        public int monedaTipo { get; set; }

        public string nombreDestinatario { get; set; }

    }
}
