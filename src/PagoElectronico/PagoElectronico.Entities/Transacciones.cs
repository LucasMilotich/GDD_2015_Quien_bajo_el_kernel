using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    class Transacciones
    {
        public long idTransaccion { get; set; }
        public long operacionTipo { get; set; }
        public DateTime fecha { get; set; }
    }
}
