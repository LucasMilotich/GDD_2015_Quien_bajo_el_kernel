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
        public Usuario Get(int idUsuario)
        {
            var repository = new UsuarioRepository();
            return repository.Get(idUsuario);
        }

        public int Save(Usuario usuario)
        {
            int id = usuario.Id;

            var repository = new UsuarioRepository();

            if (usuario.IsNew())
            {
                id = repository.Insert(usuario);
            }
            else
            {
                repository.Update(usuario);
            }

            return id;
        }

        public void Delete(Usuario usuario)
        {
            var repository = new UsuarioRepository();
            repository.Delete(usuario);
        }

        public IEnumerable<Usuario> GetAll(string username, string nombre, string apellido, int? tipoDocumentoId, string numeroDocumento, string mail, string telefono, string direccion, DateTime? fechaNacimiento, int? rolId)
        {
            var usuariosDTO = new List<Usuario>();

        //    var repository = new UsuarioRepository();
        //    IEnumerable<Usuario> usuarios = repository.GetAll(username, nombre, apellido, tipoDocumentoId, numeroDocumento, mail, telefono, direccion, fechaNacimiento, rolId);

        //    foreach (Usuario usuario in usuarios)
        //    {
        //        usuariosDTO.Add(new UsuarioDTO
        //        {
        //            Apellido = usuario.Apellido,
        //            Direccion = usuario.Direccion.Calle,
        //            FechaNacimiento = usuario.FechaNacimiento.HasValue ? usuario.FechaNacimiento.Value.ToShortDateString() : string.Empty,
        //            Id = usuario.Id,
        //            Mail = usuario.Mail,
        //            Modificar = "Modificar",
        //            Nombre = usuario.Nombre,
        //            NumeroDocumento = usuario.NumeroDocumento,
        //            Telefono = usuario.Telefono,
        //            TipoDocumento = usuario.TipoDocumento != null ? usuario.TipoDocumento.Nombre : string.Empty,
        //            Username = usuario.Username,
        //            Habilitado = usuario.Habilitado
        //        });
        //    }

            return usuariosDTO;
        }

        public bool IsValidUserName(string userName)
        {
            var repository = new UsuarioRepository();
            return repository.IsValidUserName(userName);
        }
    }
}
