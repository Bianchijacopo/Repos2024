class Program
{
    private static int sum;

    private static readonly object lockv1 = new object();
    static void Main(string[] args)
    {
        //create thread t1 using anonymous method
        Thread t1 = new Thread(() =>
        {
            for (int i = 0; i < 10000000; i++)
            {
                //acquire lock ownership
                Monitor.Enter(lockv1);
                //increment sum value
                sum++;
                //release lock ownership
                Monitor.Exit(lockv1);
            }
        });
        //create thread t2 using anonymous method
        Thread t2 = new Thread(() =>
        {
            for (int i = 0; i < 10000000; i++)
            {
                //acquire lock ownership
                Monitor.Enter(lockv1);
                //increment sum value
                sum++;
                //release lock ownership
                Monitor.Exit(lockv1);
            }
        });
        //start thread t1 and t2
        t1.Start();
        t2.Start();
        //wait for thread t1 and t2 to finish their execution
        t1.Join();
        t2.Join();
        //write final sum on screen
        Console.WriteLine("sum: " + sum);
        Console.WriteLine("Press enter to terminate!");
        Console.ReadLine();
    }
}