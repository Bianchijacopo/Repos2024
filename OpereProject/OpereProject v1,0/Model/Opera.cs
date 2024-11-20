using System;

namespace OpereProject_v1_0.Model;
//Opera (Id, Titolo, Quotazione, FkArtistaId)
public class Opera
{
    public int Id { get; set; }
    public string Titolo { get; set; } = null!;
    public decimal Quotazione { get; set; } 
    public int FkArtista { get; set; }
}
