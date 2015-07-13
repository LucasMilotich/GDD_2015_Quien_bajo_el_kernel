using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    public class Cliente
    {
        public long tipoDocumento { get; set; }

        public long numeroDocumento { get; set; }

        public long paisCodigo { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string domCalle { get; set; }

        public long domNro { get; set; }

        public long domPiso { get; set; }

        public string domDpto { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public string mail { get; set; }


        public string localidad { get; set; }
 
        public string username { get; set; }
        
    }
}
