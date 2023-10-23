using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
   public class UsuarioNegocio
    {
        public bool Loguear (Usuarios usuario)
        {
            AccesoDatos  datos = new AccesoDatos();

            try
            {
                datos.setearConsulta2("ObtenerUsuarios");
                datos.setearParametros("@Usuario", usuario.Usuario);
                datos.setearParametros("@Contraseña", usuario.Contraseña);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.TipoUsuario = (int)datos.Lector["TipoUsuario"] == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;

                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
