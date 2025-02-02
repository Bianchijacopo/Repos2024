﻿using System;
using System.Threading.Tasks;
namespace ParallelDemo
{
 class Program
 {
 static int A, B, C, D, E, F, G, Z;
 static void Main(string[] args)
 {
 A = 1;
 // Esecuzione parallela delle tre procedure, equivalente a:
 // cobegin
 // Proc1();
 // Proc2();
 // Proc3();
 // coend
 // Il metodo Invoke esegue le tre procedure, normalmente in parallelo.
 // Il main thread attende il completamento di tutte le procedure indicate.

 Thread pro1 = new Thread(Proc1);
 Thread pro2 = new Thread(Proc3);
 Thread pro3 = new Thread(Proc3);

 pro1.Start();
 pro2.Start();
 pro3.Start();

 pro1.Join();
 pro2.Join();
 pro3.Join();

//è equivalente a fare il parallel invoke 

 Parallel.Invoke(Proc1, Proc2, Proc3);
 Z = E + F + G;
 Console.WriteLine("Z: {0}", Z);
 }
 static void Proc1()
 {
 B = 2;
 E = A + B;
 Console.WriteLine("E: {0}", E);
 }
 static void Proc2()
 {
 C = 3;
 F = A + 3 * C;
 Console.WriteLine("F: {0}", F);
 }
 static void Proc3()
 {
 D = 4;
 G = 2 * D - A;
 Console.WriteLine("G: {0}", G);
 }
 }
}