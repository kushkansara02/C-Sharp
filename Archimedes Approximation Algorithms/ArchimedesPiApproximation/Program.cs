using System;
using static System.Convert;
using System.Collections.Generic;

namespace ArchimedesPiApproximation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to do: 1. Find approximation of pi OR 2. Approximation of the square root function OR 3. Approximation of solution root OR 4. Rounding Numbers OR 5. Cube root");

                        int userChoice = int.Parse(Console.ReadLine());

            if (userChoice == 1)
            {
                Console.WriteLine("Enter the number of sides. ");
                Console.WriteLine(FindPi(int.Parse(Console.ReadLine())));
            }

            else if (userChoice == 2)
            {
                Console.WriteLine("What is your number?");
                double mainNumber = double.Parse(Console.ReadLine());

                Console.WriteLine("Your number is: " + SquareRoot(mainNumber).ToString());
            }

            else if (userChoice == 3)
            {
                Console.WriteLine("What is your initial guess? ");

                double initialGuess = double.Parse(Console.ReadLine());

                Console.WriteLine("The solution is: " + SolutionApproximation(initialGuess).ToString());
            }

            else if (userChoice == 4)
            {
                Console.WriteLine("What is the number you want to round?");
                double number = double.Parse(Console.ReadLine());

                Console.WriteLine("How many decimal places?");
                int decimalPlaces = int.Parse(Console.ReadLine());

                Console.WriteLine("The new number is: " + RoundOffV2(number, decimalPlaces));
            }

            else if (userChoice == 5)
            {
                Console.WriteLine("What is your number?");
                double c = double.Parse(Console.ReadLine());

                Console.WriteLine("The cube root is: " + QuinticRootApproximation(c).ToString());
            }

            else
            {
                Console.WriteLine("This was not an option");
            }
        }

        private static string FindPi(int NumberOfSides)
        {
            return (NumberOfSides * Math.Sin(Math.PI / NumberOfSides)) + " < pi < " + (NumberOfSides * Math.Tan(Math.PI / NumberOfSides));
        }

        private static double SquareRoot(double q)
        {
            int numDigitsInWholePart = (int)Math.Floor(Math.Log10(q));
            double exponentOnTen = numDigitsInWholePart / 2d;

            double Approximation = Math.Pow(10, exponentOnTen);
            double qOverApproximation = q / Approximation;

            double tolerance = Math.Pow(10, Math.Floor(exponentOnTen) - 14);

            while (Math.Abs(Approximation - qOverApproximation) > tolerance)
            {
                Approximation = (Approximation + qOverApproximation) / 2;
                qOverApproximation = q / Approximation;
            }
            return Approximation;
        }

        private static double SolutionApproximation(double initialGuess)
        {
            double xn = initialGuess;
            double nextTerm = Math.Pow(xn + 10, 0.25);
            int numOfWholeDigits = (int)Math.Floor(Math.Log10(xn)) + 1;
            double E = Math.Pow(10, numOfWholeDigits - 14);

            while (Math.Abs(xn - nextTerm) > E)
            {
                xn = nextTerm;
                nextTerm = Math.Pow(xn + 10, 0.25);
            }
            return xn;
        }

        private static double RoundOff(double numberToRound, double decimalPlaces)
        {
            double movedDecimalNumber = numberToRound * Math.Pow(10, decimalPlaces);
            int flooredNumber = (int)Math.Floor(movedDecimalNumber);
            double finalNumber;
            double lastDigit = Math.Floor((movedDecimalNumber - flooredNumber) * 10);

            if (lastDigit < 5)
            {
                finalNumber = Math.Floor(movedDecimalNumber);
            }
            else if (lastDigit > 5)
            {
                finalNumber = Math.Ceiling(movedDecimalNumber);
            }
            else
            {
                if (flooredNumber % 2 == 1)
                {
                    finalNumber = Math.Ceiling(movedDecimalNumber);
                }
                else
                {
                    finalNumber = Math.Floor(movedDecimalNumber);
                }
            }
            return finalNumber * Math.Pow(10, -decimalPlaces);
        }

        private static double RoundOffV2(double numberToRound, int decimalPlaces)
        {
            double decPtFactor = Math.Pow(10, decimalPlaces);
            double movedDecimalNum = numberToRound * decPtFactor;
            int flooredNumber = (int)Math.Floor(movedDecimalNum);
            double roundedValue;

            if (flooredNumber % 2 != 0 && movedDecimalNum - flooredNumber != 0.5)
            {
                roundedValue = Math.Floor(movedDecimalNum + 0.5);
            }

            else
            {
                roundedValue = Math.Floor(movedDecimalNum);
            }

            return roundedValue / decPtFactor;
        }

        private static double CubeRootApproximation(double c)
        {
            double xn, previousTerm;

            if (c == 0)
            {
                return 0;
            }

            xn = Math.Pow(10, (Math.Floor(Math.Log10(Math.Abs(c))) + 1) / 3);

            if (c < 0)
            {
                xn = -xn;
            }

            do
            {
                previousTerm = xn;
                xn -= (Math.Pow(xn, 3) - c) / (3 * Math.Pow(xn, 2));
            } while (previousTerm != xn);

            return xn;
        }

        private static double QuinticRootApproximation(double c)
        {
            if (c == 0)
            {
                return 0;
            }

            double numDigitsWholePart = Math.Floor(Math.Log10(Math.Abs(c)) + 1);
            double previousTerm;
            double xn = Math.Pow(10, numDigitsWholePart / 5);

            if (c < 0)
            {
                xn = -xn;
            }

            double tolerance = Math.Pow(10, numDigitsWholePart - 14);

            do
            {
                previousTerm = xn;
                xn -= (Math.Pow(xn, 5) - c) / (5 * Math.Pow(xn, 4));
            } while (Math.Abs(xn - previousTerm) > tolerance);

            return xn;
        }
    }
}