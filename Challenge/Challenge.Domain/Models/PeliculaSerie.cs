using Challenge.Infrastructure.Models;

namespace Challenge.Domain.Models;

public class PeliculaSerie : ModelBase
{
    public int Id { get; set; }
    public string Imagen { get; set; }
    public string Titulo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int Calificacion { get; set; }
    public IEnumerable<PeliculaSeriePersonaje> PeliculasSeriesPersonajes { get; set; }
    public IEnumerable<GeneroPeliculaSerie> GenerosPeliculasSeries { get; set; }
}

