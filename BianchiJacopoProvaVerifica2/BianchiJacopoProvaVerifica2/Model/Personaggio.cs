using System;

namespace BianchiJacopoProvaVerifica2.Model;
//Personaggio(PersonaggioId, Nome, RomanzoId*, Sesso, Ruolo )
public class Personaggio
{
    public int PersonaggioId { get; set; }
    public string Nome { get; set; } = null!;
    public int RomanzoId { get; set; }
    public string Sesso { get; set; } = null!;
    public string Ruolo { get; set; } = null!;
    
    public Romanzo Romanzo { get; set; } = null!;
}
