//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Videojuegos_PereraA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plataforma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plataforma()
        {
            this.JuegoPlataforma = new HashSet<JuegoPlataforma>();
        }
    
        public int IdPlataforma { get; set; }
        public string Plataforma1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JuegoPlataforma> JuegoPlataforma { get; set; }
    }
}