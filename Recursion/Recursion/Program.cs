using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[] a = { 1, 5, 6, 2, 6, 2 };
            //PancakeSort(a);

            //foreach (double num in a)
            //{
            //    Console.WriteLine(num);
            //}

            //Console.WriteLine(reverse("racecar"));

        }

        #region Exercises
        private static int SumOfIntegers(int m, int n)
        {
            if (n == m)
            {
                return m;
            }
            return n + SumOfIntegers(m, n - 1);
        }

        private static int SumOfDigits(int num)
        {
            if (num == 0)
            {
                return 0;
            }

            return num % 10 + SumOfDigits(num / 10);
        }

        private static int TribonacciSequence(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            else if (n == 3)
            {
                return 2;
            }

            return TribonacciSequence(n - 1) + TribonacciSequence(n - 2) + TribonacciSequence(n - 3);
        }

        private static int MinimumValue(List<int> series)
        {
            if (series.Count == 1)
            {
                return series[0];
            }

            series.Remove(Math.Max(series[0], series[series.Count - 1]));

            return MinimumValue(series);
        }

        private static bool PalindromeCheck(string word)
        {
            if (word[0] != word[word.Length - 1])
            {
                return false;
            }
            if (word.Length <= 1)
            {
                return true;
            }
            return PalindromeCheck(word.Substring(1, word.Length - 2));
        }

        private static int ConsonantCount(string word, int occurences)
        {
            if (word.Length == 0)
            {
                return occurences;
            }
            string vowels = "aeiou";

            if (vowels.IndexOf(word[0].ToString()) < 0)
            {
                occurences += 1;
            }
            return ConsonantCount(word.Substring(1, word.Length - 1), occurences);
        }

        private static void BinaryStrings(string startString, int numDigits, string addString, List<string> listOfStrings)
        {
            if (startString.Length == numDigits)
            {
                listOfStrings.Add(startString);
                startString = "";
            }

            if (listOfStrings.Count >= 2)
            {
                return;
            }

            startString += addString;

            if (startString.Length == 0 || startString[startString.Length - 1].ToString() == "0")
            {
                BinaryStrings(startString, numDigits, "1", listOfStrings);
                BinaryStrings(startString, numDigits, "0", listOfStrings);
            }

            else
            {
                BinaryStrings(startString, numDigits, "0", listOfStrings);
            }
        }
        #endregion Exercises

        #region QuickSort
        private static void QuickSort(int[] a, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int pivotIndex = Partition(a, leftIndex, rightIndex);
                QuickSort(a, leftIndex, pivotIndex - 1);
                QuickSort(a, pivotIndex + 1, rightIndex);
            }
        }

        private static int Partition(int[] a, int leftIndex, int rightIndex)
        {
            int pivot = a[rightIndex];
            int counter = leftIndex;

            for (int i = leftIndex; i < rightIndex; i++)
            {
                if (a[i] <= pivot)
                {
                    int copy = a[i];
                    a[i] = a[counter];
                    a[counter] = copy;
                    counter++;
                }
            }
            a[rightIndex] = a[counter];
            a[counter] = pivot;

            return counter;
        }
        #endregion QuickSort

        public static string reverse(string s)
        {
            if (s.Length > 1)
            {
                return s[s.Length - 1] + reverse(s.Substring(0, s.Length - 1));
            }

            else
            {
                return s;
            }
        }

        public static int IndexOfMax(double[] a, int startIndex, int endIndex)
        {
            int maxIndex = startIndex;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (a[i] > a[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public static void Flip(double[] a, int index)
        {
            for (int i = 0; i <= index/2; i++)
            {
                double firstNum = a[i];
                a[i] = a[index - i];
                a[index - i] = firstNum;
            }
        }

        public static void PancakeSort(double[] a)
        {
            int n = a.Length;

            for (int i = n - 1; i >= 0; i--)
            {
                int maxIndex = IndexOfMax(a, 0, i);
                Flip(a, maxIndex);
                Flip(a, i);
            }
        }
    }
}