using System;
using System.Collections.Generic;

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
                 "This activity helps you focus on the good things in your life by listing as many as you can.")
        { }

        public override void Start()
        {
            base.Start();

            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];

            Console.WriteLine($"\nPrompt: {prompt}");
            Console.WriteLine("Start listing items! Press Enter after each one.\n");

            List<string> answers = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(Duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string response = Console.ReadLine();
                answers.Add(response);
            }

            Console.WriteLine($"\nYou listed {answers.Count} item(s)!");
            End();
        }
    }
}

