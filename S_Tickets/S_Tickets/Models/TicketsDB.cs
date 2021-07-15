using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace S_Tickets.Models
{
    public partial class TicketsDB : DbContext
    {
        public TicketsDB()
            : base("name=TicketsDB")
        {
        }

        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Resposable> Resposable { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Estado)
                .HasForeignKey(e => e.idEstado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resposable>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Resposable>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Resposable>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Resposable>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<Resposable>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Resposable)
                .HasForeignKey(e => e.idResponsable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Descripsion)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Solucion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);
        }
    }
}
