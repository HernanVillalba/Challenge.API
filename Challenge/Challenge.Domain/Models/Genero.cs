using Challenge.Infrastructure.Models;

namespace Challenge.Domain.Models;

public class Genero : ModelBase
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Imagen { get; set; }
    public IEnumerable<GeneroPeliculaSerie> GenerosPelicuslaSeries { get; set; }
}
