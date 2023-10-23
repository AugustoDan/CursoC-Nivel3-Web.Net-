using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Cliente cliente = user != null ? (Cliente)user : null;
            if (cliente != null && cliente.Id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool esAdmin(object user)
        {
            Cliente cliente = user != null ? (Cliente)user : null;

            return cliente != null ?  cliente.Admin : false ;
        }
            
    }
}
