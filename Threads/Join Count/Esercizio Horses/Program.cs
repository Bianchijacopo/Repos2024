
class Program 
{
    static SemaphoreSlim postiLiberi = new(5,5);
    static void Main(string[] args)
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
        int? indice = obj as int?;
        Console.WriteLine($"Sono il bambino con id {Thread.CurrentThread.ManagedThreadId} e indice {indice} e mi sono messo in coda");
        //attende che ci sia posto 
        postiLiberi.Wait();
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