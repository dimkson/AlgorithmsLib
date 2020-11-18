using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLib
{
    static public class Sort
    {
        /// <summary>
        /// Сортировка пузырьком. Сложность алгоритма: O(n^2).
        /// Алгоритм оптимизирован. Добавлен флаг для выхода, в случае если массив отсортирован. Внутренний цикл работает до места последнего обмена значений.
        /// </summary>
        public static void Bubble(int[] array)
        {
            int right = array.Length - 1,
                pos = 0;
            bool flag = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < right; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        flag = true;
                        pos = j;
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
                if (!flag) break;
                right = pos;
                flag = false;
            }
        }

        /// <summary>
        /// Шейкерная сортировка. Сложность алгоритма: O(n^2).
        /// Алгоритм оптимизирован. Добавлены флаги для выхода, в случае если массив отсортирован. Внутренние циклы работают до места последнего обмена значений.
        /// </summary>
        public static void CoctailShaker(int[] array)
        {
            int left = 0,
                right = array.Length - 1,
                pos = 0;
            bool flag = false;
            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        flag = true;
                        pos = i;
                        Swap(ref array[i], ref array[i + 1]);
                    }
                }
                if (!flag) break;
                right = pos;
                flag = false;
                for (int i = right; i > left; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        flag = true;
                        pos = i;
                        Swap(ref array[i], ref array[i - 1]);
                    }
                }
                if (!flag) break;
                left = pos;
                flag = false;
            }
        }

        /// <summary>
        /// Сортировка выбором. Сложность алгоритма: O(n^2).
        /// </summary>
        public static void Selection(int[] array)
        {
            int min, pos;
            for (int i = 0; i < array.Length - 1; i++)
            {
                min = array[i];
                pos = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        pos = j;
                    }
                }
                if (i != pos) 
                    Swap(ref array[i], ref array[pos]);
            }
        }

        public static void Swap(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
    }
}
