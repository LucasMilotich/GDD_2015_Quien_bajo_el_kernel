using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Entities.Exceptions
{
    public class FormException : Exception
    {
        public FormException(string message)
            : base(message)
        {
        }
    }
}
