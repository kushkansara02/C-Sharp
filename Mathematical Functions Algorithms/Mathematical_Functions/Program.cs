using System;
using System.Collections.Generic;

namespace Mathematical_Functions
{
    class MathematicalFunctions
    {
        static void Main(string[] args)
        {

            MathematicalFunctions P = new MathematicalFunctions();

            List<double> mainList = new List<double>();
            Console.Write("How long is your list? ");
            int listLength = Int32.Parse(Console.ReadLine());

            for (int i = 1; i <= listLength; i++)
            {
                Console.Write("Enter number: ");
                mainList.Add(Convert.ToDouble(Console.ReadLine()));
            }

            Console.WriteLine("Pick one - 1: Minimum, 2: Maximum, 3: Mean, 4: Median, 5: Mode, 6: Scramble. ");
            int function = Int32.Parse(Console.ReadLine());

            if (function == 1)
            {
                double output = P.Minimum(mainList);
                Console.WriteLine("The smallest number is: " + output);
            }

            else if (function == 2)
            {
                double output = P.Maximum(mainList);
                Console.WriteLine("The largest number is: " + output);
            }

            else if (function == 3)
            {
                double output = P.Mean(mainList);
                Console.WriteLine("The average is: " + output);
            }

            else if (function == 4)
            {
                double output = P.Median(mainList);
                Console.WriteLine("The median is: " + output);
            }

            else if (function == 5)
            {
                List<double> output = new List<double>();
                output = P.EfficientMode(mainList);
                Console.WriteLine("The mode(s) are listed below.");
                output.ForEach(Console.WriteLine);
            }

            else if (function == 6)
            {
                List<double> output = new List<double>();
                output = P.Scramble(mainList);
                Console.WriteLine("Here is your new list below.");
                output.ForEach(Console.WriteLine);
            }
        }

        public double Minimum(List<double> numbers)
        {
            double min = numbers[0];
            int HighestIndex = numbers.Count - 1;

            for (int i = 1; i <= HighestIndex; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }

            }
            return min;
        }

        public double Maximum(List<double> numbers)
        {
            double max = numbers[0];
            int HighestIndex = numbers.Count - 1;

            for (int i = 1; i <= HighestIndex; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;
        }

        public double Mean(List<double> numbers)
        {
            double sum = 0;
            int HighestIndex = numbers.Count - 1;

            for (int i = 0; i <= HighestIndex; i++)
            {
                sum += numbers[i];
            }
            double average = sum/(HighestIndex + 1);
            return average;
        }

        public double Median(List<double> numbers)
        {
            numbers.Sort();
            int length = numbers.Count;
            double median;

            if (length%2 != 0)
            {
                median = numbers[length / 2];
            }
           
           else
            {
                median = (numbers[length / 2] + numbers[length / 2 - 1]) / 2;
            }
            return median;
        }

        public List<double> Mode(List<double> numbers)
        {
            List<double> modeList = new List<double>();
            int appearances = 0, maxAppearances = 0;
            int HighestIndex = numbers.Count - 1;
            bool exist;


            for (int i = 0; i <= HighestIndex; i++)
            {
                exist = false;
                appearances = 0;

                for (int n = 0; n <= HighestIndex; n++)
                {
                    if (numbers[n] == numbers[i])
                    {
                        appearances += 1;
                    }
                }

                if (appearances == maxAppearances)
                {
                    for (int x = 0; x <= modeList.Count - 1; x++)
                    {
                        if (modeList.Count > 0)
                        {
                            if (numbers[i] == modeList[x])
                            {
                                exist = true;
                            }
                        }
                        else
                        {
                            exist = false;
                        }
                    }

                    if (exist == false)
                    {
                        modeList.Add(numbers[i]);
                    }
                }

                else if (appearances > maxAppearances)
                {
                    maxAppearances = appearances;
                    modeList.Clear();
                    modeList.Add(numbers[i]);
                }
            }
            return modeList;
        }

        public List<double> Scramble(List<double> numbers)
        {
            List<double> scrambledList = new List<double>();
            Random rnd = new Random();
            int n;
            int initCount = numbers.Count;

            for (int i = 0; i <= initCount - 1; i++)
            {
                n = rnd.Next(0, numbers.Count);
                scrambledList.Add(numbers[n]);
                numbers.Remove(numbers[n]);
            }
            return scrambledList;
        }

        public List<double> EfficientMode(List<double> listOfNumbers)
        {
            if (listOfNumbers.Count > 0)
            {

                List<double> modeList = new List<double>();
                List<List<double>> frequencyList = new List<List<double>>();
                List<double> itemFrequency = new List<double>();
                int appearances = 0;
                double maxAppearances = 0;
                int HighestIndex = listOfNumbers.Count - 1;
                bool Examined;

                foreach (double item1 in listOfNumbers)
                {
                    itemFrequency.Clear();
                    Examined = false;

                    foreach (double item2 in listOfNumbers)
                    {
                        if (item1 == item2)
                        {
                            appearances += 1;
                        }
                    }

                    if (frequencyList.Count > 0)
                    {
                        foreach (List<double> column in frequencyList)
                        {
                            if (column[0] == item1)
                            {
                                Examined = true;
                            }
                        }
                    }

                    if (!Examined)
                    {
                        itemFrequency.Add(item1);
                        itemFrequency.Add(appearances);
                        frequencyList.Add(itemFrequency);
                    }

                    appearances = 0;
                }

                foreach (List<double> column in frequencyList)
                {
                    if (column[1] > maxAppearances)
                    {
                        maxAppearances = column[1];
                        modeList.Clear();
                        modeList.Add(column[0]);
                    }
                    if (column[1] == maxAppearances)
                    {
                        bool existsInList = false;

                        foreach (double mode in modeList)
                        {
                            if (mode == column[0])
                            {
                                existsInList = true;
                            }
                        }
                        if (!existsInList)
                        {
                            modeList.Add(column[0]);
                        }
                    }
                }
                return modeList;
            }
            else
            {
                return listOfNumbers;
            }
        }
    }
}