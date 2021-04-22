using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class AdminCategoria
    {
        public static List<Categoria> Listar()
        {
            return DACCategoria.CmdSelect();
            
        }
        public static int Crear(Categoria categoria)
        {
            int idDevuelto = DACCategoria.CmdInsert(categoria);
            return idDevuelto;
            //if (idDevuelto > 0)
            //{
            //    return idDevuelto;
            //}
            //else
            //{
            //    return 0;    
            //}
        }
    }
}
