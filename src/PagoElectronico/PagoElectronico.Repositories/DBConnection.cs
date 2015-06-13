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
            int retorno;
            try
            {
                command.Connection.Open();
                retorno = Convert.ToInt32(command.ExecuteScalar());
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

            return retorno;
        }

        public static double ExecuteScalarDouble(SqlCommand command)
        {
            double retorno;
            try
            {
                command.Connection.Open();
                retorno = Convert.ToDouble(command.ExecuteScalar());
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

            return retorno;
        }

        public static long ExecuteScalarLong(SqlCommand command)
        {
            long retorno;
            try
            {
                command.Connection.Open();
                retorno = Convert.ToInt64(command.ExecuteScalar());
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

            return retorno;
        }

        public static string ExecuteScalarString(SqlCommand command)
        {
            string retorno;
            try
            {
                command.Connection.Open();
                retorno= command.ExecuteScalar().ToString();
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

            return retorno;
        }

        public static DataTable EjecutarComandoSelect(SqlCommand command)
        {
            SqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                reader.Close();
                CloseCommand(command);
            }

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
