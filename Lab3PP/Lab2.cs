﻿using System;
using System.Threading;

namespace Lab3PP 
{
    /**
 * Parallel and distributed computing.
 * Labwork 2. C#.
 *
 * Andrii Sliusarenko
 * IO-91
 * 30.09.2021
 *
 * F1: E = A + C * (MA * ME) + B
 * F2: MG = TRANS(MK) * (MH * MF)
 * F3: S = (O + P) * TRANS(MR * MT)
 */
    public class Lab2 
    {
        private static int N = 100;

        static void Main(string[] args) 
        {
            Console.WriteLine("Lab 2 start\n");
            
            var data = new Data(N);
            Thread T1 = new Thread(new F1(data).Run);
            Thread T2 = new Thread(new F2(data).Run);
            Thread T3 = new Thread(new F3(data).Run);

            T1.Priority = ThreadPriority.Lowest;
            T2.Priority = ThreadPriority.Highest;
            T3.Priority = ThreadPriority.Normal;
            
            T1.Start();
            T2.Start();
            T3.Start();

            T1.Join();
            //T2.Join();
            //T3.Join();
            
            Console.WriteLine("Lab 2 end \n");
        }
    }
}