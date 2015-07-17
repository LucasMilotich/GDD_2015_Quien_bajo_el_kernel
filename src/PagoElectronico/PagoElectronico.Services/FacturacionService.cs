using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using PagoElectronico.Repositories;
using PagoElectronico.Entities;
using System.Configuration;
using PagoElectronico.Entities.Enums;

namespace PagoElectronico.Services
{
    public class FacturacionService
    {
        public long Facturar(IList<ItemFactura> itemsAFacturar, Cliente cliente)
        {
            long nroFactura;
            FacturacionRepository repo = new FacturacionRepository();
            TransaccionRepository repoTrans = new TransaccionRepository();
            using (var transaction = new TransactionScope())
            {
                Factura factura = new Factura
                {
                    clienteNumeroDoc = cliente.numeroDocumento,
                    clienteTipoDoc = cliente.tipoDocumento,
                    fecha = Session.Fecha
                };

                nroFactura = repo.GenerarFactura(factura);

                itemsAFacturar.ToList().ForEach(i => i.facturaNumero = nroFactura);
                var itemsTransferencia = itemsAFacturar.Where(i => (TiposTransaccionEnum)i.tipo == TiposTransaccionEnum.Transferencia).ToList();
                if (itemsTransferencia.Any())
	            {
                    repo.AgregarItemsTransferencia(itemsTransferencia);
	            }
                var itemsApertura = itemsAFacturar.Where(i => (TiposTransaccionEnum)i.tipo == TiposTransaccionEnum.AperturaCuenta).ToList();
                if (itemsApertura.Any())
                {
                    repo.AgregarItemsApertura(itemsApertura);
                }
                var itemsModificacion = itemsAFacturar.Where(i => (TiposTransaccionEnum)i.tipo == TiposTransaccionEnum.ModifCuenta).ToList();
                if (itemsModificacion.Any())
                {
                    repo.AgregarItemsModificacion(itemsModificacion);
                }

                var cuentas = itemsAFacturar.Select(i => i.cuenta).Distinct().ToList();
                cuentas.ForEach(repoTrans.ValidarCantidadTransacciones);

                transaction.Complete();
                transaction.Dispose();
            }

            return nroFactura;
        }
    }
}
