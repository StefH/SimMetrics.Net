using System;

namespace SimMetrics.Net.Utilities
{
    public static class MathFunctions
    {
        public static double MaxOf3(double firstNumber, double secondNumber, double thirdNumber)
        {
            return Math.Max(firstNumber, Math.Max(secondNumber, thirdNumber));
        }

        public static int MaxOf3(int firstNumber, int secondNumber, int thirdNumber)
        {
            return Math.Max(firstNumber, Math.Max(secondNumber, thirdNumber));
        }

        public static double MaxOf4(double firstNumber, double secondNumber, double thirdNumber, double fourthNumber)
        {
            return Math.Max(Math.Max(firstNumber, secondNumber), Math.Max(thirdNumber, fourthNumber));
        }

        public static double MinOf3(double firstNumber, double secondNumber, double thirdNumber)
        {
            return Math.Min(firstNumber, Math.Min(secondNumber, thirdNumber));
        }

        public static int MinOf3(int firstNumber, int secondNumber, int thirdNumber)
        {
            return Math.Min(firstNumber, Math.Min(secondNumber, thirdNumber));
        }
    }
}