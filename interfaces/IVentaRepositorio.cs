using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg.interfaces;
using plantila_tienda_backend.dto.VentaDto;
using plantila_tienda_backend.modelos.venta;

namespace plantila_tienda_backend.interfaces
{
    public interface IVentaRepositorio : IBaseRepositorio<Venta>
    {
        Task<RLista<Venta>> GetVentasByUsuario(string idUsuario);
        Task<RItem<Venta>> CrearVenta(CrearVenta venta);
    }
}