using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Unit0Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            //string word = "adfl;racecaras;dlfjkaracecarllldlll";
            //List<string> palindromeList = LargestPalindromeSubstring(word);

            //palindromeList.ForEach(Console.WriteLine);

            double[] a = { 1, 2, 3, 4, 5 };
            RotateItemsOfArray(a, 2);

            foreach (double digit in a)
            {
                Console.WriteLine(digit);
            }
        }

        #region page 24 questions
        private static bool PrimeCheck(int num)
        {
            int divisor = (int)Math.Sqrt(num);

            for (int i = divisor; i > 1; i--)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static double Discriminant(double a, double b, double c)
        {
            return Math.Pow(b, 2) - 4 * a * c;
        }

        private static double LinearEquation(double a, double b, double c)
        {
            return (c - b) / a;
        }

        private static double DistanceTwoPoints(List<double> point1, List<double> point2)
        {
            return Math.Sqrt(Math.Pow(point1[0] - point2[0], 2) + Math.Pow(point1[1] - point2[1], 2));
        }

        private static bool LeapYearCheck(int year)
        {
            bool leapYear = false;

            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        leapYear = true;
                    }
                }

                else
                {
                    leapYear = true;
                }
            }
            return leapYear;
        }

        private static string DayOfTheWeek(int date, int month, int year)
        {
            int janDoomsdayDate = 3;
            int febDoomsdayDate = 28;

            if (LeapYearCheck(year))
            {
                janDoomsdayDate += 1;
                febDoomsdayDate += 1;
            }

            int[,] doomsdayDates = { { 1, janDoomsdayDate }, { 2, febDoomsdayDate }, { 3, 7 }, { 4, 4 }, { 5, 9 }, { 6, 6 }, { 7, 11 }, { 8, 8 }, { 9, 5 }, { 10, 10 }, { 11, 7 }, { 12, 12 } };
            int[] anchorDays = { 2, 0, 5, 3 };
            string[] daysOfWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            int anchorDay = anchorDays[year / 100 % 4];
            int doomsdayDate = doomsdayDates[month - 1, 1];

            int yearLastTwoDigits = year % 100;
            int remainderFromYear = yearLastTwoDigits % 12;

            int doomsdayDay = (anchorDay + (yearLastTwoDigits / 12) + remainderFromYear + (remainderFromYear / 4)) % 7;
            int day;
            if (doomsdayDate > date)
            {
                while (doomsdayDate - 7 > date)
                {
                    doomsdayDate -= 7;
                }
            }

            else if (date > doomsdayDate)
            {
                while (date > doomsdayDate + 7)
                {
                    doomsdayDate += 7;
                }
            }

            day = doomsdayDay + date - doomsdayDate;

            if (day < 0)
            {
                day += 7;
            }

            else if (day > 6)
            {
                day -= 7;
            }
            return daysOfWeek[day];
        }
        #endregion

        #region GCD methods
        private static int EuclideanGCD(int m, int n)
        {
            do
            {
                int remainder = m % n;
                m = n;
                n = remainder;
            } while (n != 0);

            return m;
        }

        private static int BruteForceGCD(int m, int n)
        {
            int gcd = 1;

            for (int i = 2; i <= Math.Min(m, n); i++)
            {
                if (m % i == 0 && n % i == 0)
                {
                    gcd = i;
                }
            }
            return gcd;
        }
        #endregion

        #region page 42 questions
        private static void ReverseOrderOfList(List<double> originalList)
        {
            for (int i = 0; i <= originalList.Count / 2; i++)
            {
                double copy = originalList[i];
                originalList[i] = originalList[originalList.Count - i - 1];
                originalList[originalList.Count - i - 1] = copy;
            }
        }

        private static double ListSum(List<double> originalList, int n)
        {
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += originalList[i];
            }

            return sum;
        }

        private static double ListSum(List<double> originalList, int n, int i)
        {
            double sum = 0;

            for (int x = i; x < i + n; x++)
            {
                sum += originalList[x];
            }

            return sum;
        }

        private static List<double> OddNumberedItemsList(List<double> originalList)
        {
            List<double> newList = new List<double>();

            for (int i = 1; i < originalList.Count; i += 2)
            {
                newList.Add(originalList[i]);
            }

            return newList;
        }

        private static List<object> CombineLists(List<object> list1, List<object> list2)
        {
            List<object> combinedList = new List<object>();
            List<object> greaterList = new List<object>();
            int sizeDifference = list1.Count - list2.Count;
            int minimumSize = Math.Min(list1.Count, list2.Count);

            if (sizeDifference > 0)
            {
                greaterList = list1;
            }

            else if (sizeDifference < 0)
            {
                greaterList = list2;
            }

            for (int i = 0; i < minimumSize; i++)
            {
                combinedList.Add(list1[i]);
                combinedList.Add(list2[i]);
            }

            if (sizeDifference != 0)
            {
                for (int i = minimumSize; i < Math.Abs(sizeDifference) + minimumSize; i++)
                {
                    combinedList.Add(greaterList[i]);
                }
            }
            return combinedList;
        }

        private static List<double> MergeSortedLists(List<double> list1, List<double> list2)
        {
            List<double> mergedList = new List<double>();
            mergedList.AddRange(list1);
            mergedList.AddRange(list2);
            mergedList.Sort();

            return mergedList;
        }

        private static double[] RotateItemsOfList(double[] inputArray, int k)
        {
            int numOfElements = inputArray.Length;
            double[] rotatedList = new double[numOfElements];

            for (int i = 0; i < numOfElements; i++)
            {
                int newIndex = i - (k % numOfElements);

                if (newIndex < 0)
                {
                    newIndex += numOfElements;
                }
                rotatedList[i] = inputArray[newIndex];
            }
            return rotatedList;
        }

        private static void RotateItemsOfArray(double[] inputArray, int k)
        {
            if (k >= inputArray.Length)
            {
                k %= inputArray.Length;
            }

            for (int i = 0; i < k; i++)
            {
                double last = inputArray[inputArray.Length - 1];

                for (int j = inputArray.Length - 2; j >= 0; j--)
                {
                    inputArray[j + 1] = inputArray[j];
                }

                inputArray[0] = last;
            }
        }

        private static List<int> DigitsOfInt(int num)
        {
            int numOfDigits = (int)Math.Floor(Math.Log10(num) + 1);
            List<int> digitArray = new List<int>();

            for (int i = 0; i < numOfDigits; i++)
            {
                digitArray.Add(Convert.ToInt32(num.ToString()[i].ToString()));
            }

            return digitArray;
        }

        private static string EnglishToPigLatin(string englishText)
        {
            string pigLatin = "";
            string[] englishWords = englishText.Split(" ");

            for (int i = 0; i < englishWords.Length; i++)
            {
                englishWords[i] += englishWords[i][0] + "ay";
                englishWords[i] = englishWords[i].Remove(0, 1);
            }

            pigLatin = string.Join(" ", englishWords);

            return pigLatin;
        }

        private static List<string> LargestPalindromeSubstring(string word)
        {
            List<string> palindromeList = new List<string>();

            for (int i = word.Length; i > 0; i--)
            {
                for (int j = 0; j < word.Length + 1 - i; j++)
                {
                    string substring = word.Substring(j, i);
                    bool isPalindrome = true;

                    for (int k = 0, l = substring.Length - 1; k < l; k++, l--)
                    {
                        if (substring[k] != substring[l])
                        {
                            isPalindrome = false;
                        }
                    }
                    if (isPalindrome)
                    {
                        palindromeList.Add(substring);
                    }
                }

                if (palindromeList.Count > 0)
                {
                    break;
                }
            }
            return palindromeList;
        }

        private static bool IsPalindrome(string word)
        {
            if (word.Length > 1)
            {
                if (word[word.Length - 1] != word[0])
                {
                    return false;
                }
                return IsPalindrome(word.Substring(1, word.Length - 2));
            }
            return true;
        }

        private static bool IsPalindrome2(string word)
        {
            if (word.Length <= 1)
            {
                return true;
            }
            if (word[word.Length - 1] != word[0])
            {
                return false;
            }
            return IsPalindrome(word.Substring(1, word.Length - 2));
        }
        #endregion

        #region BinaryDigitExercises

        #region TwosComplement
        private static int SignedIntToDecimalForm(int n, string binaryNum)
        {
            int sizeDifference = n - binaryNum.Length;
            int decimalForm = 0;

            if (sizeDifference > 0)
            {
                return UnsignedIntToDecimalForm(n, binaryNum);
            }

            if (sizeDifference < 0)
            {
                binaryNum = binaryNum.Remove(0, Math.Abs(sizeDifference));
            }
            n = binaryNum.Length;

            decimalForm += Int32.Parse(binaryNum[0].ToString()) * (int)-Math.Pow(2, n - 1);

            for (int i = 1; i < n; i++)
            {
                decimalForm += Int32.Parse(binaryNum[i].ToString()) * (int)Math.Pow(2, n - i - 1);
            }

            return decimalForm;
        }

        private static int UnsignedIntToDecimalForm(int n, string binaryNum)
        {
            int sizeDifference = n - binaryNum.Length;
            int decimalForm = 0;

            if (sizeDifference < 0)
            {
                binaryNum = binaryNum.Remove(0, Math.Abs(sizeDifference));
            }

            n = binaryNum.Length;

            for (int i = 0; i < n; i++)
            {
                decimalForm += Int32.Parse(binaryNum[i].ToString()) * (int)Math.Pow(2, n - i - 1);
            }

            return decimalForm;
        }

        private static int DecimalFormToUnsignedInt(int decimalForm)
        {
            int highestPowerOfTwo;
            int binaryForm = 0;

            do
            {
                highestPowerOfTwo = (int)Math.Floor(Math.Log(decimalForm, 2));
                decimalForm -= (int)Math.Pow(2, highestPowerOfTwo);
                binaryForm += (int)Math.Pow(10, highestPowerOfTwo);

            } while (highestPowerOfTwo != 0);

            return binaryForm;
        }

        private static int DecimalFormToSignedInt(int n, int decimalForm)
        {
            int highestPowerOfTwo;

            if (decimalForm > 0)
            {
                return DecimalFormToUnsignedInt(decimalForm);
            }

            int binaryForm = (int)Math.Pow(10, n - 1);
            decimalForm += (int)Math.Pow(2, n - 1);

            do
            {
                highestPowerOfTwo = (int)Math.Floor(Math.Log(decimalForm, 2));
                decimalForm -= (int)Math.Pow(2, highestPowerOfTwo);
                binaryForm += (int)Math.Pow(10, highestPowerOfTwo);

            } while (highestPowerOfTwo != 0);

            return binaryForm;
        }

        private static string DecimalFormToUnsignedBin(uint decimalForm, int n)
        {
            if (n < 0 || n > 32 || decimalForm >= Math.Pow(2, n))
            {
                return "Invalid Argument";
            }

            string binary = "";
            for (int i = 0; i < n; i++)
            {
                binary = (decimalForm % 2).ToString() + binary;
                decimalForm /= 2;
            }

            return binary;
        }
        #endregion

        #region IEEE754
        private static double DoubleFloatingPointToDecimalForm(string floatingPointValue)
        {
            string fraction = floatingPointValue.Substring(12, 52);
            double fractionValue = 1;

            for (int i = 0; i < fraction.Length; i++)
            {
                fractionValue += double.Parse(fraction[i].ToString()) * Math.Pow(2, -(i + 1));
            }

            return Math.Pow(-1, Convert.ToInt32(floatingPointValue[0].ToString())) * fractionValue * Math.Pow(2, UnsignedIntToDecimalForm(11, floatingPointValue.Substring(1, 11)) - 1023);
        }

        private static string DecimalFormToDoubleFloatingPoint(int decimalForm)
        {
            string floatingPoint = "";



            return floatingPoint;
        }
        #endregion

        #endregion

        #region Nested Loops
        private static List<int> RandomNumberGenerationV1(int n, int lowest, int highest)
        {
            Random generator = new Random();
            List<int> randomNumbers = new List<int>();
            bool intInList;
            int nextNumber = generator.Next(lowest, highest);

            if (n > highest - lowest + 1)
            {
                return randomNumbers;
            }

            for (int i = 0; i < n; i++)
            {
                do
                {
                    nextNumber = generator.Next(lowest, highest + 1);
                    intInList = false;

                    foreach (int value in randomNumbers)
                    {
                        if (value == nextNumber)
                        {
                            intInList = true;
                        }
                    }

                } while (intInList);

                randomNumbers.Add(nextNumber);
            }

            return randomNumbers;
        }

        private static List<int> RandomNumberGenerationV2(int n, int lowest, int highest)
        {
            Random generator = new Random();
            List<int> randomNumbers = new List<int>();
            bool intInList;
            int nextNumber = generator.Next(lowest, highest);

            if (n > highest - lowest + 1)
            {
                return randomNumbers;
            }

            while (randomNumbers.Count < n)
            {
                nextNumber = generator.Next(lowest, highest + 1);
                intInList = false;

                foreach (int value in randomNumbers)
                {
                    if (value == nextNumber)
                    {
                        intInList = true;
                    }
                }

                if (!intInList)
                {
                    randomNumbers.Add(nextNumber);
                }
            }

            return randomNumbers;
        }

        private static List<int> RandomNumberGenerationV3(int n, int lowest, int highest)
        {
            bool[] ocurrencesArray = new bool[highest];
            List<int> randomNumbers = new List<int>();
            Random generator = new Random();
            int nextNumber = generator.Next(lowest, highest + 1);

            if (n > highest - lowest + 1)
            {
                return randomNumbers;
            }

            while (randomNumbers.Count < n)
            {

                nextNumber = generator.Next(lowest, highest + 1);

                if (!ocurrencesArray[nextNumber - lowest])
                {
                    ocurrencesArray[nextNumber - lowest] = true;
                    randomNumbers.Add(nextNumber);
                }
            }

            return randomNumbers;
        }
        #endregion Nested Loops

        #region Converting Problem
        private static string ConvertingAllTypes(int originalValue, int[] divisorsArray, string[] possibleOutputsArray, bool onlyString)
        {
            string convertedValue = "";
            int remainder = originalValue;
            int nextValue;
            int outputArrayLength = possibleOutputsArray.Length;

            for (int i = 0; i < divisorsArray.Length; i++)
            {
                nextValue = remainder / divisorsArray[i];
                remainder %= divisorsArray[i];

                if (onlyString)
                {
                    string addedString = "";

                    for (int j = 0; j < nextValue; j++)
                    {
                        addedString += possibleOutputsArray[i];
                    }

                    convertedValue += addedString;
                }

                else
                {
                    convertedValue += nextValue + possibleOutputsArray[i % outputArrayLength];
                }
            }

            return convertedValue;
        }

        private static int[] CreateArrayOfBaseN(int n, int mainValue)
        {
            int highestPower = (int)Math.Floor(Math.Log(mainValue, n));
            int[] powerArray = new int[highestPower + 1];

            for (int i = highestPower; i >= 0; i--)
            {
                powerArray[i] = (int)Math.Pow(n, i);
            }

            return powerArray;
        }

        private static int[] GroupsOf(int[] placeValueSizes, int value)
        {
            int groupSizeLength = placeValueSizes.Length;

            int[] groupArray = new int[groupSizeLength];
            int remainder = Math.Abs(value);

            for (int i = 0; i < groupSizeLength; i++)
            {
                groupArray[i] = remainder / placeValueSizes[i];
                remainder %= placeValueSizes[i];
            }

            return groupArray;
        }

        private static string ChangeMaker(int[] numGroups)
        {
            string expandedVersion = "";
            string[] expandedStrings = {" x $100 + ", " x $50 + ", " x $20 + ", " x $10 + ", " x $5 + ", " x $2 + ", " x $1 + ", " x $0.25 + ", " x $0.10 + ", " x $0.05 + ", " x $0.01"};

            for (int i = 0; i < numGroups.Length; i++)
            {
                expandedVersion += numGroups[i].ToString() + expandedStrings[i];
            }

            return expandedVersion;
        }
        #endregion Converting Problem

        #region Searching & Sorting Algorithms
        private static int LinearSearch(int[] inputArray, int key)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == key)
                {
                    return i;
                }
            }
            return -1;
        }

        private static int BinarySearch(List<int> inputList, int key)
        {
            int lowerBound = 0;
            int higherBound = inputList.Count - 1;

            while (lowerBound < higherBound)
            {
                int guess = (lowerBound + higherBound) / 2;

                if (inputList[guess] > key)
                {
                    higherBound = guess - 1;
                }

                else if (inputList[guess] < key)
                {
                    lowerBound = guess + 1;
                }

                else
                {
                    return guess;
                }
            }

            return -1;
        }

        private static void BubbleSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = 0; j < inputArray.Length - i - 1; j++)
                {
                    if (inputArray[i] > inputArray[i + 1])
                    {
                        int copy = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = copy;
                    }
                }
            }
        }

        private static void SelectionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < inputArray.Length - 1; j++)
                {
                    if (inputArray[j] < inputArray[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int copy = inputArray[i];
                inputArray[i] = inputArray[minIndex];
                inputArray[minIndex] = copy;
            }
        }

        private static void InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                int numIndex = i - 1;
                int key = inputArray[i];

                while (numIndex >= 0 && key < inputArray[numIndex])
                {
                    inputArray[numIndex + 1] = inputArray[numIndex];
                    numIndex--;
                }
                inputArray[numIndex + 1] = key;
            }
        }
        #endregion Searching Algorithms

    }
}