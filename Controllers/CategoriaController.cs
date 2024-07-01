using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using plantila_tienda_backend.interfaces;
using plantila_tienda_backend.modelos.categoria;

namespace plantila_tienda_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _categoriaRepositorio.GetAll();
            return Ok(categorias.Lista);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategoria(Categoria categoria)
        {
            var categoriaCreada = await _categoriaRepositorio.Create(categoria);
            return Ok(categoriaCreada.Valor);
        }
        
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategoria(Categoria categoria)
        {
            var categoriaActualizada = await _categoriaRepositorio.Put(categoria);
            return Ok(categoriaActualizada.Valor);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var categoria = await _categoriaRepositorio.GetById(id);
            return Ok(categoria.Valor);
        }
        [HttpGet("categoria/{idCategoria}")]
        public async Task<IActionResult> GetCategoriasHijas(string NombreCategoria)
        {
            var categorias = await _categoriaRepositorio.GetCategoriasHijas(NombreCategoria);
            return Ok(categorias.Lista);
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(string id)
        {
            var categoriaEliminada = await _categoriaRepositorio.Delete(id);
            return Ok(categoriaEliminada);
        }





        
        
    }
}