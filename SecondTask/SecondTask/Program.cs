using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SecondTask
{
    class Program
    {
        private const int numberOfDigits = 10000000;

        static void Main(string[] args)
        {
            Random random = new();
            List<int> inputArray = new();
            List<int> resultArray = new(); 
            for (int i = 0; i < numberOfDigits; i++)
            {
                inputArray.Add(random.Next(1, 13));
            }

            for (int i = 1; i <= 20; i++)
            {
                Stopwatch timePerOne = new();

                timePerOne.Start();
                resultArray = FactorialAsync(inputArray, i).Result;
                timePerOne.Stop();
                Console.Write("\n");
                var total = timePerOne.ElapsedMilliseconds;
                Console.Write("\nTime(" + (i) + " thread(s)):\n" + total + "\n");
            }

            Console.Write("\n Max value: " + resultArray.Max());
            Console.Write("\n Avg value: " + resultArray.Average());
            Console.Write("\n Sum value: Too big value!\n");
        }

        public static async Task<List<int>> FactorialAsync(List<int> arr, int threadsCount)
        {
            List<Task<List<int>>> tasks = new();
            List<int> resultArray = new();

            for (int i = 0; i < threadsCount; i++)
            {
                int left = arr.Count / threadsCount * i;
                int right = arr.Count / threadsCount * (i + 1);
                tasks.Add(Task.Run(() => FactorialIter(arr, left, right)));
            }
            
            var resultArrays = await Task.WhenAll(tasks);

            for(int i = 0; i < resultArrays.Length; i++)
            {
                resultArray.AddRange(resultArrays[i]);
            }

            return resultArray;
        }


        public static List<int> FactorialIter(List<int> inputArray, int left, int right)
        {
            List<int> resultArray = new();
            for (int i = left; i < right; i++)
            {
                resultArray.Add(Fact(inputArray[i]));
            }
            return resultArray;
        }

        public static int Fact(int num)
        {
            if(num>=2)
            {
                return num*Fact(num-1);
            }
            return 1;
        }
    }
}
