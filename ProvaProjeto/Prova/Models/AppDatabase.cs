using Microsoft.EntityFrameworkCore;

namespace Prova.Models;

public class AppDatabase : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source =Empresa.db");
    }
    public DbSet<Folha> Folhas { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Funcionario>()
            .HasKey(a => a.Id);



        modelBuilder.Entity<Folha>()
            .HasOne(m => m.funcionario);



    }
}