using System;
using BianchiJacopoProvaVerifica2.Model;
using Microsoft.EntityFrameworkCore;

namespace BianchiJacopoProvaVerifica2.Data;

public class RomanziContext : DbContext
{
    public DbSet<Autore> Autori { get; set; } = null!;
    public DbSet<Romanzo> Romanzi { get; set;} = null!;
    public DbSet<Personaggio> Personaggi { get; set; } = null!;
    public string DbPath { get; set; } = null!;

    public RomanziContext()
    {
        var appDir = AppContext.BaseDirectory;
        var path = Path.Combine(appDir, $"../../../Romanzi.db");
        DbPath = path;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source = {DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Romanzo>().HasOne(a => a.Autore).WithMany(r => r.Romanzi).HasForeignKey(a => a.AutoreId);

        modelBuilder.Entity<Personaggio>().HasOne(r => r.Romanzo).WithMany(p => p.Personaggi).HasForeignKey(r => r.RomanzoId);

        
    }
}
