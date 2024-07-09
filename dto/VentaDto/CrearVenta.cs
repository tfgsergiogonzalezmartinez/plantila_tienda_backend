using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using plantila_tienda_backend.modelos.venta;

namespace plantila_tienda_backend.dto.VentaDto
{
    public class CrearVenta
    {
        public string Usuario { get; set; }
        public List<VentaProducto> Productos { get; set; }
        public double Total { get; set; }


        public CrearVenta(string usuario, List<VentaProducto> productos, double total)
        {
            Usuario = usuario;
            Productos = productos;
            Total = total;
        }


        public void toEntidad(Venta venta){
            venta.Usuario = Usuario;
            venta.Productos = Productos;
            venta.Total = Total;}
    }


}