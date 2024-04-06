using System;
using System.Xml;

namespace Hw3
{
    internal class Program
    {
        static (string, string, int, bool, string[]) GetUserData()
        {
            Console.WriteLine("Enter your first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter your last name:");
            string lastName = Console.ReadLine();

            int age = GetUserInput("Enter your age:");

            Console.WriteLine("Do you have a pet? (Y/N):");
            bool hasPet = Console.ReadLine().ToUpper() == "Y";

            int petCount = 0;
            string[] petNames = null;
            if (hasPet)
            {
                petCount = GetUserInput("Enter the number of pets you have:");
                petNames = new string[petCount];
                for (int i = 0; i < petCount; i++)
                {
                    Console.WriteLine("Enter the name of pet " + (i + 1) + ":");
                    petNames[i] = Console.ReadLine();
                }
            }

            int favoriteColorCount = GetUserInput("Enter the number of favorite colors:");
            string[] favoriteColors = new string[favoriteColorCount];
            for (int i = 0; i < favoriteColorCount; i++)
            {
                Console.WriteLine("Enter the favorite color " + (i + 1) + ":");
                favoriteColors[i] = Console.ReadLine();
            }

            return (firstName, lastName, age, hasPet, favoriteColors);
        }

        static int GetUserInput(string message)
        {
            int result = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out result) && result > 0)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive integer.");
                }
            }
            return result;
        }

        static void DisplayUserData((string, string, int, bool, string[]) userData)
        {
            Console.WriteLine("\n--- User Information ---");
            Console.WriteLine("First Name: " + userData.Item1);
            Console.WriteLine("Last Name: " + userData.Item2);
            Console.WriteLine("Age: " + userData.Item3);

            if (userData.Item4)
            {
                Console.WriteLine("You have pets:");
                foreach (var pet in userData.Item5)
                {
                    Console.WriteLine("  - " + pet);
                }
            }
            else
            {
                Console.WriteLine("You do not have pets.");
            }

            Console.WriteLine("Favorite Colors:");
            foreach (var color in userData.Item5)
            {
                Console.WriteLine("  - " + color);
            }
        }

        static void Main()
        {
            var userData = GetUserData();
            DisplayUserData(userData);

            string fullName = DataProcessing.GetFullname(userData.Item1, userData.Item2);
            Console.WriteLine("\nFull Name: " + fullName);

            double averageLength = DataProcessing.CalculateAverageLengthOfColors(userData.Item5);
            Console.WriteLine("Average length of favorite colors: " + averageLength);
        }
    }
    }