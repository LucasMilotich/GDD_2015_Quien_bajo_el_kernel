using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public interface IDataAccess
    {
        DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType);

        DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, SqlParameter[] param);

        bool ExecuteNonQuery(string CommandName, CommandType cmdType, SqlParameter[] pars);
    }
}
