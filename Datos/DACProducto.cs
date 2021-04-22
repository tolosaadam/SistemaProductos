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
    public static  class DACProducto
    {
        public static List<Producto> CmdSelect()
        {
            DataSet ds = new DataSet();
            string query = "SELECT Id,Nombre,Precio,IdCategoria FROM dbo.Productos";
            SqlDataAdapter adapter = new SqlDataAdapter(query, AdminDB.ConectarDB());
            adapter.Fill(ds, "Productos");

            List<Producto> lista = new List<Producto>();
            foreach (DataRow auxProducto in ds.Tables["Productos"].Rows)
            {
                lista.Add(new Producto(auxProducto["Nombre"].ToString(),Convert.ToDecimal(auxProducto["Precio"]),Convert.ToInt32(auxProducto["IdCategoria"]), Convert.ToInt32(auxProducto["Id"])));
            }

            return lista;
            
        }

        public static List<Producto> CmdSelect(int idCategoria)
        {
            DataSet ds = new DataSet();


            string query = "SELECT Id,Nombre,Precio,IdCategoria FROM dbo.Productos WHERE IdCategoria = @IdCategoria";

            SqlDataAdapter adapter = new SqlDataAdapter(query, AdminDB.ConectarDB());

           
            adapter.SelectCommand.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = idCategoria;

            adapter.Fill(ds, "Productos");


            List<Producto> lista = new List<Producto>();
            foreach (DataRow auxProducto in ds.Tables["Productos"].Rows)
            {
                lista.Add(new Producto(auxProducto["Nombre"].ToString(), Convert.ToDecimal(auxProducto["Precio"]), Convert.ToInt32(auxProducto["IdCategoria"]), Convert.ToInt32(auxProducto["Id"])));
            }
            return lista;
            
        }

        public static int CmdInsert(Producto producto)
        {
            string query = "INSERT INTO dbo.Productos (Nombre ,Precio ,IdCategoria) VALUES (@Nombre, @Precio, @IdCategoria); SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, AdminDB.ConectarDB());
            
            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = producto.Nombre;
            command.Parameters.Add("@Precio", SqlDbType.Money).Value = producto.Precio;
            command.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = producto.IdCategoria;
            

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
