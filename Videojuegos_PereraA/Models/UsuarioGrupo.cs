using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Videojuegos_PereraA.Models
{
    public class UsuarioGrupo
    {
        [Key]
        public int IdUsuarioGrupo { get; set; }
        public int IdUsuario { get; set; }
        public int IdGrupo { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("IdGrupo")]
        public virtual Grupo Grupo { get; set; }
    }
}