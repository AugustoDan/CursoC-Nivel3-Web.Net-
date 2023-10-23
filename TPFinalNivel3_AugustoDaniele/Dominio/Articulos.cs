using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulos
    {
        public int IdArt { get; set; }
        [DisplayName("Codigo")]
        public string CodigoArt { get; set; }
        [DisplayName("Nombre")]
        public string NombreArt { get; set; }
        [DisplayName("Descripcion")]
        public string DescripcionArt { get; set; }
        [DisplayName("Marca")]
        public Marcas IdMarca { get; set; }
        [DisplayName("Categoria")]
        public Categorias IdCategorias { get; set; }
        public string ImagenUrl { get; set; }
        [DisplayName("Precio")]
        public decimal PrecioArt { get; set; }
        public int Activo { get; set; }

    }
}
