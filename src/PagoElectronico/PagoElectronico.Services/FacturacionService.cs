using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;
using System.Configuration;

namespace PagoElectronico.Services
{
    public class FacturacionService
    {
        public void Facturar(IList<ItemFactura> itemsAFacturar, Cliente cliente)
        {
            FacturacionRepository repo = new FacturacionRepository();
            using (var transaction = new TransactionScope())
            {
                Factura factura = new Factura
                {
                    clienteNumeroDoc = cliente.numeroDocumento,
                    clienteTipoDoc = cliente.tipoDocumento,
                    fecha = Session.Fecha
                };

                var nroFactura = repo.GenerarFactura(factura);
            }
        }
    }
}
