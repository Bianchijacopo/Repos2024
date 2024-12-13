using System;
using System.Threading;

namespace ProducerConsumerFIFO
{
    class Program
    {
        static readonly object _lock = new();
        static int bufferSize = 10;
        static int[] buffer = new int[bufferSize];
        static SemaphoreSlim emptyPosCount = new(bufferSize, bufferSize); //all'inizio è 10 , perche non ce dentro nulla (ovvio)
        static SemaphoreSlim fillPosCount = new(0, bufferSize); //all'inizio è 0 , ovvio piu di prima
        static int writePos = 0;
        static int readPos = 0;

        static void Main(string[] args)
        {
            Thread producer = new(ProducerWork) { Name = "Producer" };
            Thread consumer = new(ConsumerWork) { Name = "Consumer" };
            producer.Start();
            consumer.Start();
            // Attendiamo la fine dei thread producer e consumer
            producer.Join();
            consumer.Join();
            Console.WriteLine("Fine");
        }

        private static void ConsumerWork()
        {
            while (true)
            {
                //leggo se c'è qualcosa da leggere
                fillPosCount.Wait();
                //entro in sezione critica 
                lock (_lock)
                {
                    //simulo la lettura dal buffer
                    buffer[readPos] = 0;
                    Console.WriteLine($"{Thread.CurrentThread.Name} prelevato un elemento dalla posizione {readPos}");
                    readPos = (readPos + 1) % bufferSize;
                    PrintArray(buffer);
                    
                }
                //segnalo all'altro thread che c'è una nuova cella libera
                emptyPosCount.Release();
                Thread.Sleep(500);
            }
        }

        private static void ProducerWork()
        {
            //in sezione critica si fa solo il minimo indispensabile
            while (true)
            {
                //la wait riduce di 1 la variabile di conteggio del sempaforo
                emptyPosCount.Wait();
                lock (_lock)
                {
                    //ci metto dentro il pezzo
                    buffer[writePos] = 1;
                    writePos = (writePos + 1) % bufferSize;
                    Console.WriteLine($"{Thread.CurrentThread.Name} aggiunto un elemento in posizione {writePos}");
                    PrintArray(buffer);
                }
                //segnalo all'altro thread che c'è un pezzo prodotto
                //incremento la variabile di conteggio , segnalo all'altro thread che è successo qualcosa
                fillPosCount.Release();
                Thread.Sleep(1000);

            }
        }

        static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}