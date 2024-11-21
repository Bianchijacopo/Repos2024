using System;

namespace BianchiJacopoProvaVerifica2.Model;

//Romanzo(RomanzoId, Titolo, AutoreId*, AnnoPubblicazione )
public class Romanzo
{
    public int RomanzoId { get; set; }
    public string Titolo { get; set; } = null!;
    public int AutoreId { get; set; }
    public int AnnoPubblicazione { get; set; }

    public Autore Autore { get; set; } = null!;
    public List<Personaggio> Personaggi { get; set; } = null!;
}
