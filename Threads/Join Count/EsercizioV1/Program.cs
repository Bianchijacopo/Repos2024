
internal class Program
{
     static SemaphoreSlim postiLiberi = new(5,5);
     static int bambiniInAttesa = 0;
    private static readonly object _lock = new object();
        private static void Main(string[] args)
    {
         for (int i = 0;i<5;i++)
        {
            new Thread (KidWork).Start(i);
            Thread.Sleep(1000);
        }
        Console.ReadLine();
    }

    private static void KidWork(object? obj)
    {
        //leggo il dato in input 
        int? indice = obj as int?;
        //leggo quanti bambini sono in coda
        bool miMettoInCoda = false;
        //mutex viene usato per l'accesso alla sezione critica
        lock (_lock)
        {
             if(bambiniInAttesa <10)
        {
            miMettoInCoda = true;
            bambiniInAttesa++;
            Console.WriteLine($"Sono il bambino con id {Thread.CurrentThread.ManagedThreadId} e indice {indice} e mi sono messo in coda");

        }
        else
         {
            System.Console.WriteLine($"sono il bimbo con id {Environment.CurrentManagedThreadId}E  ME NE VADO DA STO POSO CHE NON C'è MAI POSTO ");
        }
        }
        if(miMettoInCoda)
        {
            postiLiberi.Wait();
            lock(_lock)
            {
                bambiniInAttesa--;
             //se supera la wait entra nella giostra
        System.Console.WriteLine("OOOOOOOOOOOOOOO SONO ENTRATO E MI DIVERTOOOOOOOOOOOOOOOO AAAAAAAAAAAAAA");
        Random gen = new Random();
        Thread.Sleep(gen.Next(1,4)*1000);
        //il giro è finito :(
        //libero un posto e me ne vado 
        postiLiberi.Release();
        System.Console.WriteLine("HEY ME NE SONO ANDATO NOOOOOOOO");
        }
            }
            
    }
}