using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class ArraySort
    {
        public ArraySort() //конструктор
        {

        }
        public int[] a;
        private static void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        public void SelectSort(int[] a, ref int sr, ref int obm)
        {
            int max;
            int length = a.Length;
            for (int i = 0; i < length - 1; i++)
            {
                max = i;
                for (int j = i + 1; j < length; j++)
                {
                    sr++;
                    if (a[j] > a[max])
                    {
                        max = j;

                    }
                }

                sr++;
                if (max != i)
                {
                    swap(ref a[i], ref a[max]);
                    obm++;
                }
            }
        }
        public void InsertSort(int[] a, ref int sr, ref int obm)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int cur = a[i];
                int j = i;
                while (j > 0 && cur > a[j - 1])
                {
                    sr++;
                    a[j] = a[j - 1];
                    j--;
                }
                a[j] = cur;
            }
            sr++;
        }
        public void BubbleSort(int[] a, ref int sr, ref int obm)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    sr++;
                    if (a[j] < a[j + 1])
                    {
                        swap(ref a[j], ref a[j + 1]);
                        obm++;
                    }
                }
            }
        }
        public void insertionSortRecursive(int[] input, ref int sr, ref int obm)
        {
            insertionSortRecursive(input, input.Length, ref sr, ref obm);
        }
        private void insertionSortRecursive(int[] input, int i, ref int sr, ref int obm)
        {
            if (i <= 1)
            {
                return;
            }
            insertionSortRecursive(input, i - 1, ref sr, ref obm);
            int key = input[i - 1];
            int j = i - 2;
            while (j >= 0 && input[j] > key)
            {
                input[j + 1] = input[j];
                j = j - 1;
                sr++;
            }
            input[j + 1] = key;
        }

        private void QuickSort(int[] array, int minIndex, int maxIndex, ref int sr, ref int obm)
        {
            if (minIndex >= maxIndex)
            {
                return;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex, ref  sr, ref  obm);
            QuickSort(array, minIndex, pivotIndex - 1, ref sr, ref obm);
            QuickSort(array, pivotIndex + 1, maxIndex, ref sr, ref obm);

            return;
        }

        public void QuickSort(int[] array, ref int sr, ref int obm)
        {
            QuickSort(array, 0, array.Length - 1, ref  sr, ref  obm);
        }

        private int Partition(int[] array, int minIndex, int maxIndex, ref int sr, ref int obm)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                sr++;
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    swap(ref array[pivot], ref array[i]);
                    obm++;
                }
            }

            pivot++;
            swap(ref array[pivot], ref array[maxIndex]);
            obm++;
            return pivot;
        }
    }
}
