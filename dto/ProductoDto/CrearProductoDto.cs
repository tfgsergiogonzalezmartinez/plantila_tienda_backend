using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using plantila_tienda_backend.modelos.producto;

namespace plantila_tienda_backend.dto.ProductoDto
{
    public class CrearProductoDto
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


        public CrearProductoDto(string nombre, string descripcion, double precio, int? stock, List<string> colores, List<string> tallas, string categoria, string? fotoPrincipal, List<string>? fotos)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Colores = colores;
            Tallas = tallas;
            Categoria = categoria;
            FotoPrincipal = fotoPrincipal;
            Fotos = fotos;
        }


        public void toEntidad(Producto producto){
            producto.Nombre = Nombre;
            producto.Descripcion = Descripcion;
            producto.Precio = Precio;
            producto.Stock = Stock;
            producto.Colores = Colores;
            producto.Tallas = Tallas;
            producto.Categoria = Categoria;
            producto.FotoPrincipal = FotoPrincipal;
            producto.Fotos = Fotos;
        }
    }
}