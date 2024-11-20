using System;

namespace OpereProject_v1_0.Model;
//Artista (Id, Nome, Cognome, Nazionalità)
public class Artista
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Cognome { get; set; } = null!;
    public string Nazionalita { get; set; } = null!;
}
