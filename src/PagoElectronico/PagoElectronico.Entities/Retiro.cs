using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    class Retiro
    {
        public long codigo { get; set; }

        public DateTime fecha { get; set; }

        public double importe { get; set; }

        public long cuenta { get; set; }

        public long cheque { get; set; }

    }
}
