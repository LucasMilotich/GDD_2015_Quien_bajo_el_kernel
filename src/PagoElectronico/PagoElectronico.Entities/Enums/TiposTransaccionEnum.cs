using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PagoElectronico.Entities.Enums
{
    public enum TiposTransaccionEnum
    {
        [Description("Apertura de Cuenta")]
        AperturaCuenta = 1,
        [Description("Modificación de Cuenta")]
        ModifCuenta = 2,
        [Description("Comisión por Transferencia")]
        Transferencia =3
    };
}
