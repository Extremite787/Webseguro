using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webseguro.Models;

namespace Webseguro.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,UserRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("Genero");

                entity.Property(e => e.Contenido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Persona__06370DAD884D090A");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoGeneroNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.CodigoGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Genero");

                entity.Property(e => e.Cambio)
                    //.HasMaxLength(100)
                    .IsUnicode(false);
            });
        }        
    }
}
