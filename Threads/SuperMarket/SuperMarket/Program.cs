
internal class Program
{
    static int incassoTotale = 0;
    static readonly object _lock = new object();
    static SemaphoreSlim semCliente = new SemaphoreSlim(1, 1);
    static SemaphoreSlim semBancone = new SemaphoreSlim(0, 1);

    static Random random = new Random();
    static int costoProdotto;
    private static void Main(string[] args)
    {
        Thread bancone = new Thread(() => BanconeWork());
        Thread cliente = new Thread(() => CLIenteWork());
        bancone.Start();
        cliente.Start();
    }

    private static void CLIenteWork()
    {
        while (incassoTotale <100)
        {
            semCliente.Wait();
            System.Console.WriteLine("sono il cliente e metto le cose sulla cassa");
            Thread.Sleep(1000);
            lock (_lock)
            {
                costoProdotto = random.Next(1, 101);
                incassoTotale += costoProdotto;
            }
            System.Console.WriteLine($"ho pagato {costoProdotto} euro e me ne vado");
            semBancone.Release();
        }
    }

    private static void BanconeWork()
    {
        while (incassoTotale < 100)
        {
            semBancone.Wait();
            System.Console.WriteLine($"sono il cassiere e ho prelevato {costoProdotto} euro dal cliente");
            System.Console.WriteLine($"incasso attuale : {incassoTotale}");
            semCliente.Release();
        }
    }
}