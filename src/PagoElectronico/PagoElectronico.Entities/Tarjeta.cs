﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities
{
    class Tarjeta
    {
        public string tarjetaNumero { get; set; }
        public DateTime fechaEmision { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string codigoSeguridad { get; set; }
        public string emisorDescripcion { get; set; }
    }
}