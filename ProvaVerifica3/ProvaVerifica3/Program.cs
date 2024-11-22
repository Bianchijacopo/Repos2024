using Microsoft.EntityFrameworkCore.Query.Internal;
using ProvaVerifica3.Data;
using ProvaVerifica3.Model;

static void PopulateDb()
{
		using UtilizziContext db = new();

			 List<Classe> classi =
			[
				new (){Id =1, Nome="3IA", Aula="Est 1"},
				new (){Id =2,Nome="4IA", Aula="A32"},
				new (){Id =3,Nome="5IA", Aula="A31"},
				new (){Id =4,Nome="3IB", Aula="Est 2"},
				new (){Id =5,Nome="4IB", Aula="A30"},
				new (){Id =6,Nome="5IB", Aula="A32"},
			];
            classi.ForEach(c => db.Add(c));
            db.SaveChanges();

			 List<Studente> studenti =
			[
				new (){Id = 1, Nome = "Mario", Cognome = "Rossi", ClasseId =1 },
				new (){Id = 2, Nome = "Giovanni", Cognome = "Verdi", ClasseId =1 },
				new (){Id = 3, Nome = "Piero", Cognome = "Angela", ClasseId = 1 },
				new (){Id = 4, Nome = "Leonardo", Cognome = "Da Vinci", ClasseId = 1 },
				new (){Id = 50, Nome = "Cristoforo", Cognome = "Colombo", ClasseId=2 },
				new (){Id = 51, Nome = "Piero", Cognome = "Della Francesca", ClasseId=2 },
				new (){Id = 82, Nome = "Alessandro", Cognome = "Manzoni", ClasseId=4 },
				new (){Id = 83, Nome = "Giuseppe", Cognome = "Parini", ClasseId=4 },
				new (){Id = 102, Nome = "Giuseppe", Cognome = "Ungaretti", ClasseId=3 },
				new (){Id = 103, Nome = "Luigi", Cognome = "Pirandello", ClasseId=3 },
				new (){Id = 131, Nome = "Enrico", Cognome = "Fermi", ClasseId=6 },
				new (){Id = 132, Nome = "Sandro", Cognome = "Pertini", ClasseId=6 },
			];
            studenti.ForEach(c => db.Add(c));
            db.SaveChanges();

			 List<Computer> computers = 
			[
				new (){Id = 1, Modello="Hp 19 inc. 2019", Collocazione = "Bunker-D1-D5"},
				new (){Id = 2, Modello="Hp 19 inc. 2019", Collocazione = "Bunker-D1-D5"},
				new (){Id = 3, Modello="Hp 19 inc. 2019", Collocazione = "Bunker-D1-D5"},
				new (){Id = 4, Modello="Hp 19 inc. 2019", Collocazione = "Bunker-D1-D5"},
				new (){Id = 5, Modello="Hp 19 inc. 2019", Collocazione = "Bunker-D1-D5"},
				new (){Id = 6, Modello="Hp 19 inc. 2019", Collocazione = "Bunker-D6-D10"},
				new (){Id = 7, Modello="Hp 19 inc. 2019", Collocazione = "Bunker-D6-D10"},
				new (){Id = 8, Modello="Hp 19 inc. 2019", Collocazione = "Bunker-D6-D10"},
				new (){Id = 9, Modello="Hp 19 inc. 2019", Collocazione = "Bunker-D6-D10"},
				new (){Id = 10, Modello="Hp 19 inc. 2019", Collocazione = "Bunker-D6-D10"},
				new (){Id = 20, Modello="Lenovo i5 2020", Collocazione = "Bunker-D20-D25"},
				new (){Id = 21, Modello="Lenovo i5 2020", Collocazione = "Bunker-D20-D25"},
				new (){Id = 22, Modello="Lenovo i5 2020", Collocazione = "Bunker-D20-D25"},
				new (){Id = 23, Modello="Lenovo i5 2020", Collocazione = "Bunker-D20-D25"},
				new (){Id = 24, Modello="Lenovo i5 2020", Collocazione = "Bunker-D20-D25"},
				new (){Id = 61, Modello="Lenovo i5 2021", Collocazione = "Carrello-Mobile-S1"},
				new (){Id = 62, Modello="Lenovo i5 2021", Collocazione = "Carrello-Mobile-S2"},
				new (){Id = 63, Modello="Lenovo i5 2021", Collocazione = "Carrello-Mobile-S3"},
				new (){Id = 64, Modello="Lenovo i5 2021", Collocazione = "Carrello-Mobile-S4"},
				new (){Id = 65, Modello="Lenovo i5 2021", Collocazione = "Carrello-Mobile-S5"},
			];
            computers.ForEach(c => db.Add(c));
            db.SaveChanges();

			 List<Utilizza> utilizzi = new()
			{
				new (){ComputerId = 61,StudenteId=1,
					DataOraInizioUtilizzo = DateTime.Now.Add(- new TimeSpan(1,12,0)),
					DataOraFineUtilizzo = DateTime.Now},
				new (){ComputerId = 61,StudenteId=1,
					DataOraInizioUtilizzo = DateTime.Now.Add(- new TimeSpan(1,1,12,0)),
					DataOraFineUtilizzo = DateTime.Now.Add(- new TimeSpan(1,0,0,0))},
				new (){ComputerId = 61,StudenteId=3,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-2).AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-2).AddHours(12)},
				new (){ComputerId = 61,StudenteId=82,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-1).AddHours(12),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-1).AddHours(13) },
				new (){ComputerId = 61,StudenteId=1,
					DataOraInizioUtilizzo = DateTime.Today.AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddHours(12) },
				new (){ComputerId = 62,StudenteId=2,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-2).AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-2).AddHours(12) },
				new (){ComputerId = 62,StudenteId=2,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-1).AddHours(12),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-1).AddHours(13) },
				new (){ComputerId = 62,StudenteId=4,
					DataOraInizioUtilizzo = DateTime.Today.AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddHours(11) },
				new (){ComputerId = 1,StudenteId=50,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-2).AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-2).AddHours(12) },
				new (){ComputerId = 1,StudenteId=103,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-1).AddHours(12),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-1).AddHours(13) },
				new (){ComputerId = 1,StudenteId=50,
					DataOraInizioUtilizzo = DateTime.Today.AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddHours(12) },
				new (){ComputerId = 2,StudenteId=51,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-1).AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-1).AddHours(12) },
				new (){ComputerId = 2,StudenteId=51,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-1).AddHours(12),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-1).AddHours(13) },
				new (){ComputerId = 2,StudenteId=103,
					DataOraInizioUtilizzo = DateTime.Today.AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddHours(12) },
				new (){ComputerId = 3,StudenteId=82,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-2).AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-2).AddHours(12) },
				new (){ComputerId = 3,StudenteId=82,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-1).AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-1).AddHours(13) },
				new (){ComputerId = 3,StudenteId=83,
					DataOraInizioUtilizzo = DateTime.Today.AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddHours(12) },
				new (){ComputerId = 20,StudenteId=102,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-2).AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-2).AddHours(12) },
				new (){ComputerId = 20,StudenteId=103,
					DataOraInizioUtilizzo = DateTime.Today.AddDays(-1).AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddDays(-1).AddHours(12) },
				new (){ComputerId = 20,StudenteId=103,
					DataOraInizioUtilizzo = DateTime.Today.AddHours(11),
					DataOraFineUtilizzo = DateTime.Today.AddHours(12) },
				new (){ComputerId = 64,StudenteId=131,
					DataOraInizioUtilizzo = DateTime.Now.Add(- new TimeSpan(0,12,0)),
					DataOraFineUtilizzo = null},
				new (){ComputerId = 65,StudenteId=132,
					DataOraInizioUtilizzo = DateTime.Now.Add(- new TimeSpan(1,12,0)),
					DataOraFineUtilizzo = null},
			};
            utilizzi.ForEach(c => db.Add(c));
            db.SaveChanges();
}

