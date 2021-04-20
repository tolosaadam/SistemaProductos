using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public Producto(string nombre,decimal precio,int idCategoria, int id = 0)
        {
            Nombre = nombre;
            Precio = precio;
            IdCategoria = idCategoria;
            Id = id;
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        
    }
}
//Producto (Id-Nombre, Precio decimal, IdCategoria)