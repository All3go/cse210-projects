using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different from other times?",
            "What could you learn from this experience?"
        };

        public ReflectingActivity() :
            base("Reflecting Activity",
                 "This activity will help you reflect on times when you have shown strength and resilience.")
        { }

        public override void Run()
        {
            Start();
            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);

            Console.WriteLine("\nPrompt:");
            Console.WriteLine($"--- {_prompts[_rand.Next(_prompts.Count)]} ---");
            Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
            Console.ReadLine();

            while (TimeRemaining(end))
            {
                Console.WriteLine(_questions[_rand.Next(_questions.Count)]);
                PauseWithSpinner(6);
                Console.WriteLine();
            }

            End();
        }
    }
}
