using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static SemaphoreSlim goA = new SemaphoreSlim(1,1);
    static SemaphoreSlim goB = new SemaphoreSlim(0,2);
    static SemaphoreSlim goC = new SemaphoreSlim(0,1);
    private static void Main(string[] args)
    {
        Parallel.Invoke(scriviA,scriviB,scriviC);
    }
    private static void scriviA()
    {
        while (true)
        {
            goA.Wait();
            Console.Write("A");
            Random gen = new Random();
            int milliseconds = gen.Next(0,1000);
            Thread.Sleep(milliseconds);
            //segnalo al thread b che puo scrivere due volte
            goB.Release(2);
        }
    }
    private static void scriviB()
    {
        while (true)
        {
            goB.Wait();
            Console.Write("B");
            Random gen = new Random();
            int milliseconds = gen.Next(0,1000);
            Thread.Sleep(milliseconds);
            if(goB.CurrentCount ==0)
            {
                goC.Release();
            }

        }
    }
    private static void scriviC()
    {
        while (true)
        {
            goC.Wait();
            Console.Write("C");
            Random gen = new Random();
            int milliseconds = gen.Next(0,1000);
            Thread.Sleep(milliseconds);
            goA.Release();
        }
    }
}