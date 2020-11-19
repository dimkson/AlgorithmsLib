using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLib
{
    delegate void SortDelegate(int[] arr);
    class SortCompare
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
        }

        public void Compare()
        {
            int[] array = new int[arr.Length];
            SortDelegate[] sortDelegates = { Sort.Bubble, 
                                            Sort.CoctailShaker, 
                                            Sort.Insert, 
                                            Sort.InsertBinary,
                                            Sort.Selection};
            for (int i = 0; i < 5; i++)
            {
                array.CopyTo(arr, 0);
                sortDelegates[i](array);
                Console.WriteLine(sortDelegates[i].ToString());
                Print(array);
                Console.ReadLine();
            }
            
            array = Sort.Counting(arr);
            Console.WriteLine("Сортировка подсчетом");
            Print(array);

            array.CopyTo(arr, 0);
            Sort.QuickSort(array, 0, array.Length);
            Console.WriteLine("Быстрая сортировка");
            Print(array);
        }

        public void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
        }
    }
}
