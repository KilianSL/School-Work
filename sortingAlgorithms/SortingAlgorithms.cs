using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class BubbleSort<T>  //performs a bubble sort on an array of integers - best for small lists - O(n^2) worst case
    {
        public int[] Sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                bool flag = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    break;
                }
            }
            return arr;
        }
    }

    public class SelectionSort  //performs a selection sort on an array of integers - best for small lists - O(n^2)  worst case
    {
        public int[] Sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n-1; i++)
            {
                int min_index = i;
                for (int j = i+1; j < n; j++)
                {
                    if (arr[j] < arr[min_index])
                    {
                        min_index = j;
                    }
                }
                int temp = arr[i];
                arr[i] = arr[min_index];
                arr[min_index] = temp;
            }
            return arr;
        }
    }

    public class MergeSort //performs a merge sort on an array of integers - best when memory is plentiful - O(n log n) worst case
    {
        private int[] merge(int[] arr, int l, int m, int r) //merges 2 sub-arrays of arr
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] L = new int[n1];
            int[] R = new int[n2];
            //fills the Left and Rigt sub-arrays
            for (int a = 0; a < n1; a++)
            {
                L[a] = arr[l + a];
            }
            for (int b = 0; b < n2; b++)
            {
                R[b] = arr[m + 1 + b];
            }
            //merge arrays back into sorted arr[l...r]
            int i = 0;  //index of L[]
            int j = 0;  //index of R[]
            int k = l;  //index of merged array 
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            //copy the remaining elements of L[]
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }

            return arr;

        }
        private int[] mergeSort(int[] arr, int l, int r)  //l is the left index of the sub-array, r is the right index and m is the midpoint
        {
            if (l<r)
            {
                int m = l + (r - l) / 2;
                mergeSort(arr, l, m);
                mergeSort(arr, m+1, r);
                merge(arr, l, m, r);
            }
            return arr;
        }
        public int[] Sort(int[] arr)
        {   
            int n = arr.Length;
            mergeSort(arr, 0, n - 1);
            return arr;
        }
    }

    public class InsertionSort  //performs an insertion sort on an array of integers - best for nearly sorted lists
    {
        public int[] Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var temp = arr[i];
                int j = i - 1;
                while (j >= 0 && temp < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j -= 1;
                }
                arr[j + 1] = temp;
            }
            return arr;
        }
    }
}
