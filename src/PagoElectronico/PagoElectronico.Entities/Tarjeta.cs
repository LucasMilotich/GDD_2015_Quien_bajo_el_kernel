using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace PagoElectronico.Entities
{
    public class Tarjeta
    {
        public string tarjetaNumero { get; set; }

        public DateTime fechaEmision { get; set; }

        public DateTime fechaVencimiento { get; set; }

        public string codigoSeguridad { get; set; }

        public int codEmisor { get; set; }

        public long tipoDoc { get; set; }

        public long nroDoc { get; set; }

        public byte[] numeroHashed  { get; set; }
       
        public Boolean habilitado { get; set; }
    }
}
