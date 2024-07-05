using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plantila_tienda_backend.modelos.venta
{
    public class VentaProducto
    {
        public string Producto { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public double Precio { get; set; }
    }
}