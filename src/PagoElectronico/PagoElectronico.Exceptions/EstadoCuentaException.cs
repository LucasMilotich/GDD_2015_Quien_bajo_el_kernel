using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Exceptions
{
    class EstadoCuentaException : Exception
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
