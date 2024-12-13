using System;
using System.Threading;

internal class Program
{
    static int postiDisponibili = 5;
    static int postiOccupati = 0;
    static bool negozioAperto = true;
    static readonly object _lock = new object();
    static int acconto = 0;
    static int numeroClienti = 0;
    static SemaphoreSlim negozio = new SemaphoreSlim(postiDisponibili, postiDisponibili);

    public static void Main(string[] args)
    {
        Thread entraCliente = new Thread(() => EntraClienteWork());
        Thread esceCliente = new Thread(() => EsciClienteWork());
        Thread chiudiNegozio = new Thread(() => ChiudiNegozioWork());

        entraCliente.Start();
        esceCliente.Start();
        chiudiNegozio.Start();

        entraCliente.Join();
        esceCliente.Join();
        chiudiNegozio.Join();
    }

    public static void EntraClienteWork()
    {
        while (true)
        {
            negozio.Wait(); 
            Thread.Sleep(1500);

            lock (_lock)
            {
                if (negozioAperto)
                {
                    Console.WriteLine("Un cliente è entrato nel negozio");
                    postiOccupati++;
                    postiDisponibili--;
                    acconto += 20;
                    System.Console.WriteLine($"numero clienti : {postiOccupati}");
                }
                else
                {
                    Console.WriteLine("Il cliente ha trovato chiuso e se ne va");
                    negozio.Release();
                }
            }
        }
    }

    public static void EsciClienteWork()
    {
        while (true)
        {
            Random random = new Random();
            int tempo = random.Next(1,6);
            Thread.Sleep(tempo * 1000); 

            lock (_lock)
            {
                if (postiOccupati > 0)
                {
                    Console.WriteLine($"Il cliente esce e paga 20 euro. È stato dentro per {tempo} secondi.");
                    postiOccupati--;
                    postiDisponibili++;
                    System.Console.WriteLine($"numero clienti : {postiOccupati}");
                    negozio.Release(); 
                }
                else if (postiOccupati == 0)
                {
                    Console.WriteLine("Il negozio non ha più clienti");
                }
                if(negozioAperto ==false)
                {
                    System.Console.WriteLine("il negozio non ha piu clienti quindi chiude ");
                     System.Console.WriteLine($"numero clienti : {postiOccupati}");
                }
            }
        }
    }

    public static void ChiudiNegozioWork()
    {
        Thread.Sleep(15000); 
        lock (_lock)
        {
            Console.WriteLine("Il negozio è chiuso.");
            Console.WriteLine($"L'acconto totale è {acconto} euro.");
        }
    }
}
