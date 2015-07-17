using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PagoElectronico.Entities
{
    public static class Session
    {
        public static Usuario Usuario { get; set; }

        public static DateTime Fecha { 
            get
            {
                return Convert.ToDateTime(ConfigurationSettings.AppSettings["Fecha"]);
            } 
        }
    }
}
