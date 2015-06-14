﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class PaisRepository : BaseRepository<Pais>
    {

        public override IEnumerable<Pais> GetAll()
        {
            List<Pais> paises = new List<Pais>();

            SqlCommand command = DBConnection.CreateStoredProcedure("GetPaises");
            DataRowCollection collection = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            foreach (DataRow pais in collection)
            {
                Pais entity = this.CreatePais(pais);
                paises.Add(entity);
            }

            return paises;
        }

        public override Pais Get(int id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Pais entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Pais entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Pais entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> getByMayorIngresosEgresos(DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("PaisesConMayorIngresosEgresos");
            command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@fechaHasta", fechaHasta);

            DataRowCollection paises = DBConnection.EjecutarStoredProcedureSelect(command).Rows;
            List<Pais> listaPaises = new List<Pais>();

            foreach (DataRow unPais in paises)
            {
                Pais entity = new Pais();
                entity.codigoPais = Convert.ToInt64(unPais[0]);
                entity.descripcionPais = unPais[1].ToString();

                listaPaises.Add(entity);
            }

            return listaPaises;
        }

        private Pais CreatePais(DataRow reader)
        {
            Pais pais = new Pais();
            pais.codigoPais = Convert.ToInt64(reader["codigo_pais"]);
            pais.descripcionPais = reader["descripcion_pais"].ToString();

            return pais;
        }
    }
}