using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloUsuarios.Models.Entities
{
    public class Usuario
    {
        // DataAnnotations
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Por favor, escriba su nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor, escriba su correo")]
        [EmailAddress]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Por favor, escriba su teléfono")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Por favor, escriba su contraseña")]
        public string Contrasena { get; set; }

        [NotMapped]
        [Compare(nameof(Contrasena), ErrorMessage = "Las contraseñas no coinciden")]
        public string RepetirContrasena { get; set; }

        public bool Estado { get; set; }

        [ForeignKey("RolId")]
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
