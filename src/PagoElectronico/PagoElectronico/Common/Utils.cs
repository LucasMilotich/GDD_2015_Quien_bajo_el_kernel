using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using PagoElectronico.Services;
using System.Windows.Forms;

namespace PagoElectronico.Common
{
    public class Utils
    {


        public static Cliente obtenerCliente(Usuario usuarioLogueado)
        {
            ClienteService clienteService = new ClienteService();
            try
            {
               return clienteService.getClienteByUsername(usuarioLogueado.Username);               
            }
            catch (Exception)
            {
                throw new Exception ("El usuario actual no posee algun cliente asociado");
            }
        }

    }
}
