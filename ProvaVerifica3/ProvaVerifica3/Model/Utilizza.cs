using System;
using Microsoft.EntityFrameworkCore;

namespace ProvaVerifica3.Model;

//Utilizza(StudenteId*,ComputerId*,DataOraInizioUtilizzo, DataOraFineUtilizzo )


public class Utilizza
{
    public int StudenteId { get; set; }
    public int ComputerId { get; set; }
    public DateTime DataOraInizioUtilizzo { get; set; } 
    public DateTime? DataOraFineUtilizzo { get; set; }

    public Computer Computer { get; set; } = null!;
    public Studente Studente { get; set; } = null!;
}
