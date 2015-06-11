using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    class ItemFactura
    {
        public long numeroItem { get; set; }
        public string descripcion { get; set; }
        public double importe { get; set; }
        public long facturaNumero { get; set; }
        public long idTransaccion { get; set; }
    }
}
