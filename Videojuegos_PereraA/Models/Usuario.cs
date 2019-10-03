using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videojuegos_PereraA.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Requiere inicio de sesión")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Introduzca su contraseña")]
        public string Password { get; set; }

        public Usuario()
        {
            UsuarioGrupos = new HashSet<UsuarioGrupo>();
        }
        public virtual ICollection<UsuarioGrupo> UsuarioGrupos { get; set; }
    }
}