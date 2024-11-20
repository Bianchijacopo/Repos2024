using OpereProject_v1_0.Model;

    IList<Artista> artisti =
    [
        new (){Id=1, Cognome="Picasso", Nome="Pablo", Nazionalita="Spagna"},
        new (){Id=2, Cognome="Dalì", Nome="Salvador", Nazionalita="Spagna"},
        new (){Id=3, Cognome="De Chirico", Nome="Giorgio", Nazionalita="Italia"},
        new (){Id=4, Cognome="Guttuso", Nome="Renato", Nazionalita="Italia"}
    ];
//poi le collection che hanno Fk
IList<Opera> opere =
    [
        new (){Id=1, Titolo="Guernica", Quotazione=50000000.00m , FkArtista=1},//opera di Picasso
        new (){Id=2, Titolo="I tre musici", Quotazione=15000000.00m, FkArtista=1},//opera di Picasso
        new (){Id=3, Titolo="Les demoiselles d’Avignon", Quotazione=12000000.00m,  FkArtista=1},//opera di Picasso
        new (){Id=4, Titolo="La persistenza della memoria", Quotazione=16000000.00m,  FkArtista=2},//opera di Dalì
        new (){Id=5, Titolo="Metamorfosi di Narciso", Quotazione=8000000.00m, FkArtista=2},//opera di Dalì
        new (){Id=6, Titolo="Le Muse inquietanti", Quotazione=22000000.00m,  FkArtista=3},//opera di De Chirico
    ];
IList<Personaggio> personaggi =
    [
        new (){Id=1, Nome="Uomo morente", FkOperaId=1},//un personaggio di Guernica 
        new (){Id=2, Nome="Un musicante", FkOperaId=2},
        new (){Id=3, Nome="una ragazza di Avignone", FkOperaId=3},
        new (){Id=4, Nome="una seconda ragazza di Avignone", FkOperaId=3},
        new (){Id=5, Nome="Narciso", FkOperaId=5},
        new (){Id=6, Nome="Una musa metafisica", FkOperaId=6},
    ];

    System.Console.WriteLine("QUERY 1");
    //1) Stampare le opere di un dato autore (ad esempio Picasso)

    var opereArtista = 
    artisti.Where(o => o.Cognome == "Picasso")
    .Join(opere, a => a.Id, o => o.FkArtista ,(a,o) => new {Titolo = o.Titolo})
    .ToList();

    opereArtista.ForEach(t => System.Console.WriteLine($"{t.Titolo}"));


    //2) Riportare per ogni nazionalità (raggruppare per nazionalità) gli artisti

     System.Console.WriteLine("QUERY 2");
    var artistiNazione = 
    artisti.GroupBy(a => a.Nazionalita);

    foreach(var g in artistiNazione)
    {
        System.Console.Write($"{g.Key} --> ");
        foreach(var v in g)
        {
            System.Console.Write($"[{v.Nome} {v.Cognome}] ");
        }
        System.Console.WriteLine();
    }

    //3) Contare quanti sono gli artisti per ogni nazionalità (raggruppare per nazionalità e contare)
     System.Console.WriteLine("QUERY 3");
    var nazionalitaArtisti =
    artisti.GroupBy(a => a.Nazionalita)
    .Select(s => new {NazionalitaArtista = s.Key , NumeroArtisti = s.Count() })
    .ToList();

    nazionalitaArtisti.ForEach(t => System.Console.WriteLine($"{t.NazionalitaArtista} {t.NumeroArtisti}"));





