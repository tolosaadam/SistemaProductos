using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;
using Datos.BaseDatos;

namespace Datos
{
    public static class DACCategoria
    {
        public static List<Categoria> CmdSelect()
        {
            DataSet ds = new DataSet();
            string query = "SELECT Id,Nombre FROM dbo.Categoria";
            SqlDataAdapter adapter = new SqlDataAdapter(query, AdminDB.ConectarDB());
            adapter.Fill(ds, "Categoria");

            List<Categoria> lista = new List<Categoria>();
            foreach(DataRow auxCategoria in ds.Tables["Categoria"].Rows)
            {
                lista.Add(new Categoria(auxCategoria["Nombre"].ToString(), Convert.ToInt32(auxCategoria["Id"])));
            }

            return lista;
        }
        public static int CmdInsert(Categoria categoria)
        {
            string query = "INSERT INTO dbo.Categoria (Nombre) VALUES (@Nombre); SELECT SCOPE_IDENTITY()"; 

            SqlCommand command = new SqlCommand(query, AdminDB.ConectarDB());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = categoria.Nombre;

            object filasAfectadas = command.ExecuteScalar(); //Invocar: inser into-update-delete

            //Cerrar connecion de la DB
            AdminDB.ConectarDB().Close();

            if (filasAfectadas != null)
            {
                return Convert.ToInt32(filasAfectadas);
            }
            else
            {
                return 0;
            }
        }
    }
}
