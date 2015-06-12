using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Exceptions
{
    class SaldoCuentaException : Exception
    {
         public SaldoCuentaException()
        {
        }
         public SaldoCuentaException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
