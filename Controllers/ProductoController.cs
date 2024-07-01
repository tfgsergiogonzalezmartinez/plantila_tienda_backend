using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using plantila_tienda_backend.interfaces;
using plantila_tienda_backend.modelos.producto;

namespace plantila_tienda_backend.Controllers
{   
    [ApiController]
    [Authorize]
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
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var producto = await _productoRepositorio.GetById(id);
            return Ok(producto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            var productoCreado = await _productoRepositorio.Create(producto);
            return Ok(productoCreado);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Producto producto)
        {
            var productoActualizado = await _productoRepositorio.Put(producto);
            return Ok(productoActualizado);
        }

        [HttpGet("categoria/{idCategoria}")]
        public async Task<IActionResult> GetProductosByCategoria(string idCategoria)
        {
            var productos = await _productoRepositorio.GetProductosByCategoria(idCategoria);
            return Ok(productos);
        }
        [HttpGet("categoria/{idCategoria}/precio/asc")]
        public async Task<IActionResult> GetProductosByCategoriaFilterPrecioAsc(string idCategoria)
        {
            var productos = await _productoRepositorio.GetProductosByCategoriaFilterPrecioAsc(idCategoria);
            return Ok(productos);
        }
        [HttpGet("categoria/{idCategoria}/precio/desc")]
        public async Task<IActionResult> GetProductosByCategoriaFilterPrecioDesc(string idCategoria)
        {
            var productos = await _productoRepositorio.GetProductosByCategoriaFilterPrecioDesc(idCategoria);
            return Ok(productos);
        }
        [HttpGet("precio/asc")]
        public async Task<IActionResult> GetProductosFilterPrecioAsc()
        {
            var productos = await _productoRepositorio.GetProductosFilterPrecioAsc();
            return Ok(productos);
        }
        [HttpGet("precio/desc")]
        public async Task<IActionResult> GetProductosFilterPrecioDesc()
        {
            var productos = await _productoRepositorio.GetProductosFilterPrecioDesc();
            return Ok(productos);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var productoEliminado = await _productoRepositorio.Delete(id);
            return Ok(productoEliminado);
        }


        
    }
}