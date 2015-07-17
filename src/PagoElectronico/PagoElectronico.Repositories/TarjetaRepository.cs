using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class TarjetaRepository : BaseRepository<Tarjeta>
    {
        public IEnumerable<Tarjeta> getAllByCliente(long tipoDoc, long numeroDoc)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("GetAllByCliente");
            command.Parameters.AddWithValue("@tipoDoc", tipoDoc);
            command.Parameters.AddWithValue("@numeroDoc", numeroDoc);

            List<Tarjeta> tarjetas = new List<Tarjeta>();
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow tarjeta in collection)
            {
                Tarjeta entity = this.CreateTarjeta(tarjeta);
                tarjetas.Add(entity);
            }

            return tarjetas;
        }

        private Tarjeta CreateTarjeta(DataRow tarjeta)
        {
            Tarjeta entity = new Tarjeta();
            entity.tarjetaNumero = Convert.ToString(tarjeta["tarjeta_numero"]);
            entity.fechaEmision = Convert.ToDateTime(tarjeta["fecha_emision"]);
            entity.fechaVencimiento = Convert.ToDateTime(tarjeta["fecha_vencimiento"]);
            entity.codigoSeguridad = Convert.ToString(tarjeta["codigo_seguridad"]);
            entity.codEmisor = Convert.ToInt32(tarjeta["cod_emisor"]);
            entity.tipoDoc = Convert.ToInt64(tarjeta["cliente_tipo_doc"]);
            entity.nroDoc = Convert.ToInt64(tarjeta["cliente_numero_doc"]);

            return entity;
        }

        public override IEnumerable<Tarjeta> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Tarjeta Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Tarjeta entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Tarjeta entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Tarjeta entity)
        {
            throw new NotImplementedException();
        }
    }
}
