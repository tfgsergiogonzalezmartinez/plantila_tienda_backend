using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg;
using backend_tfg.interfaces;
using backend_tfg.repositorios;
using MongoDB.Bson;
using MongoDB.Driver;
using plantila_tienda_backend.interfaces;
using plantila_tienda_backend.modelos.producto;

namespace plantila_tienda_backend.repositorios
{
    public class ProductoRepositorio : BaseRepositorio<Producto>, IProductoRepositorio
    {


        private IConfiguration _config;
        public ProductoRepositorio(IConfiguration config, ContextoDB contextoDb) : base(contextoDb)
        {
            this._config = config;
        }

        public async Task<RLista<Producto>> GetProductosByCategoria(string idCategoria){
            var filter = Builders<Producto>.Filter.Eq("Categoria", idCategoria);
            var datos = await this.collection.Find<Producto>(filter).ToListAsync();
            return new RLista<Producto>(datos);
        }


        public async Task<RLista<Producto>> GetProductosFilterPrecioAsc(){
            var filter = new List<BsonDocument>
            {
                new BsonDocument("$sort", 
                new BsonDocument("Precio", -1))
            };
            var datos = await this.collection.Aggregate<Producto>(filter).ToListAsync();
            return new RLista<Producto>(datos);
        }

        public async Task<RLista<Producto>> GetProductosByCategoriaFilterPrecioAsc(string idCategoria){
            var filter = new List<BsonDocument>
            {
                new BsonDocument("$match",
                new BsonDocument("Categoria", idCategoria)),
                new BsonDocument("$sort", 
                new BsonDocument("Precio", -1))
            };
            var datos = await this.collection.Aggregate<Producto>(filter).ToListAsync();
            return new RLista<Producto>(datos);
        }

        public async Task<RLista<Producto>> GetProductosFilterPrecioDesc(){
            var filter = new List<BsonDocument>
            {
                new BsonDocument("$sort", 
                new BsonDocument("Precio", 1))
            };
            var datos = await this.collection.Aggregate<Producto>(filter).ToListAsync();
            return new RLista<Producto>(datos);
        }

        public async Task<RLista<Producto>> GetProductosByCategoriaFilterPrecioDesc(string idCategoria){
            var filter = new List<BsonDocument>
            {
                new BsonDocument("$match",
                new BsonDocument("Categoria", idCategoria)),
                new BsonDocument("$sort", 
                new BsonDocument("Precio", 1))
            };
            var datos = await this.collection.Aggregate<Producto>(filter).ToListAsync();
            return new RLista<Producto>(datos);
        }

        
    }
}