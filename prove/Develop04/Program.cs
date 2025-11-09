using System;
using System.Diagnostics;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness Program!");
                Console.WriteLine("Please select an activity:");
                Console.WriteLine("1. Breathing Exercise");
                Console.WriteLine("2. Reflecting Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Enter your choice (1-4): ");

                string choice = Console.ReadLine();
                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectingActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        Console.WriteLine("Thank you, we hope you were able to relax. Goodbye!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to continue.");
                        Console.ReadLine();
                        break;
                }

                if (!exit && activity != null)
                {
                    activity.Run();
                    Console.WriteLine("\nPress Enter to return to the main menu.");
                    Console.ReadLine();
                }
            }
        }
    }
}