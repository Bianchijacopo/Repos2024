using System;

namespace ProvaVerifica3.Model;

//Computer(Id, Modello, Collocazione )
public class Computer
{
    public int Id { get; set; }
    public string Modello { get; set; } = null!;
    public string Collocazione { get; set; } = null!;

    public List<Utilizza> Utilizzi { get; set; } = null!;
}
