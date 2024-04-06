using System;

namespace Hw3
{
    internal class DataProcessing
    {
        public static string GetFullname(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }

        public static double CalculateAverageLengthOfColors(string[] colors)
        {
            double totalLength = 0;
            foreach (var color in colors)
            {
                totalLength += color.Length;
            }

            return totalLength / colors.Length;
        }
    }
}
