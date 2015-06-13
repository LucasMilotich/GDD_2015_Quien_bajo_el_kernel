using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    public class Cuenta
    {
        public long numero { get; set; }

        public DateTime fechaCreacion { get; set; }

        public int estadoCodigo { get; set; }

        public long paisCodigo { get; set; }

        public DateTime fechaCierre { get; set; }

        public long tipoDoc { get; set; }

        public long nroDoc { get; set; }

        public int monedaTipo { get; set; }

        public int tipoCuenta { get; set; }

        public long idTransaccion { get; set; }

        public double saldo { get; set; }
    }
}
