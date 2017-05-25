using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Zhangjp.WeixinFir.DbCommon
{
   public class DataAccessBase
    {

       private static string connstring = ConfigHelper.GetConnectionStrings("ConnectionString");

       public IDbConnection CreateDbConnection()
       {

           SqlConnection conn = new SqlConnection(connstring);
           conn.Open();
           return conn;
       }

    }
}
