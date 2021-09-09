using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICRUD_Productos.DataBase
{
    public class AccesoDB
    {
        public static SqlConnection getConnection()
        {
            try
            {
                string cadena = ConfigurationManager.ConnectionStrings["MY_CONNECTION"].ConnectionString;
                SqlConnection cn = new SqlConnection(cadena);
                return cn;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}

