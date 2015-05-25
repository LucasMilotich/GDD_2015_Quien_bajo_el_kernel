using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    public class Usuario
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string PreguntaSecreta { get; set; }

        public string RespuestaSecreta { get; set; }

        public IList<Rol> Roles { get; set; }
    }
}
