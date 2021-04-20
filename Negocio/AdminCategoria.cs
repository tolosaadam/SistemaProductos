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
        public static bool Crear(Categoria categoria)
        {
            bool filasAfectadas = DACCategoria.CmdInsert(categoria);
            if (filasAfectadas)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
