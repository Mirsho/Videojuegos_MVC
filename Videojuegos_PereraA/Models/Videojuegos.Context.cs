﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VideoJuegosEntitiesOLD : DbContext
    {
        public VideoJuegosEntitiesOLD()
            : base("name=VideoJuegosEntities")
        {
        }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        */

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");  //Al llamar a la clase, se conecta con la tabla "Cliente"
            modelBuilder.Entity<Desarrollador>().ToTable("Desarrollador");
            modelBuilder.Entity<Distribuidor>().ToTable("Distribuidor");
            modelBuilder.Entity<Juego>().ToTable("Juego");
            modelBuilder.Entity<JuegoPlataforma>().ToTable("JuegoPlataforma");
            modelBuilder.Entity<Plataforma>().ToTable("Plataforma");
            modelBuilder.Entity<Puntuacion>().ToTable("Puntuacion");
            modelBuilder.Entity<Tipo>().ToTable("Tipo");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Grupo>().ToTable("Grupos");
            modelBuilder.Entity<UsuarioGrupo>().ToTable("UsuariosGrupos");
        }

        public virtual DbSet<Cliente> Cliente { get; set; }     //Metodo getter y setter de la clase Cliente
        public virtual DbSet<Desarrollador> Desarrollador { get; set; }
        public virtual DbSet<Distribuidor> Distribuidor { get; set; }
        public virtual DbSet<Juego> Juego { get; set; }
        public virtual DbSet<JuegoPlataforma> JuegoPlataforma { get; set; }
        public virtual DbSet<Plataforma> Plataforma { get; set; }
        public virtual DbSet<Puntuacion> Puntuacion { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<UsuarioGrupo> UsuariosGrupos { get; set; }
    }
}