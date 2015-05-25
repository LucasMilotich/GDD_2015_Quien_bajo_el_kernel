using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;
using DAL.Repository;

namespace DAL.Business
{
    public class UsuarioManager
    {
        private UsuarioRepository usuarioRepository = new UsuarioRepository();

        public bool Alta(Usuario usuario)
        {
            return usuarioRepository.Alta(usuario);
        }
    }
}
