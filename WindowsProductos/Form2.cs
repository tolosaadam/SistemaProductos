using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Datos.BaseDatos;
using Negocio;


namespace WindowsProductos
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto("Mouse", Convert.ToDecimal(5.5), 2);
            bool result = AdminProducto.Crear(producto);
            if (result)
            {
                MessageBox.Show("OK");
                ShowAllProducts();
            }
            else
            {
                MessageBox.Show("Fallo");
            }
        }

        private void ShowAllProducts()
        {
            List<Producto> listaResultado = AdminProducto.Listar();
            dataGridView1.DataSource = listaResultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ShowAllProducts();
            }
            else
            {
                List<Producto> listaResultado = AdminProducto.Listar(Convert.ToInt32(textBox1.Text));
                dataGridView1.DataSource = listaResultado;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowAllCategories();
        }

        private void ShowAllCategories()
        {
            List<Categoria> listaResultado = AdminCategoria.Listar();
            dataGridView1.DataSource = listaResultado;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria("Periferico");
            bool result = AdminCategoria.Crear(categoria);
            if (result)
            {
                MessageBox.Show("OK");
                ShowAllCategories();
            }
            else
            {
                MessageBox.Show("Fallo");
            }
        }
    }
}
