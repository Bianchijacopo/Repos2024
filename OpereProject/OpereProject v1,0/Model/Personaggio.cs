using System;

namespace OpereProject_v1_0.Model;
//Personaggio (Id, Nome, FkOperaId)
public class Personaggio
{
    public int Id { get; set;}
    public string Nome { get; set;} = null!;
    public int FkOperaId { get; set;}
}
