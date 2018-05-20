using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GraduateWork;

namespace GraduateWorkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the directory as an example: C:\\ ");
            string way = Console.ReadLine();

            var threadParametr = new ParameterizedThreadStart(ScanDirectory.PathView);
            Thread Thread1 = new Thread(threadParametr);
            Thread1.Start(way);

            while (true)
            {
                ConsoleKey action = Console.ReadKey().Key;
                if (action == ConsoleKey.Spacebar)
                {
                    int delay = 0;

                    if (ScanDirectory.wait.WaitOne(delay))
                    {
                        ScanDirectory.wait.Reset();
                    }
                    else
                    {
                        ScanDirectory.wait.Set();
                    }
                }
            }
        }
    }
}
