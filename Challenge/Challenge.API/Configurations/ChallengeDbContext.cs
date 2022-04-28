using Challenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge.API.Configurations;

public class ChallengeDbContext : DbContext
{
    public ChallengeDbContext(DbContextOptions<ChallengeDbContext> options) : base(options)
    {
        
    }

    public DbSet<Personaje> Personaje { get; set; }
    public DbSet<PeliculaSerie> PeliculaSerie { get; set; }
    public DbSet<Genero> Genero { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GeneroPeliculaSerie>().HasKey(sc => new { sc.GeneroId, sc.PeliculaSerieId});

        modelBuilder.Entity<PeliculaSeriePersonaje>().HasKey(sc => new { sc.PeliculaSerieId, sc.PersonajeId });
    }
}
