using System;

namespace DoomsdayProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = DayOfTheWeek(30, 09, 2002);

            Console.WriteLine(day);
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
    }
}
