using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using ProjetoAluguelCarros.Models;

namespace ProjetoAluguelCarros;

public partial class AluguelDbContext : DbContext
{

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Aluguel> Alugueis { get; set; }

    public AluguelDbContext()
    {
    }

    public AluguelDbContext(DbContextOptions<AluguelDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
        modelBuilder.Entity<Cliente>().Property(c => c.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Carro>().HasKey(c => c.Id);
        modelBuilder.Entity<Carro>().Property(c => c.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Aluguel>().HasKey(a => a.Id);
        modelBuilder.Entity<Aluguel>().Property(a => a.Id).ValueGeneratedOnAdd();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
