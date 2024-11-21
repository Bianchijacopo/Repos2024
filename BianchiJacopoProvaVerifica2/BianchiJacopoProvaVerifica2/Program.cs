using BianchiJacopoProvaVerifica2.Data;
using BianchiJacopoProvaVerifica2.Model;

static void PopulateDb()
{

    using RomanziContext db = new();

    List<Autore> autori =
        [
            new (){AutoreId=1, Nome="Ernest",Cognome="Hemingway", Nazionalità="Americana"},//AutoreId=1
            new (){AutoreId=2,Nome="Philip",Cognome="Roth", Nazionalità="Americana"},//AutoreId=2
            new (){AutoreId=3,Nome="Thomas",Cognome="Owen", Nazionalità="Belga"},//AutoreId=3
            new (){AutoreId=4,Nome="William",Cognome="Shakespeare", Nazionalità="Inglese"},//AutoreId=4
            new (){AutoreId=5,Nome="Charles",Cognome="Dickens", Nazionalità="Inglese"},//AutoreId=5
        ];

        autori.ForEach(a => db.Add(a));
        db.SaveChanges();
        //Almeno 10 romanzi degli autori precedentemente inseriti
        List<Romanzo> romanzi =
        [
            new (){RomanzoId=1, Titolo="For Whom the Bell Tolls", AnnoPubblicazione=1940, AutoreId=1},//RomanzoId=1
            new (){RomanzoId=2,Titolo="The Old Man and the Sea", AnnoPubblicazione=1952, AutoreId=1},
            new (){RomanzoId=3,Titolo="A Farewell to Arms",AnnoPubblicazione=1929, AutoreId=1},
            new (){RomanzoId=4,Titolo="Letting Go", AnnoPubblicazione=1962, AutoreId=2},
            new (){RomanzoId=5,Titolo="When She Was Good", AnnoPubblicazione=1967, AutoreId=2},
            new (){RomanzoId=6,Titolo="Destination Inconnue", AnnoPubblicazione=1942, AutoreId=3},
            new (){RomanzoId=7,Titolo="Les Fruits de l'orage", AnnoPubblicazione=1984, AutoreId=3},
            new (){RomanzoId=8,Titolo="Giulio Cesare", AnnoPubblicazione=1599, AutoreId=4},
            new (){RomanzoId=9,Titolo="Otello", AnnoPubblicazione=1604, AutoreId=4},
            new (){RomanzoId=10,Titolo="David Copperfield", AnnoPubblicazione=1849, AutoreId=5},
        ];
        romanzi.ForEach(r => db.Add(r));
        db.SaveChanges();
        //Almeno 5 personaggi presenti nei romanzi precedentemente inseriti
        List<Personaggio> personaggi =
        [
            new (){PersonaggioId=1, Nome="Desdemona", Ruolo="Protagonista", Sesso="Femmina", RomanzoId=9},//PersonaggioId=1
            new (){PersonaggioId=2,Nome="Jago", Ruolo="Protagonista", Sesso="Maschio", RomanzoId=9},
            new (){PersonaggioId=3,Nome="Robert", Ruolo="Protagonista", Sesso="Maschio", RomanzoId=1},
            new (){PersonaggioId=4,Nome="Cesare", Ruolo="Protagonista", Sesso="Maschio", RomanzoId=8},
            new (){PersonaggioId=5,Nome="David", Ruolo="Protagonista", Sesso="Maschio", RomanzoId=10}
        ];
        personaggi.ForEach(p => db.Add(p));
        db.SaveChanges();
    }

    /*
    Q1: creare un metodo che prende in input la nazionalità e stampa gli autori che hanno la nazionalità specificata
    Q2: creare un metodo che prende in input il nome e il cognome di un autore e stampa tutti i romanzi di quell’autore
    Q3: creare un metodo che prende in input la nazionalità e stampa quanti romanzi di quella nazionalità sono presenti nel database
    Q4: creare un metodo che per ogni nazionalità stampa quanti romanzi di autori di quella nazionalità sono presenti nel database
    Q5: creare un metodo che stampa il nome dei personaggi presenti in romanzi di autori di una data nazionalità
    */

    //Q1: creare un metodo che prende in input la nazionalità e stampa gli autori che hanno la nazionalità specificata
    System.Console.WriteLine("QUERY 1");
    Q1("Americana");
    static void Q1(string nazionalita)
    {
        using RomanziContext db = new();

        db.Autori.Where(a => a.Nazionalità == nazionalita)
        .Select(t => new {Nome = t.Nome ,Cognome = t.Cognome})
        .ToList()
        .ForEach(t => Console.WriteLine($"{t.Nome} {t.Cognome}"));
    }
    System.Console.WriteLine("QUERY 2");

    //Q2: creare un metodo che prende in input il nome e il cognome di un autore e stampa tutti i romanzi di quell’autore

    Q2("Ernest","Hemingway");
    static void Q2(string nome ,string cognome )
    {
        using RomanziContext db = new();

        db.Autori.Where(a => a.Nome == nome && a.Cognome == cognome)
        .Join(db.Romanzi ,a => a.AutoreId ,r => r.AutoreId ,(a,r) => new {Titolo = r.Titolo})
        .ToList()
        .ForEach(t => Console.WriteLine($"{t.Titolo}"));

    }

    Q2("Ernest","Hemingway");

    //Q3: creare un metodo che prende in input la nazionalità e stampa quanti romanzi di quella nazionalità sono presenti nel database

    System.Console.WriteLine("QUERY 3");
    Q3("Americana");
    static void Q3(string nazionalita)
    {
        using RomanziContext db = new();

        db.Autori.Where(a => a.Nazionalità == nazionalita)
        .Join(db.Romanzi,a => a.AutoreId ,r => r.AutoreId ,(a,r) => new {Titolo = r.Titolo})
        .ToList()
        .ForEach(t => Console.WriteLine($"{t.Titolo}"));
    }


    System.Console.WriteLine("QUERY 4");

    //Q4: creare un metodo che per ogni nazionalità stampa quanti romanzi di autori di quella nazionalità sono presenti nel database

    Q4();
    static void Q4()
    {
        using RomanziContext db = new();

        var gruppoNazioni = 
        db.Autori.GroupBy(a => a.Nazionalità)
        .Select(a => new {Nazionalita = a.Key , NumeroRomanzi = a.Count()})
        .ToList();

        foreach(var  gruppo in gruppoNazioni)
        {
            System.Console.WriteLine($"{gruppo.Nazionalita} {gruppo.NumeroRomanzi}");
        }

    }

    //Q5: creare un metodo che stampa il nome dei personaggi presenti in romanzi di autori di una data nazionalità
    
    System.Console.WriteLine($"QUERY 5");

    Q5("Inglese");

    static void Q5(string nazionalita)
    {
        using RomanziContext db = new();

        db.Autori.Where(a => a.Nazionalità == nazionalita)
        .Join(db.Romanzi ,a => a.AutoreId ,r => r.AutoreId ,(a,r) => new {RomanzoId = r.RomanzoId})
        .Join(db.Personaggi ,r => r.RomanzoId ,p => p.RomanzoId ,(a,p) => new {NomePersonaggio = p.Nome})
        .ToList()
        .ForEach(t => Console.WriteLine($"{t.NomePersonaggio}"));
    }


    
