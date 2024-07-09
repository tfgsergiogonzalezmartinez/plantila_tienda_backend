using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using plantila_tienda_backend.dto.ProductoDto;
using plantila_tienda_backend.interfaces;
using plantila_tienda_backend.modelos.producto;

namespace plantila_tienda_backend.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepositorio _productoRepositorio;
        public ProductoController(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }



        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _productoRepositorio.GetAll();
            return Ok(productos.Lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var producto = await _productoRepositorio.GetById(id);
            return Ok(producto.Valor);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("CrearProducto")]
        public async Task<IActionResult> CrearProducto(CrearProductoDto producto)
        {
            var productoCreado = await _productoRepositorio.CrearProducto(producto);
            return Ok(productoCreado.Valor);
        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Update(Producto producto)
        {
            var productoActualizado = await _productoRepositorio.Put(producto);
            return Ok(productoActualizado.Valor);
        }

        [HttpGet("categoria/{nombreCategoria}")]
        public async Task<IActionResult> GetProductosByCategoria(string nombreCategoria)
        {
            var productos = await _productoRepositorio.GetProductosByCategoria(nombreCategoria);
            return Ok(productos.Lista);
        }
        [HttpGet("categoria/{nombreCategoria}/precio/asc")]
        public async Task<IActionResult> GetProductosByCategoriaFilterPrecioAsc(string nombreCategoria)
        {
            var productos = await _productoRepositorio.GetProductosByCategoriaFilterPrecioAsc(nombreCategoria);
            return Ok(productos.Lista);
        }
        [HttpGet("categoria/{nombreCategoria}/precio/desc")]
        public async Task<IActionResult> GetProductosByCategoriaFilterPrecioDesc(string nombreCategoria)
        {
            var productos = await _productoRepositorio.GetProductosByCategoriaFilterPrecioDesc(nombreCategoria);
            return Ok(productos.Lista);
        }
        [HttpGet("precio/asc")]
        public async Task<IActionResult> GetProductosFilterPrecioAsc()
        {
            var productos = await _productoRepositorio.GetProductosFilterPrecioAsc();
            return Ok(productos.Lista);
        }
        [HttpGet("precio/desc")]
        public async Task<IActionResult> GetProductosFilterPrecioDesc()
        {
            var productos = await _productoRepositorio.GetProductosFilterPrecioDesc();
            return Ok(productos.Lista);
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var productoEliminado = await _productoRepositorio.Delete(id);
            return Ok(productoEliminado);
        }

        [Authorize(Roles ="admin")]
        [HttpPost("subirImagenes")]
        public async Task<IActionResult> SubirImagenesProducto(SubirImagenesDto subirImagenesDto)
        {
            var producto = await _productoRepositorio.SubirImagenesProducto(subirImagenesDto);
            if (producto.Resultado != 0){
                return BadRequest(producto.Mensaje);
            }
            return Ok(producto.Valor);
        }


        
    }
}