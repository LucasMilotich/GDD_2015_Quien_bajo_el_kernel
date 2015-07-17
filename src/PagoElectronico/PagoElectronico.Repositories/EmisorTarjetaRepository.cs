using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;


namespace PagoElectronico.Repositories
{
    public class EmisorTarjetaRepository : BaseRepository<EmisorTarjeta>
    {

        public override IEnumerable<EmisorTarjeta> GetAll()
        {
            {
                List<EmisorTarjeta> EmisorTarjetaList = new List<EmisorTarjeta>();

                SqlCommand command = DBConnection.CreateStoredProcedure("GetEmisoresTarjeta");
                DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
                foreach (DataRow row in collection)
                {
                    EmisorTarjeta emisorTarjeta = new EmisorTarjeta();
                    emisorTarjeta.ID = Convert.ToInt32(row[0]);
                    emisorTarjeta.descripcion = row[1].ToString();
                    EmisorTarjetaList.Add(emisorTarjeta);
                }

                return EmisorTarjetaList;
            }
        }

        public override EmisorTarjeta Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(EmisorTarjeta entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(EmisorTarjeta entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(EmisorTarjeta entity)
        {
            throw new NotImplementedException();
        }
    }
}
