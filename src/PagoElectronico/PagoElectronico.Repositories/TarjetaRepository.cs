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
            entity.habilitado = Convert.ToBoolean(tarjeta["habilitado"]);

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
            SqlCommand command = DBConnection.CreateStoredProcedure("INSERT_TARJETA");
            command.Parameters.AddWithValue("@tarjetaNumero", entity.tarjetaNumero.ToString());
            command.Parameters.AddWithValue("@fecha_emision", entity.fechaEmision);
            command.Parameters.AddWithValue("@fecha_vencimiento", entity.fechaVencimiento);
            command.Parameters.AddWithValue("@codigo_seguridad", entity.codigoSeguridad);
            command.Parameters.AddWithValue("@cod_emisor", entity.codEmisor);
            command.Parameters.AddWithValue("@cliente_tipo_doc", entity.tipoDoc);
            command.Parameters.AddWithValue("@cliente_numero_doc", entity.nroDoc);
            return DBConnection.ExecuteNonQuery(command);
        }

        public override void Update(Tarjeta entity)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("UPDATE_TARJETA");
            command.Parameters.AddWithValue("@tarjetaNumero", entity.tarjetaNumero.ToString());
            command.Parameters.AddWithValue("@fecha_emision", entity.fechaEmision);
            command.Parameters.AddWithValue("@fecha_vencimiento", entity.fechaVencimiento);
            command.Parameters.AddWithValue("@codigo_seguridad", entity.codigoSeguridad);
            command.Parameters.AddWithValue("@cod_emisor", entity.codEmisor);
            command.Parameters.AddWithValue("@cliente_tipo_doc", entity.tipoDoc);
            command.Parameters.AddWithValue("@cliente_numero_doc", entity.nroDoc);
            DBConnection.ExecuteNonQuery(command);
        }

        public override void Delete(Tarjeta entity)
        {
            throw new NotImplementedException();
        }

        public void desasociarTarjeta(long tarjetaNumero)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("Desasociar_Tarjeta");
            command.Parameters.AddWithValue("@tarjetaNumero", tarjetaNumero.ToString());
            DBConnection.ExecuteNonQuery(command);

        }

        public Boolean NumeroTarjetaDisponible(string nroTarjeta)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("GetTarjetaByNumeroTarjeta");
            command.Parameters.AddWithValue("@tarjetaNumero", nroTarjeta.ToString());

            if (DBConnection.EjecutarStoredProcedureSelect(command).Rows.Count > 0)
                return false;
            else
                return true;
        }

        public Boolean NumeroTarjetaFueDesasociada(string nroTarjeta, long tipoDoc, long nroDoc)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("GetTarjetaDesasociada");
            command.Parameters.AddWithValue("@tarjetaNumero", nroTarjeta.ToString());
            command.Parameters.AddWithValue("@tipoDoc", tipoDoc);
            command.Parameters.AddWithValue("@nroDoc", nroDoc);

            if (DBConnection.EjecutarStoredProcedureSelect(command).Rows.Count > 0)
                return true;
            else
                return false;          
            
        }
    }
}
