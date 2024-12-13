//version 1
// using System.Net.WebSockets;

// internal class Program
// {
//     const int numberOfSeats = 10;
//     //numero di sedie libere
//     static int freeSeats = numberOfSeats;
//     //seat access serve per gestire lìaccesso alla variabile free seats in mutua esclusione
//     static SemaphoreSlim seatAccess = new SemaphoreSlim(1, 1);  //funziona come un lock
//     //è il semaforo che notifica la disponibilita del barbiere
//     static SemaphoreSlim barberReady = new SemaphoreSlim(1, 1);
//     //vede se ci sono clienti in attesa 
//     static SemaphoreSlim clientReady = new SemaphoreSlim(0, numberOfSeats);

//     private static void Main(string[] args)
//     {
//         //creiamo un thread per il barbiere

//         Thread barbiere = new(BarberWork) { Name = "Barbiere"};
//         barbiere.Start();
//         int numberOfSeats = 30;
//     //creiamo piu thread per simulare l'arrivo dei clienti 


//         for(int i=0;i<numberOfSeats; i++)
//         {
//             new Thread(ClientWork).Start();
//             Thread.Sleep(500);
//         }
//     }

//     private static void ClientWork(object? obj)
//     {
//         while(true)
//         {
//             //il cliente vede se c'è un posto libero 
//             //apro una sezione criticai
//             seatAccess.Release();
//             if(freeSeats>0)
//             {
//                 freeSeats--;
//                 Console.WriteLine($"sono il cliente con id : {Thread.CurrentThread.ManagedThreadId} e attendo di avere il cut");
//                 //esco dalla sezione critica
//                 seatAccess.Release();
//                 barberReady.Wait();
//                 System.Console.WriteLine($"sono il ciente {Thread.CurrentThread.ManagedThreadId} e il barbiere mi sta creando il cut");
//             }else  // non ho trovato posto 
//             {
//                 seatAccess.Release();
//                 System.Console.WriteLine($"sono il ciente {Thread.CurrentThread.ManagedThreadId} e non ho trovato posto");
                
//             }
//             //se c'è lo occupa
//             //resta su quel posto finche il barbiere non è disponibile
//         }
//     }

//     private static void BarberWork(object? obj)
//     {
//         while(true)
//         {
//             //attende che ci sia un cliente pronto in attesa
//             clientReady.Wait();
//             //comincia il taglio dei capelli e cosi libera un posto da freeseats
//             seatAccess.Wait();
//             freeSeats++;
//             Console.WriteLine("il barbiere libera un posto"); 
//             //esco dalla sezione critica
//             seatAccess.Release();
//             Console.WriteLine($"{Thread.CurrentThread.Name} : sto tagliando i capelli a un cliente!");
//             //alla fine il barbiere è disponibile per un nuovo ciclo 
//             Thread.Sleep(2000);
//             barberReady.Release();
//         }
//     }
// }


using System.Net.WebSockets;

internal class Program
{
    const int numberOfSeats = 10;
    //numero di sedie libere
    static int freeSeats = numberOfSeats;
    static readonly object _lock = new();
    //è il semaforo che notifica la disponibilita del barbiere
    static SemaphoreSlim barberReady = new SemaphoreSlim(1, 1);
    //vede se ci sono clienti in attesa 
    static SemaphoreSlim clientReady = new SemaphoreSlim(0, numberOfSeats);

    private static void Main(string[] args)
    {
        //creiamo un thread per il barbiere

        Thread barbiere = new(BarberWork) { Name = "Barbiere"};
        barbiere.Start();
        int numberOfSeats = 30;
    //creiamo piu thread per simulare l'arrivo dei clienti 


        for(int i=0;i<numberOfSeats; i++)
        {
            new Thread(ClientWork).Start();
            Thread.Sleep(500);
        }
    }

    private static void ClientWork(object? obj)
    {
        bool siSiede = false;
        while(true)
        {
            //il cliente vede se c'è un posto libero 
            //apro una sezione criticai
           lock(_lock)
           {    
            if(freeSeats>0)
            {
                freeSeats--;
                siSiede = true;
            }
            else 
            {
                System.Console.WriteLine($"sono il ciente {Thread.CurrentThread.ManagedThreadId} e non ho trovato posto");
            }
           }
           }
    }

    private static void BarberWork(object? obj)
    {
        while(true)
        {
            //attende che ci sia un cliente pronto in attesa
            clientReady.Wait();
            //comincia il taglio dei capelli e cosi libera un posto da freeseats
           lock(_lock)
           {
            //il barbiere fa accomodare sulla poltrona di taglio
            freeSeats++;
            System.Console.WriteLine("Iol barbiere libera un posto");
           }
            Console.WriteLine($"{Thread.CurrentThread.Name} : sto tagliando i capelli a un cliente!");
            //alla fine il barbiere è disponibile per un nuovo ciclo 
            Thread.Sleep(2000);
            barberReady.Release();
        }
    }
}
