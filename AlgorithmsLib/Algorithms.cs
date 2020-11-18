using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLib
{
    public class Algorithms
    {
        /// <summary>
        /// Алгоритм Евклида. Алгоритм нахождения наибольшего общего делителя (НОД) пары целых чисел вычитанием.
        /// </summary>
        public static int NOD(int a, int b)
        {
            //Алгоритм Эвклида
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
        /// <summary>
        /// Алгоритм Евклида. Ускоренный алгоритм нахождения наибольшего общего делителя (НОД) пары целых чисел делением.
        /// </summary>
        public static int NODfast(int a, int b)
        {
            //Ускоренный алгоритм Эвклида
            int c;
            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }
            return a;
        }
        /// <summary>
        /// Алгоритм ускоренного возведения в степень.
        /// </summary>
        public static int Pow(int a, int b)
        {
            int n = 1, s = a, k = b;
            while (k != 0)
            {
                if (k % 2 == 0)
                {
                    s *= s;
                    k /= 2;
                }
                else
                {
                    n *= s;
                    k--;
                }
            }
            return n;
        }
        /// <summary>
        /// Обмен значениями двух целочисленных переменных.
        /// </summary>
        public static void Swap(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
    }
}
