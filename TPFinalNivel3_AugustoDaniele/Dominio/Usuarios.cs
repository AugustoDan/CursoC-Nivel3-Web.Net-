using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        NORMAL = 1 ,
        ADMIN = 2 
    }
    public class Usuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Usuarios(string usuario , string contraseña , bool administrador)
        {
            Usuario = usuario;
            Contraseña = contraseña;
            TipoUsuario = administrador ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
    }
}
