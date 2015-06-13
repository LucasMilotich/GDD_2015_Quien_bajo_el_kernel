using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.Repositories
{
    public static class DBConnection
    {
        private static string connectionString = ConfigurationSettings.AppSettings["ConnectionString"];

        public static string ConnectionString
        {
            get { return connectionString; }
        }

        public static SqlCommand CreateCommand()
        {
            string conn = ConnectionString;

            SqlConnection conexion = new SqlConnection(conn);

            SqlCommand command = conexion.CreateCommand();
            command.CommandType = CommandType.Text;

            return command;
        }

        public static SqlCommand CreateStoredProcedure(string storedName)
        {
            SqlConnection conexion = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand(string.Format("[GD1C2015].[QUIEN_BAJO_EL_KERNEL].[{0}]", storedName), conexion);
            command.CommandType = CommandType.StoredProcedure;


            return command;
        }

        public static int ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
        }

        public static int ExecuteScalar(SqlCommand command)
        {
            try
            {
                int retorno;
                command.Connection.Open();
                retorno = Convert.ToInt32(command.ExecuteScalar());

                command.Connection.Close();
                command.Connection.Dispose();
                return retorno;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static double ExecuteScalarDouble(SqlCommand command)
        {
            try
            {
                double retorno;
                command.Connection.Open();
                retorno= Convert.ToDouble(command.ExecuteScalar());

                command.Connection.Close();
                command.Connection.Dispose();
                return retorno;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static long ExecuteScalarLong(SqlCommand command)
        {
            try
            {
                long retorno;
                command.Connection.Open();
                retorno = Convert.ToInt64(command.ExecuteScalar());

                command.Connection.Close();
                command.Connection.Dispose();
                return retorno;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static string ExecuteScalarString(SqlCommand command)
        {
            try
            {
                string retorno;
                command.Connection.Open();
                retorno= command.ExecuteScalar().ToString();

                command.Connection.Close();
                command.Connection.Dispose();

                return retorno;
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public static DataTable EjecutarComandoSelect(SqlCommand command)
        {
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            CloseCommand(command);

            return dt;
        }

        public static DataTable EjecutarStoredProcedureSelect(SqlCommand command)
        {
            var table = new DataTable();

            try
            {
                command.Connection.Open();

                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                table = dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                CloseCommand(command);
            }

            return table;
        }

        public static void CloseCommand(SqlCommand command)
        {
            command.Connection.Close();
            command.Connection.Dispose();
            command.Dispose();
        }
    }
}
