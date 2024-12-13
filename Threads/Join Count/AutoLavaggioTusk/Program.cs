
class CarData
{
    public int CarId { get; set; }
    public long CreationTime { get; set; } 
}
internal class Program
{
    //sezione critica???????????
    static bool autolavaggioAperto = true;
    private static readonly object _lockAutolavaggio = new object();
    const int numeroMassimoAutoInParcheggio = 20;
    static int postiDisponibili = numeroMassimoAutoInParcheggio;
    private static readonly object _lockPostiDisponibili = new object();
    //milliseconds
    const int maxCarDelay = 300;
    const int minCarDelay = 100;

    static SemaphoreSlim tunnelReady = new SemaphoreSlim(1,1);
    static SemaphoreSlim waitingCarsReady = new SemaphoreSlim(0,numeroMassimoAutoInParcheggio);

    const int tunnelDelay = 400;

    private static void Main(string[] args)
    {
        Task tunnel = Task.Factory.StartNew(() => TunnelWork());
         Random gen = new Random();
        for(int i = 0 ; i < 59 ; i++)
        {
            Task.Factory.StartNew(CarWork, new CarData() {CarId = i,CreationTime = DateTime.Now.Ticks});
            Thread.Sleep(gen.Next(minCarDelay,maxCarDelay+1));
        }

       // Thread.Sleep(10000);

        Task.Delay(10000).Wait(); //--> è preferibile  a thread sleep perche piu task possono andare sullo stesso thread 
        //attendo che il tunnel finisca
        lock(_lockAutolavaggio)
        {
            autolavaggioAperto = false;
        }
        tunnel.Wait(); //--> wait dei tunnel diversa dalla wait dei semafori 
    }

    private static void CarWork(object obj)
    {
        CarData? carData = obj as CarData;
        bool siFerma = false;
        bool hoTrovatoPosto =false; ;
        lock(_lockAutolavaggio)
        {
            siFerma = autolavaggioAperto;
        }
        if(siFerma)
        {
            lock(_lockPostiDisponibili)
            {
                postiDisponibili--;
                hoTrovatoPosto = true;
            }
            if(hoTrovatoPosto)//mi fermo
            {
                waitingCarsReady.Release();
                //aspetto che il tunnel mi lavi 
                tunnelReady.Wait();
                //se supero la wait sono dentro al tunnel
                var tempoAttesa = DateTime.Now.Ticks - carData.CreationTime; 
            System.Console.WriteLine($"Sono l'auto con indice {carData.CarId} su taskId {Task.CurrentId} , e sono dentro, ho aspettato {tempoAttesa} ticks");


            } 
            else // me ne vado 
            {
                System.Console.WriteLine("me ne vado ");
            }
        }
        else
        {
            System.Console.WriteLine($"Sono l'auto con indice {carData.CarId} su taskId {Task.CurrentId} , ho trovato l'autolavaggio chiuso e me ne vado");
        }
    }

    private static void TunnelWork()
    {
            //devo verificare se sono aperto o chiuso 
            //per saperlo devo entrare in sezione critica
           bool aperto = false;
            lock(_lockAutolavaggio)
            {
                aperto = autolavaggioAperto;
            }
            while(aperto)
            {
                //attendo che ci sia una macchina 
                waitingCarsReady.Wait();
                //il tunnel libera un posto 
                lock(_lockPostiDisponibili)
                {
                    postiDisponibili++;
                }
                //sto lavando un'auto
                System.Console.WriteLine($"il tunnel {Task.CurrentId} lava l'auto ");
                Thread.Sleep(tunnelDelay);
                tunnelReady.Release();
                //devo ricontrollare se sono aperto 
                lock(_lockAutolavaggio)
                {
                    aperto = autolavaggioAperto; 
                }
            }
    }
}