using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg.models;
using plantila_tienda_backend.modelos.producto;

namespace plantila_tienda_backend.modelos.venta
{
    public class Venta : Entidad
    {
        public string Usuario { get; set; }
        public List<VentaProducto> Productos { get; set; }
        public double Total { get; set; }
    }
}