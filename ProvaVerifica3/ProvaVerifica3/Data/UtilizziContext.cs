using System;
using Microsoft.EntityFrameworkCore;
using ProvaVerifica3.Model;

namespace ProvaVerifica3.Data;

public class UtilizziContext : DbContext
{
    public DbSet<Studente> Studenti { get; set; } = null!;
   public  DbSet<Classe> Classi { get; set; } = null!;
    public DbSet<Utilizza> Utilizzi { get; set;} = null!;
    public DbSet<Computer> Computers { get; set; } = null!;
    public string DbPath {get;set;} = null!;

    public UtilizziContext()
    {
        var appDir = AppContext.BaseDirectory;
        var path = Path.Combine(appDir, "../../../Utilizzi.db");
        DbPath = path;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source = {DbPath}");
    }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Relazione uno-a-molti tra Studente e Classe
    modelBuilder.Entity<Studente>()
        .HasOne(c => c.Classe)
        .WithMany(c => c.Studenti)
        .HasForeignKey(c => c.ClasseId);

    // Relazioni molti-a-molti tra Studente e Computer tramite Utilizza
    modelBuilder.Entity<Utilizza>()
        .HasOne(c => c.Studente)
        .WithMany(c => c.Utilizzi)
        .HasForeignKey(c => c.StudenteId);

    modelBuilder.Entity<Utilizza>()
        .HasOne(c => c.Computer)
        .WithMany(c => c.Utilizzi)
        .HasForeignKey(c => c.ComputerId);

    // Chiave primaria composta per la tabella di collegamento Utilizza
    modelBuilder.Entity<Utilizza>()
        .HasKey(u => new { u.StudenteId, u.ComputerId, u.DataOraInizioUtilizzo });
}
}