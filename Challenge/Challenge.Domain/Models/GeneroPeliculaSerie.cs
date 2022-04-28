namespace Challenge.Domain.Models;

public class GeneroPeliculaSerie
{
    public int GeneroId { get; set; }
    public Genero Genero { get; set; } 

    public int PeliculaSerieId { get; set; }
    public PeliculaSerie PeliculaSerie { get; set; }
}
