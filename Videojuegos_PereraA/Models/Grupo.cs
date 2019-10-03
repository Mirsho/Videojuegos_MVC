using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videojuegos_PereraA.Models
{
    public class Grupo
    {
        [Key]
        public int IdGrupo { get; set; }
        public string Nombre { get; set; }

        public Grupo()
        {
            UsuarioGrupos = new HashSet<UsuarioGrupo>();
        }
        public virtual ICollection<UsuarioGrupo> UsuarioGrupos { get; set; }
    }
}