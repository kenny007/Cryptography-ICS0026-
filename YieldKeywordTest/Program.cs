using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldKeywordTest
{
    class Program
    {
        static void Main(string[] args)
        {
           Execute();
           Console.ReadKey();
        }

        public static IEnumerable<long> GetList()
        {
            var list = new List<long>();
            for (long i = 0; i < 10000000; i++)
                list.Add(i);

            return list;
        }

        public static IEnumerable<long> GetListYield()
        {
            for (long i = 0; i < 10000000; i++)
                yield return i;
        }

        public static void Execute()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            var list1 = GetList();
            stopwatch.Stop();
            var elapsedTicks1 = stopwatch.ElapsedTicks;
            Console.WriteLine($"{elapsedTicks1}");

            stopwatch.Restart();
            var list2 = GetListYield();
            stopwatch.Stop();
            var elapsedTicks2 = stopwatch.ElapsedTicks;
            Console.WriteLine($"{elapsedTicks2}");

        }
    }
}