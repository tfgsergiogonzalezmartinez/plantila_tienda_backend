using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tfg.modelos.usuario;
using plantila_tienda_backend.modelos.usuario;

namespace backend_tfg.dto.UserDto
{

    public class UserCreateDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public Direccion? DireccionUsuario { get; set; }

        public UserCreateDto()
        {
        }

        public void toEntidad(User usuario)
        {
            usuario.Email = Email;
            usuario.HashedPassword = Password;
            usuario.FechaNacimiento = FechaNacimiento;
            usuario.Nombre = Nombre;
            usuario.Apellido1 = Apellido1;
            usuario.Apellido2 = Apellido2;
            usuario.Telefono = Telefono;
            usuario.DireccionUsuario = DireccionUsuario;
        }


    }
}
