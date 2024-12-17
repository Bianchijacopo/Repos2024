
internal class Program
{
    static SemaphoreSlim goGiovanni = new SemaphoreSlim(1, 1);
    static SemaphoreSlim goMattia = new SemaphoreSlim(0, 1);
    static SemaphoreSlim goAlessandro = new SemaphoreSlim(0, 1);
    static SemaphoreSlim goRoberto = new SemaphoreSlim(0, 1);
    static bool haFischiato = false;
    private static readonly object _lockFischio = new object();

    public static void Main(string[] args)
    {
        //simulo il fatto che dopo 10 secondi l'arbitro fischia
        Task.Factory.StartNew(() => 
        {
            Task.Delay(1000).Wait();
            lock(_lockFischio)
            {
                haFischiato = true;
            }
        });
        Parallel.Invoke(() => GiovanniPlay(), () => MattiaPlay(), () => AlessandroPlay(), () => RobertoPlay());

    }

    private static void RobertoPlay()
    {
        bool fischiato = false;
        lock (_lockFischio)
        {
            fischiato = haFischiato;
        }
        while (!fischiato)
        {
            fischiato = haFischiato;
            //attendo il mio turno 
            goRoberto.Wait();
            //appena passo il wait ho passato il semaforo e sono in 
            System.Console.WriteLine($"sono roberto e passo la palla a giovanni");
            Random random = new Random();
            int tempoCasuale = random.Next(100,301);
            Thread.Sleep(tempoCasuale);
            goGiovanni.Release();
            System.Console.WriteLine($"ho tenuto la palla per {tempoCasuale} millisecondi");
        }
    }

    private static void AlessandroPlay()
    {
        bool fischiato = false;
        lock (_lockFischio)
        {
            fischiato = haFischiato;
        }
        while (!fischiato)
        {
            fischiato = haFischiato;
            //attendo il mio turno 
            goAlessandro.Wait();
            //appena passo il wait ho passato il semaforo e sono in 
            System.Console.WriteLine($"sono alessandro e passo la palla a roberto");
            Random random = new Random();
            int tempoCasuale = random.Next(100,301);
            Thread.Sleep(tempoCasuale);
            goRoberto.Release();
            System.Console.WriteLine($"ho tenuto la palla per {tempoCasuale} millisecondi");
        }
    }

    private static void MattiaPlay()
    {
        bool fischiato = false;
        lock (_lockFischio)
        {
            fischiato = haFischiato;
        }
        while (!fischiato)
        {
            fischiato = haFischiato;
            //attendo il mio turno 
            goMattia.Wait();
            //appena passo il wait ho passato il semaforo e sono in 
            System.Console.WriteLine($"sono mattia e passo la palla a roberto");
            Random random = new Random();
            int tempoCasuale = random.Next(100,301);
            Thread.Sleep(tempoCasuale);
            goAlessandro.Release();
            System.Console.WriteLine($"ho tenuto la palla per {tempoCasuale} millisecondi");
        }
    }

    private static void GiovanniPlay()
    {
        bool fischiato = false;
        lock (_lockFischio)
        {
            fischiato = haFischiato;
        }
        while (! fischiato)
        {
            fischiato = haFischiato;
            //attendo il mio turno 
            goGiovanni.Wait();
            //appena passo il wait ho passato il semaforo e sono in 
            System.Console.WriteLine($"sono giovanni e passo la palla a mattia");
            Random random = new Random();
            int tempoCasuale = random.Next(100,301);
            Thread.Sleep(tempoCasuale);
            goMattia.Release();
            System.Console.WriteLine($"ho tenuto la palla per {tempoCasuale} millisecondi");
        }
    }
}