using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public class ListadoRepository
    {
        public DataTable getByMayorTransacciones(DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("ClientesConMayorTransacciones");
            command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@fechaHasta", fechaHasta);

            DataTable clientes = DBConnection.EjecutarStoredProcedureSelect(command);

            return clientes;
        }

        public DataTable getByMayorComisionesFacturadas(DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("ClientesComisionesFacturadas");
            command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@fechaHasta", fechaHasta);

            DataTable clientes = DBConnection.EjecutarStoredProcedureSelect(command);

            return clientes;
        }

        public DataTable getByCuentasInhabilitadas(DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("ClientesConCuentasInhabilitadas");
            command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@fechaHasta", fechaHasta);

            DataTable clientes = DBConnection.EjecutarStoredProcedureSelect(command);

            return clientes;
        }

        public DataTable getByMayorIngresosEgresos(DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("PaisesConMayorIngresosEgresos");
            command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@fechaHasta", fechaHasta);

            DataTable dt = DBConnection.EjecutarStoredProcedureSelect(command);

            return dt;
        }

        public DataTable getByTotalFacturado(DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlCommand command = DBConnection.CreateStoredProcedure("TotalFacturadoPorCuentas");
            command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            command.Parameters.AddWithValue("@fechaHasta", fechaHasta);

            DataTable dt = DBConnection.EjecutarStoredProcedureSelect(command);

            return dt;
        }

    }
}
