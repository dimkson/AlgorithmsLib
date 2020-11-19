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

        /// <summary>
        /// Сортировка вставками. Сложность алгоритма: O(n^2).
        /// </summary>
        public static void Insert(int[] array)
        {
            int j, key;
            for (int i = 1; i < array.Length; i++)
            {
                j = i;
                key = array[i];
                while (j > 0 && array[j - 1] > key)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = key;
            }
        }

        /// <summary>
        /// Сортировка вставками с бинарным поиском. Сложность алгоритма: O(n^2).
        /// Алгоритм оптимизирован. Поиск места вставки выполняется с помощью бинарного поиска.
        /// </summary>
        public static void InsertBinary(int[] array)
        {
            int j, key;
            int left, right, middle;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    key = array[i];
                    left = 0;
                    right = i - 1;

                    while (left < right)
                    {
                        middle = (right + left) / 2;
                        if (array[middle] > key)
                            right = middle;
                        else
                            left = middle + 1;
                    }

                    j = i;
                    while (j > left)
                    {
                        array[j] = array[j - 1];
                        j--;
                    }
                    array[left] = key;
                }
            }
        }

        /// <summary>
        /// Быстрая сортировка (Сортировка Хоара). Сложность алгоритма: O(n*log n).
        /// </summary>
        public static void QuickSort(int[] arr, int first, int last)
        {
            int i = first,
                j = last,
                x = arr[(first + last) / 2];
            do
            {
                while (arr[i] < x)
                    i++;
                while (arr[j] > x)
                    j--;
                if (i <= j)
                {
                    if (arr[i] > arr[j])
                        Swap(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
                QuickSort(arr, i, last);
            if (first < j)
                QuickSort(arr, first, j);
        }

        /// <summary>
        /// Сортировка подсчетом. Сложность алгоритма: O(n+k), где k максимальный элемент в массиве.
        /// </summary>
        public static int[] Counting(int[] arr)
        {
            int max = arr[0];
            foreach (int item in arr)
                if (item > max) max = item;
            
            int[] arrCount = new int[max + 1];
            for (int i = 0; i < arr.Length; i++)
                arrCount[arr[i]]++;

            int[] arrOut = new int[arr.Length];
            
            for (int i = 0, b = 0 ; i < arrCount.Length; i++)
            {
                for (int j = 0; j < arrCount[i]; j++, b++)
                {
                    arrOut[b] = i;
                }
            }
            return arrOut;
        }

        private static void Swap(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
    }
}
