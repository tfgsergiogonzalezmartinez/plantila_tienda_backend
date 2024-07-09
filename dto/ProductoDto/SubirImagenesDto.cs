using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plantila_tienda_backend.dto.ProductoDto
{
    public class SubirImagenesDto
    {
        public string IdProducto { get; set; }
        public List<string> Fotos { get; set; }
        public string FotoPrincipal { get; set; }
    }
}