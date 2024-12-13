using System;
using System.Threading;
namespace JoinCountDemo
{
 class Program
 {
 static int A, B, C, D, E, F, Z;
 static CountdownEvent L = new CountdownEvent(3);
 static void Main(string[] args)
 {
 A = 10;
 Thread t = new Thread(Proc1);
 t.Start();
 D = A * 4;
 Console.WriteLine("D: {0}", D);
 L.Signal(); // Decrementa il contatore L
 L.Wait(); // Attende che il contatore L sia uguale a zero
 Z = D + E + F;
 Console.WriteLine("Z: {0}", Z);
 }
 static void Proc1()
 {
 Console.WriteLine("Procedura n. 1");
 B = A + 20;
 Thread t = new Thread(Proc2);
 t.Start();
 E = B - 5;
 Console.WriteLine("E: {0}", E);
 L.Signal(); // Decrementa il contatore L
 }
 static void Proc2()
 {
 Console.WriteLine("Procedura n. 2");
 C = A + B;
 F = C + 6;
 Console.WriteLine("F: {0}", F);
 L.Signal(); // Decrementa il contatore L
 }
 }
}