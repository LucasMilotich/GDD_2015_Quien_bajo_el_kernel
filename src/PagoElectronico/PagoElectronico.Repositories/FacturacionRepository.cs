using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class FacturacionRepository : BaseRepository<Factura>
    {
        public long GenerarFactura(Factura factura)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("GenerarFactura");

            command.Parameters.AddWithValue("@cliente_numero_doc", factura.clienteNumeroDoc);
            command.Parameters.AddWithValue("@cliente_tipo_doc", factura.clienteTipoDoc);
            command.Parameters.AddWithValue("@fecha", factura.fecha);

            return DBConnection.ExecuteScalar(command);
        }

        private Factura CreateFactura(DataRow factura)
        {
            Factura entity = new Factura();
            //entity.codigo = Convert.ToInt64(transaccion["Codigo"]);
            //entity.codigo = String.IsNullOrEmpty(factura["Codigo"].ToString()) ? Convert.ToInt64(factura["Cuenta"]) : Convert.ToInt64(transaccion["Codigo"]);
            //entity.cuenta = Convert.ToInt64(factura["Cuenta"]);
            //entity.costo = Convert.ToDouble(factura["Costo"]);
            //entity.tipo = Convert.ToInt32(factura["TipoTransaccion"]);
            return entity;
        }

        public override IEnumerable<Factura> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Factura Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Factura entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Factura entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Factura entity)
        {
            throw new NotImplementedException();
        }
    }
}
