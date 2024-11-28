

internal class Program
{
    //area di memoria condivisa fra i threads
    static int BufferSize = 10;
    static int[] buffer = new int[BufferSize];
    //due semafori , uno per gestire il produttore e uno per il consumatore

    //questo ci dice quante celle vuote ci sono
    static SemaphoreSlim emptyPositionCount = new(BufferSize,BufferSize);

    //questo ci dice quante celle piene ci sono
    static SemaphoreSlim fillPosCount = new(0,BufferSize);

    private static readonly object _lock = new object();

    static int firstEmptyPos = 0;
    private static void Main(string[] args)
    {
        //producer esegue il codice del metodo ProducerWork
        Thread producer = new (ProducerWork) {Name = "Producer"}; //--> producer.Name = "Producer";
        //consumer esegue il codice del metodo ConsumerWork

        Thread consumer = new (ConsumerWork) {Name = "Consumer"};

        producer.Start();
        consumer.Start();
        producer.Join();
        consumer.Join();
        System.Console.WriteLine("Fine");

    }

    private static void ConsumerWork(object? obj)
    {
        //qui mettiamo il codice eseguito dal consumatore

        //se c'è un elemento nel buffer leggo

       while(true)
       {
        fillPosCount.Wait();

        lock(_lock)
        {
            firstEmptyPos--;
            buffer[firstEmptyPos] = 0;
            Console.WriteLine($"{Thread.CurrentThread.Name}: Consumato un elemento in posizione {firstEmptyPos}");
            PrintArray(buffer);

        }
        //segnalare all'altro thread che ho liberato una posizione
        emptyPositionCount.Release();
        Thread.Sleep(2000);
       }
    }

    private static void ProducerWork(object? obj)
    {
        //qui mettiamo il codice eseguito dal produttore

        while(true)
        {
            //se c'è posto scrivo
            emptyPositionCount.Wait();
            //accedo alla sezione critica
            lock(_lock)
            {
                buffer[firstEmptyPos] = 1;
                Console.WriteLine($"{Thread.CurrentThread.Name}: Aggiunto un elemento in posizione {firstEmptyPos}");
                PrintArray(buffer);
                firstEmptyPos++;
            }
        //segnalo all'altro thread che c'è un nuovo elemento nel buffer

        fillPosCount.Release();

        //pausa per simulare la velocità di scrittura
        Thread.Sleep(1000);
        }

    }

    private static void PrintArray(int[] buffer)
    {
        for(int i=0;i<buffer.Length;i++)
        {
            Console.WriteLine(buffer[i] );
        }
        System.Console.WriteLine();
    }
}