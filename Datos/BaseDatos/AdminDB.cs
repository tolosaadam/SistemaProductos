using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos.BaseDatos
{
    internal static class AdminDB
    {
        internal static SqlConnection ConectarDB()
        {
            string cadena = Properties.Settings.Default.keyDBProductos;
            SqlConnection connection = new SqlConnection(cadena);
            connection.Open();
            return connection;
        }
    }
}
