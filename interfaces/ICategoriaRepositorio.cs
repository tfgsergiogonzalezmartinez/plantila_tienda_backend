using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg.interfaces;
using backend_tfg.repositorios;
using plantila_tienda_backend.modelos.categoria;

namespace plantila_tienda_backend.interfaces
{
    public interface ICategoriaRepositorio : IBaseRepositorio<Categoria>
    {
        Task<RLista<Categoria>> GetCategoriasHijas(string NombreCategoria);
    }
}