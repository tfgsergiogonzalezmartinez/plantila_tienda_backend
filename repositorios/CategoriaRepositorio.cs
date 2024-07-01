using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg;
using backend_tfg.interfaces;
using backend_tfg.repositorios;
using MongoDB.Driver;
using plantila_tienda_backend.interfaces;
using plantila_tienda_backend.modelos.categoria;

namespace plantila_tienda_backend.repositorios
{
    public class CategoriaRepositorio : BaseRepositorio<Categoria>, ICategoriaRepositorio
    {

        private IConfiguration _config;
        public CategoriaRepositorio(IConfiguration cofiguration, ContextoDB contexto) : base(contexto)
        {
            _config = cofiguration;
        }

        public async Task<RLista<Categoria>> GetCategoriasHijas(string NombreCategoria){
            var filter = Builders<Categoria>.Filter.Eq("CategoriaPadre", NombreCategoria);
            var datos = await this.collection.Find<Categoria>(filter).ToListAsync();
            return new RLista<Categoria>(datos);
        }


        
    }
}