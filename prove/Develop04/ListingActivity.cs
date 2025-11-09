using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people you have helped this week?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() :
            base("Listing Activity",
                 "This activity helps you reflect on the good things in your life by listing as many as you can.")
        { }

        public override void Run()
        {
            Start();
            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);

            Console.WriteLine("\nPrompt:");
            Console.WriteLine($"--- {_prompts[_rand.Next(_prompts.Count)]} ---");
            Console.Write("\nYou may begin in: ");
            Countdown(5);
            Console.WriteLine("\nStart listing! (Press Enter after each item)");

            List<string> items = new List<string>();
            while (TimeRemaining(end))
            {
                Console.Write("> ");
                string entry = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entry))
                    items.Add(entry);
            }

            Console.WriteLine($"\nYou listed {items.Count} item(s).");
            End();
        }
    }
}
