using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class AdminProducto
    {
        public static List<Producto> Listar()
        {
            return DACProducto.CmdSelect();
            
        }
        public static List<Producto> Listar(int idCategoria)
        {
            return DACProducto.CmdSelect(idCategoria);
            
        }
        public static int Crear(Producto producto)
        {
            int idDevuelto = DACProducto.CmdInsert(producto);
            return idDevuelto;

        }
    }
}
