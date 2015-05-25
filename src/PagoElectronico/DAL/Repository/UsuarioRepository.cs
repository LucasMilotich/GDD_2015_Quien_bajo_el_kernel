using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Repository
{
    public class UsuarioRepository : DataAccess
    {
        public bool Alta(Usuario usuario)
        {
            SqlTransaction trans = con.BeginTransaction();
            bool result = true;
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {       new SqlParameter("@USERNAME", usuario.Username),
                        new SqlParameter("@PASSWORD", usuario),
                        new SqlParameter("@PREGUNTA_SECRETA", usuario.PreguntaSecreta),
                        new SqlParameter("@RESPUESTA_SECRETA", usuario.RespuestaSecreta)
                };

                result = base.ExecuteNonQuery("AltaUsuario", CommandType.StoredProcedure, parameters);

                foreach (var rol in usuario.Roles)
                {
                    parameters = new SqlParameter[]
                        {       new SqlParameter("@USERNAME", usuario.Username),
                                new SqlParameter("@ID_ROL", rol.Id)
                        };

                    result = result && base.ExecuteNonQuery("AltaUsuarioRol", CommandType.StoredProcedure, parameters);
                }

                if (result)
                {
                    trans.Commit();
                }
            }
            catch
            {
                trans.Rollback();
            }

            return result;
        }
    }
}
