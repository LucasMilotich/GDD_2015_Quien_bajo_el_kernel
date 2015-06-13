using System;
using System.Collections.Generic;
using System.Text;


namespace PagoElectronico.CustomExceptions
{
    public class SaldoCuentaException : Exception
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
