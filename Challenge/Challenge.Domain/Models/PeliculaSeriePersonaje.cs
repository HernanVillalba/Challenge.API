namespace Challenge.Domain.Models;

public class PeliculaSeriePersonaje
{
    public int PeliculaSerieId { get; set; }
    public PeliculaSerie PeliculaSerie { get; set; }    

    public int PersonajeId { get; set; }
    public Personaje Personaje { get; set; }
}
