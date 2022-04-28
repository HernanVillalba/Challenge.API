using Challenge.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Domain.Models;

public class Personaje : ModelBase
{
    public int Id { get; set; }
    public string Imagen { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public float Peso { get; set; }
    public string Historia { get; set; }
    public IEnumerable<PeliculaSeriePersonaje> PeliculasSeriesPersonajes { get; set; }
}
