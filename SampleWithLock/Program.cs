using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleWithLock
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x = 0;
            //object locker = new object();  // объект-заглушка

            //// запускаем пять потоков
            //for (int i = 1; i < 6; i++)
            //{
            //    Thread myThread = new Thread(Print);
            //    myThread.Name = $"Thread {i}";
            //    myThread.Start();
            //}  

            //void Print()
            //{
            //    lock (locker)
            //    {
            //        x = 1;
            //        for (int i = 1; i < 6; i++)
            //        {
            //            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            //            x++;
            //            Thread.Sleep(100);
            //        }
            //    }
            //}

            //Console.ReadLine();



            int x = 0;
            Mutex locker = new Mutex();  // объект-заглушка

            // запускаем пять потоков
            for (int i = 1; i < 6; i++)
            {
                Thread myThread = new Thread(Print);
                myThread.Name = $"Thread {i}";
                myThread.Start();
            }

            void Print()
            {
                locker.WaitOne();

                x = 1;
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }

                locker.ReleaseMutex();
            }

            Console.ReadLine();
        }
    }
}
