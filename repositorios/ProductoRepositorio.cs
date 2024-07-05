using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg;
using backend_tfg.interfaces;
using backend_tfg.repositorios;
using MongoDB.Bson;
using MongoDB.Driver;
using plantila_tienda_backend.dto.ProductoDto;
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

        public async Task<RLista<Producto>> GetProductosByCategoria(string nombreCategoria){
            var filter = Builders<Producto>.Filter.Eq("Categoria", nombreCategoria);
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

        public async Task<RLista<Producto>> GetProductosByCategoriaFilterPrecioAsc(string nombreCategoria){
            var filter = new List<BsonDocument>
            {
                new BsonDocument("$match",
                new BsonDocument("Categoria", nombreCategoria)),
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

        public async Task<RLista<Producto>> GetProductosByCategoriaFilterPrecioDesc(string NombreCategoria){
            var filter = new List<BsonDocument>
            {
                new BsonDocument("$match",
                new BsonDocument("Categoria", NombreCategoria)),
                new BsonDocument("$sort", 
                new BsonDocument("Precio", 1))
            };
            var datos = await this.collection.Aggregate<Producto>(filter).ToListAsync();
            return new RLista<Producto>(datos);
        }

        public async Task<RItem<Producto>> CrearProducto(CrearProductoDto crearProductoDto){
            Producto producto = new Producto();
            crearProductoDto.toEntidad(producto);
            await this.collection.InsertOneAsync(producto);
            return new RItem<Producto>(producto);
        }

        public async Task<RItem<Producto>> SubirImagenesProducto(SubirImagenesDto subirImagenesDto){
            var filter = Builders<Producto>.Filter.Eq("Id", subirImagenesDto.IdProducto);
            var producto = await this.collection.Find(filter).FirstOrDefaultAsync();
            if(producto == null){
                return new RItem<Producto>(null){
                    Mensaje = "Producto no encontrado",
                    Resultado = -1
                };
            }
            producto.Fotos = subirImagenesDto.Fotos;
            producto.FotoPrincipal = subirImagenesDto.FotoPrincipal;
            await this.collection.ReplaceOneAsync(filter, producto);
            return new RItem<Producto>(producto);
        }

        
    }
}