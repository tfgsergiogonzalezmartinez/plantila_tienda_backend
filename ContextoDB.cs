using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg.modelos.usuario;
using BCrypt.Net;
using MongoDB.Driver;
using Newtonsoft.Json;
using plantila_tienda_backend.modelos.categoria;
using plantila_tienda_backend.modelos.producto;

namespace backend_tfg
{
public class ContextoDB
    {
        private readonly IMongoDatabase _database;


        public ContextoDB(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
            InicializarDatosAsync();
        }

        public IMongoDatabase getDatabase(){
            return _database;
        }
        public IMongoCollection<T> GetCollection<T>()
        {
            string nombre=string.Empty; 
            if (typeof(T).Name.Equals("User")) {
                nombre = "User";
            } else if (typeof(T).Name.Equals("Producto")) {
                nombre = "Productos";
            } else if (typeof(T).Name.Equals("Categoria")) {
                nombre = "Categorias";
            } else if (typeof(T).Name.Equals("Venta")) {
                nombre = "Ventas";
            }
     
            return _database.GetCollection<T>(nombre);
        }
  
  
        protected async Task InicializarDatosAsync()
        {

            var usuarios = _database.GetCollection<User>("User");
            if (usuarios.CountDocuments(FilterDefinition<User>.Empty) == 0)
            {
                usuarios.InsertMany(new List<User>
                {
                    new User
                    {
                        Nombre = "Sergio",
                        Apellido1 = "Gonzalez",
                        Apellido2 = "Martinez",
                        Email = "admin@admin.es",
                        HashedPassword = BCrypt.Net.BCrypt.HashPassword("Admin7#"),
                        FechaNacimiento = DateTime.Now,
                        Rol = "admin",
                        Listable = true,
                        FechaCreacion = DateTime.Now,
                    },
                });
            }
            var productosDb = _database.GetCollection<Producto>("Productos");
            string jsonProductosRuta = Path.Combine("dbModelos", "bbdd_productos.json");
            var json = await File.ReadAllTextAsync(jsonProductosRuta);
            List<Producto> listaProductos = JsonConvert.DeserializeObject<List<Producto>>(json);
            
            productosDb.InsertMany(listaProductos);

            var categoriasDb = _database.GetCollection<Categoria>("Categorias");
            string jsonCategoriaRuta = Path.Combine("dbModelos", "bbdd_categorias.json");
            json = await File.ReadAllTextAsync(jsonCategoriaRuta);
            List<Categoria> listaCategorias = JsonConvert.DeserializeObject<List<Categoria>>(json);
            
            categoriasDb.InsertMany(listaCategorias);
            
        }
    }
}