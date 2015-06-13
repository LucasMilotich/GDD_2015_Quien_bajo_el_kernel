using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    public class CuentaModificacion
    {
        public long cuenta { get; set; }
        public long transaccion { get; set; }
        public DateTime fecha { get; set; }
    }
}
