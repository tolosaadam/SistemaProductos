using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace WebProducto
{
    public partial class VistaCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {
                TraerTodasLasCategorias();
                TraerTodosLosProductos();

                //ComboCategoria.Items.Add("TODOS");
                //ComboCategoria.Items.Add("1");
                //ComboCategoria.Items.Add("2");

                List<Categoria> idCategorias = AdminCategoria.Listar();

                ComboCategoria.Items.Add("TODOS");
                foreach (Categoria a in idCategorias)
                {
                    ComboCategoria.Items.Add(Convert.ToString(a.Id));
                }
            }    
        }

        
        protected void btnInsertarCategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria(TextBox1.Text);
            int idCreado = AdminCategoria.Crear(categoria);
            

            if (idCreado > 0)
            {
                lblCheck.Text = "Insertado Ok";
                TraerTodasLasCategorias();
                ComboCategoria.Items.Add(Convert.ToString(idCreado));
            }
            else
            {
                lblCheck.Text = "Fallo Insert";
            }
        }
        private void TraerTodosLosProductosPorCategoria(int id)
        {
            List<Producto> lista = AdminProducto.Listar(id);
            GridView2.DataSource = lista;
            GridView2.DataBind();
        }

        private void TraerTodosLosProductos()
        {
            List<Producto> lista = AdminProducto.Listar();
            GridView2.DataSource = lista;
            GridView2.DataBind();
        }
        private void TraerTodasLasCategorias()
        {
            List<Categoria> lista = AdminCategoria.Listar();
            GridView1.DataSource = lista;
            GridView1.DataBind();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ComboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idCategoria = ComboCategoria.SelectedValue;
            if (idCategoria == "TODOS")
            {
                TraerTodosLosProductos();
            }
            else
            {
                TraerTodosLosProductosPorCategoria(Convert.ToInt32(idCategoria));
            }
        }
    }
}