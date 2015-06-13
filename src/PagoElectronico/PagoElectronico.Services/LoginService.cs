using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Services.Interfaces;
using PagoElectronico.Repositories;
using System.Security.Cryptography;
using PagoElectronico.Entities;

namespace PagoElectronico.Services
{
    public class LoginService : ILoginService
    {
        public Usuario Login(string username, string password)
        {
            var usuariosRepository = new UsuarioRepository();
            return usuariosRepository.GetByUsernameAndPassword(username, this.HashPassword(password));
        }

        private byte[] HashPassword(string password)
        {
            return SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
