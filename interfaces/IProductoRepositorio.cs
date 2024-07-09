using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg.interfaces;
using plantila_tienda_backend.dto.ProductoDto;
using plantila_tienda_backend.modelos.producto;

namespace plantila_tienda_backend.interfaces
{
    public interface IProductoRepositorio : IBaseRepositorio<Producto>
    {
        Task<RLista<Producto>> GetProductosByCategoriaFilterPrecioDesc(string idCategoria);
        Task<RLista<Producto>> GetProductosFilterPrecioDesc();
        Task<RLista<Producto>> GetProductosByCategoriaFilterPrecioAsc(string idCategoria);
        Task<RLista<Producto>> GetProductosFilterPrecioAsc();
        Task<RLista<Producto>> GetProductosByCategoria(string idCategoria);
        Task<RItem<Producto>> CrearProducto(CrearProductoDto crearProductoDto);
        Task<RItem<Producto>> SubirImagenesProducto(SubirImagenesDto subirImagenesDto);

    }
}