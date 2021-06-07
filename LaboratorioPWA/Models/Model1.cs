using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LaboratorioPWA.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<juego> juego { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categoria>()
                .Property(e => e.nomCategoria)
                .IsUnicode(false);

            modelBuilder.Entity<categoria>()
                .Property(e => e.imagenCat)
                .IsUnicode(false);

            modelBuilder.Entity<juego>()
                .Property(e => e.nomJuego)
                .IsUnicode(false);

            modelBuilder.Entity<juego>()
                .Property(e => e.imagen)
                .IsUnicode(false);
        }
    }
}
