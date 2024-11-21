using System;

namespace BianchiJacopoProvaVerifica2.Model;
//Autore(AutoreId, Nome, Cognome, Nazionalità )
public class Autore
{
    public int AutoreId { get; set; }
    public string Nome { get; set; } = null!;
    public string Cognome { get; set; } = null!;
    public string Nazionalità { get; set; } = null!;

    public List<Romanzo> Romanzi { get; set; } = null!;
    }
