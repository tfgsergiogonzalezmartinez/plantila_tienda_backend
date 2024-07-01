using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plantila_tienda_backend.modelos.usuario
{
    public class Direccion
    {
        public string DireccionEnvio { get; set; } = string.Empty;
        public string DireccionFacturacion { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public int Cp { get; set; } = 0;
        public string Provincia { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;

    }
}