//Q1(string classe): Stampa a Console il numero di alunni della classe in input; ad esempio, stampa il numero di alunni della 4IA
//Q2(): Stampa a Console il numero di alunni per ogni classe
//Q3(): Stampa gli studenti che non hanno ancora restituito i computer (sono quelli collegati a Utilizza con DataOraFineUtilizzo pari a null)
//Q4(string classe): Stampa l’elenco dei computer che sono stati utilizzati dagli studenti della classe specificata in input. Ad esempio, stampare l’elenco dei computer utilizzati dalla 4IA. Non mostrare ripetizioni nella stampa.
//Q5(int computerId): Dato un computer (di cui si conosce l’Id) riporta l’elenco degli studenti che lo hanno usato negli ultimi 30 giorni, con l’indicazione della DataOraInizioUtilizzo, ordinando i risultati per classe e, a parità di classe, per data (mostrando prima le date più recenti)
//Q6(): Stampa per ogni classe quanti utilizzi di computer sono stati fatti negli ultimi 30 giorni.
//Q7(): Stampa la classe che ha utilizzato maggiormente i computer (quella con il maggior numero di utilizzi) negli ultimi 30 giorni.


//Q1(string classe): Stampa a Console il numero di alunni della classe in input; ad esempio, stampa il numero di alunni della 4IA

System.Console.WriteLine("QUERY 1");
Q1("3IA");

static void Q1(string classe)
{
    using UtilizziContext db = new();

    var nStudenti =
    db.Classi.Where(c => c.Nome == classe)
    .Join(db.Studenti ,c => c.Id ,s => s.ClasseId ,(c,s) => new {NomeClasse = c.Nome})
    .GroupBy(c => c.NomeClasse)
    .Select(c => new {Classe = c.Key, NumeroAlunni = c.Count()})
    .ToList();

    nStudenti.ForEach(c => Console.WriteLine(c.NumeroAlunni)); 
}

