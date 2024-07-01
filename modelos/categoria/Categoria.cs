using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg.models;

namespace plantila_tienda_backend.modelos.categoria
{
    public class Categoria : Entidad
    {
        public string Nombre {get; set;}
        public string? CategoriaPadre {get; set;}
    }
}