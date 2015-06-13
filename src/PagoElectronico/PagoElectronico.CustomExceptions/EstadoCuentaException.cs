using System;
using System.Collections.Generic;
using System.Text;

namespace PagoElectronico.CustomExceptions
{
    public class EstadoCuentaException : Exception
    {
         public EstadoCuentaException()
        {
        }
         public EstadoCuentaException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
