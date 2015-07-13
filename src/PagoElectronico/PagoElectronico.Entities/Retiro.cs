using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    public class Retiro
    {
        public long codigo { get; set; }

        public DateTime fecha { get; set; }

        public double importe { get; set; }

        public long cuenta { get; set; }

        public long codigoCheque { get; set; }

        public Cheque cheque { get; set; }

    }
}
