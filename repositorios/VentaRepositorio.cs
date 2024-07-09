using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg;
using backend_tfg.interfaces;
using backend_tfg.repositorios;
using MongoDB.Driver;
using plantila_tienda_backend.dto.VentaDto;
using plantila_tienda_backend.interfaces;
using plantila_tienda_backend.modelos.venta;

namespace plantila_tienda_backend.repositorios
{
    public class VentaRepositorio : BaseRepositorio<Venta>, IVentaRepositorio
    {
        private readonly IConfiguration _config;
        public VentaRepositorio(ContextoDB contextoDb, IConfiguration confi) : base(contextoDb)
        {
            _config = confi;
        }


        public async Task<RLista<Venta>> GetVentasByUsuario(string idUsuario)
        {
            var datos = await collection.Find(x => x.Usuario == idUsuario).ToListAsync();
            return new RLista<Venta>(datos);
        }

        public async Task<RItem<Venta>> CrearVenta(CrearVenta venta)
        {
            var ventaCreada = new Venta
            {   
                UsuarioCreacion = venta.Usuario,
                FechaCreacion = DateTime.Now,
                Usuario = venta.Usuario,
                Productos = venta.Productos,
                Total = venta.Total
            };
            await collection.InsertOneAsync(ventaCreada);
            return new RItem<Venta>(ventaCreada);
        }

        
    }
}