System.Console.WriteLine("QUERY 2");

//Q2(): Stampa a Console il numero di alunni per ogni classe
Q2();
static void Q2()
{
    using UtilizziContext db = new();

    var nStudentiPerClasse =
    db.Studenti.Join(db.Classi ,s => s.ClasseId ,c => c.Id ,(s,c) => new {NomeClasse = c.Nome})
    .GroupBy(s => s.NomeClasse)
    .Select(c => new {NomeClasse = c.Key , NumeroAlunni = c.Count()})
    .ToList();

    nStudentiPerClasse.ForEach(c => Console.WriteLine($"{c.NomeClasse} {c.NumeroAlunni}"));
}

//Q3(): Stampa gli studenti che non hanno ancora restituito i computer (sono quelli collegati a Utilizza con DataOraFineUtilizzo pari a null)
System.Console.WriteLine("QUERY 3");
Q3();
static void Q3()
{
    using UtilizziContext db = new();

    db.Utilizzi.Where(u => u.DataOraFineUtilizzo == null)
    .Join(db.Studenti ,u => u.StudenteId ,s => s.Id ,(u,s) => new {NomeStudente = s.Nome , CognomeStudente = s.Cognome})
    .ToList()
    .ForEach(c => Console.WriteLine($"{c.CognomeStudente} {c.NomeStudente} non ha ancora restituito il pc"));
}

System.Console.WriteLine("QUERY 4");

//Q4(string classe): Stampa l’elenco dei computer che sono stati utilizzati dagli studenti della classe specificata in input. Ad esempio, stampare l’elenco dei computer utilizzati dalla 4IA. Non mostrare ripetizioni nella stampa.

Q4("4IA");
static void Q4(string classe)
{
    using UtilizziContext db = new();
    
    db.Utilizzi.Where(c => c.Studente.Classe.Nome == classe)
    .Select(u => new {ModelloPC = u.Computer.Modello})
    .ToList()
    .ForEach(s => System.Console.WriteLine($"{s.ModelloPC} usato dalla {classe}"));
}

System.Console.WriteLine("QUERY 5");
Q5(61);
static void Q5(int computerId)
{
    using UtilizziContext db = new();

    var data = DateTime.Now.AddDays(-30);

	var utilizziGiorni =
	db.Utilizzi
	.Where(c => c.DataOraFineUtilizzo >= data)
	.Select(c => new {
		ClasseStudente = c.Studente.Classe.Nome ,
		NomeStudente = c.Studente.Nome ,
		DataOraUtilizzo = c.DataOraInizioUtilizzo ,
		DataOraFineUtilizzo = c.DataOraFineUtilizzo})
		.OrderBy(c => c.DataOraUtilizzo)
		.ToList();
		
		System.Console.WriteLine("Studenti che hanno utilizzato il PC negli ultimi 30 giorni ");

		foreach(var v in utilizziGiorni)
		{
			System.Console.WriteLine($"{v.ClasseStudente} {v.NomeStudente} {v.DataOraUtilizzo} {v.DataOraFineUtilizzo}");
		}

	
}

System.Console.WriteLine("QUERY 6");
//Q6(): Stampa per ogni classe quanti utilizzi di computer sono stati fatti negli ultimi 30 giorni.

Q6();
static void Q6()
{
	using UtilizziContext db = new();

	var timeSpan = DateTime.Now.AddDays(-30);
	var utilizziPerClasse =
	db.Utilizzi
	.Where(c => c.DataOraInizioUtilizzo >= timeSpan)
	.GroupBy(c => c.Studente.Classe.Nome)
	.Select(c => new {NomiClasse = c.Key , NumeroUtilizzi = c.Count()})
	.ToList();

	foreach(var v in utilizziPerClasse)
	{
	Console.WriteLine($"{v.NomiClasse} {v.NumeroUtilizzi}");
	}

}
System.Console.WriteLine("QUERY 7");
Q7();
//Q7(): Stampa la classe che ha utilizzato maggiormente i computer (quella con il maggior numero di utilizzi) negli ultimi 30 giorni.

static void Q7()
{
	using UtilizziContext db = new();

	var classeConPiuUtilizzi=
	db.Utilizzi.GroupBy(c => c.Studente.Classe.Nome)
	.Select(c => new {Classe = c.Key ,NumeroUtilizzi = c.Count()})
	.OrderByDescending(c => c.NumeroUtilizzi)
	.FirstOrDefault();

	if(classeConPiuUtilizzi != null)
	{
		Console
		.WriteLine($"La Classe con piu utilizzi è la {classeConPiuUtilizzi.Classe} con {classeConPiuUtilizzi.NumeroUtilizzi}");
	}


}