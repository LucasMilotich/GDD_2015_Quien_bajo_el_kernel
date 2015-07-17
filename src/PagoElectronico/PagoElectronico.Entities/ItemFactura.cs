using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    public class ItemFactura
    {
        public long numeroItem { get; set; }
        public int tipo { get; set; }
        public string descripcion { get; set; }
        public double importe { get; set; }
        public long facturaNumero { get; set; }
        public long cuenta { get; set; }
        public int suscripcion { get; set; }
        public DateTime fecha { get; set; }
        public bool actualizarCuenta { get; set; }
    }
}
