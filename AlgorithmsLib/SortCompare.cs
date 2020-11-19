using System;
using System.Diagnostics;

namespace AlgorithmsLib
{
    delegate void SortDelegate(int[] arr);
    public class SortCompare
    {
        private int[] arr;

        public SortCompare(int size)
        {
            arr = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
                arr[i] = rnd.Next(0, 100);
            Console.WriteLine("Массив до сортировки:");
            Print(arr);
            Console.WriteLine();
        }

        public void Compare()
        {
            int[] array = new int[arr.Length];
            SortDelegate[] sortDelegates = { Sort.Bubble, 
                                            Sort.CoctailShaker, 
                                            Sort.Insert, 
                                            Sort.InsertBinary,
                                            Sort.Selection};
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 5; i++)
            {
                arr.CopyTo(array, 0);
                sw.Restart();
                sortDelegates[i](array);
                sw.Stop();
                Console.WriteLine(sortDelegates[i].Method.Name);
                Console.WriteLine($"Затраченное время: {sw.ElapsedMilliseconds}");
                Print(array);
                Console.ReadLine();
            }

            sw.Restart();
            array = Sort.Counting(arr);
            sw.Stop();
            Console.WriteLine("Сортировка подсчетом");
            Console.WriteLine($"Затраченное время: {sw.ElapsedMilliseconds}");
            Print(array);
            Console.ReadLine();

            arr.CopyTo(array, 0);
            sw.Restart();
            Sort.QuickSort(array, 0, array.Length - 1);
            sw.Stop();
            Console.WriteLine("Быстрая сортировка");
            Console.WriteLine($"Затраченное время: {sw.ElapsedMilliseconds}");
            Print(array);
        }

        public void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
        }
    }
}
