using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Random rand = new();
            List<int> arr = new();
            List<int> arr2 = new(); 
            for (int i = 0; i < 10000000; i++)
            {
                arr.Add(rand.Next(1, 13));
            }

            for (int i = 1; i <= 20; i++)
            {
                Stopwatch timePerOne = new();

                timePerOne.Start();
                arr2 = asyncFactorial(arr, i).Result;
                timePerOne.Stop();
                Console.Write("\n");
                var total = timePerOne.ElapsedMilliseconds;
                Console.Write("\nTime(" + (i) + " thread(s)):\n" + total + "\n");
            }

            Console.Write("\n Max value: " + arr2.Max());
            Console.Write("\n Avg value: " + arr2.Average());
            Console.Write("\n Sum value: Too big value!");

            Console.Write("\n");
        }

        public static async Task<List<int>> asyncFactorial(List<int> arr, int threadsCount)
        {
            List<Task<List<int>>> Tasks = new();
            List<int> resultArr = new();

            for (int i = 0; i < threadsCount; i++)
            {
                int Iter1 = arr.Count / threadsCount * i;
                int Iter2 = arr.Count / threadsCount * (i + 1);
                Tasks.Add(Task.Run(() => FactorialIter(arr, Iter1, Iter2)));
            }
            
            var Arrays = await Task.WhenAll(Tasks);

            for(int i = 0; i < Arrays.Length; i++)
            {
                resultArr.AddRange(Arrays[i]);
            }

            return resultArr;
        }


        public static List<int> FactorialIter(List<int> arr, int Iter1, int Iter2)
        {
            List<int> arr2 = new();
            for (int i = Iter1; i < Iter2; i++)
            {
                 arr2.Add(Fact(arr[i]));
            }
            return arr2;
        }

        public static int Fact(int a)
        {
            if(a>=2)
            {
                return a*Fact(a-1);
            }
            return 1;
        }
    }
}
