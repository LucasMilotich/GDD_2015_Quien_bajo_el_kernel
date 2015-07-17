using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Repositories;
using System.Security.Cryptography;
using PagoElectronico.Entities;
using PagoElectronico.Services.Interfaces;

namespace PagoElectronico.Services
{
    public class UsuarioService : IUsuarioService
    {
        public int insert(Usuario usuario)
        {
            UsuarioRepository usrRep = new UsuarioRepository();
            return usrRep.Insert(usuario);
        }

        public int insertRolesUsuario(Usuario usuario)
        {
            UsuarioRepository usrRep = new UsuarioRepository();
            return usrRep.InsertRolesUsuario(usuario);
        }

        public bool existeUsername(string username)
        {
            UsuarioRepository usrRep = new UsuarioRepository();
            return usrRep.existeUsername(username);
        }

    }
}
