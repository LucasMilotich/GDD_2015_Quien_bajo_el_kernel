using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    class Factura
    {
        public long numero { get; set; }

        public DateTime fecha { get; set; }

        public long clienteNumeroDoc { get; set; }

        public long clienteTipoDoc { get; set; }

    }
}
