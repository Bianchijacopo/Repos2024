using System;

namespace ProvaVerifica3.Model;

public class Classe
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Aula { get; set; } = null!;

    public List<Studente> Studenti { get; set; } = null!;
}
