using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace PagoElectronico.Entities
{
    public class Usuario
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string PreguntaSecreta { get; set; }

        public string RespuestaSecreta { get; set; }

        public bool Activo { get; set; }

        public IList<Rol> Roles { get; set; }

        public Rol SelectedRol { get; set; }

        public byte[] HashedPassword
        {
            get
            {
                return SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(this.Password));
            }            
        }
    }
}
