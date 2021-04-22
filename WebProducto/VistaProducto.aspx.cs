using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;


namespace WebProducto
{
    public partial class VistaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {              
                TraerTodosLosProductos();
            }
        }

        protected void lblInsertarProducto_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto(TextBox1.Text, Convert.ToDecimal(TextBox2.Text), Convert.ToInt32(TextBox3.Text));
            int id = AdminProducto.Crear(producto);
            if (id > 0)
            {
                lblID.Text = id.ToString();
                lblCheck.Text = "Insert OK" +  id.ToString();  
                TraerTodosLosProductos();
            }
            else
            {
                lblCheck.Text = "FALLO";
            }


        }

        private void TraerTodosLosProductos()
        {
            List<Producto> lista = AdminProducto.Listar();
            GridView2.DataSource = lista;
            GridView2.DataBind();
        }

    }
}