using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using plantila_tienda_backend.dto.VentaDto;
using plantila_tienda_backend.interfaces;
using plantila_tienda_backend.modelos.venta;

namespace plantila_tienda_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly IVentaRepositorio  _ventaRepositorio;
        public VentaController(IVentaRepositorio ventaRepositorio)
        {
            _ventaRepositorio = ventaRepositorio;
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            var ventas = await _ventaRepositorio.GetAll();
            return Ok(ventas.Lista);
        }

        [Authorize]
        [HttpGet("GetVentasByUsuario/{idUsuario}")]
        public async Task<IActionResult> GetVentasByUsuario(string idUsuario)
        {
            var ventas = await _ventaRepositorio.GetVentasByUsuario(idUsuario);
            return Ok(ventas.Lista);
        }
        [Authorize]
        [HttpPost("CrearVenta")]
        public async Task<IActionResult> CrearVenta(CrearVenta venta)
        {
            var ventaCreada = await _ventaRepositorio.CrearVenta(venta);
            return Ok(ventaCreada.Valor);
        }
        
    }
}