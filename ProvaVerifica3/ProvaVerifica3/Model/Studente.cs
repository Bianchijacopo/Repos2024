using System;

namespace ProvaVerifica3.Model;

//Studente(Id, Nome, Cognome, ClasseId* )
public class Studente
{
    public int Id { get; set;}
    public string Nome { get; set;} = null!;
    public string Cognome { get; set;} = null!;
    public int ClasseId { get; set;}


    public Classe Classe { get; set; } = null!;
    public List<Utilizza> Utilizzi {get; set; } = null!;
}
