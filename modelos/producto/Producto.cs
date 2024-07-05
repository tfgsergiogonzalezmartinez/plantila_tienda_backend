using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg.models;

namespace plantila_tienda_backend.modelos.producto
{
    public class Producto : Entidad
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int? Stock { get; set; }
        public List<string> Colores { get; set; }
        public List<string> Tallas { get; set; }
        public string Categoria { get; set; }
        public string? FotoPrincipal { get; set; }
        public List<string>? Fotos { get; set; }
    }
}