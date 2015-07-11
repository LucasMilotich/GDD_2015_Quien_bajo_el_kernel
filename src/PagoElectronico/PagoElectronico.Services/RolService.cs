using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Services.Interfaces;
using PagoElectronico.Entities;
using PagoElectronico.Repositories;

namespace PagoElectronico.Services
{
    public class RolService : IRolService
    {
        public int crearRol(Rol rol) {

            RolRepository repo = new RolRepository();
           return repo.Insert(rol);

        
        }

        public IList<Funcionalidad> Getfunciones() {

            FuncionalidadRepository repo = new FuncionalidadRepository();
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            funcionalidades = (List<Funcionalidad>) repo.GetAll();

            return funcionalidades;
        }

        public List<Rol> getRoles(String nombre, bool activo)
        {

            RolRepository repo = new RolRepository();
            return repo.getRoles(nombre, activo);
            

        }


        public Rol getRolByID(int id)
        {   
            Rol rol;
            RolRepository repo = new RolRepository();
            rol =  repo.getRolById(id);
            return rol;
        }

     

    }
}
