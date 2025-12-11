using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;

        public ReflectingActivity()
            : base("Reflecting Activity", "This activity helps you reflect on times when you have shown strength.")
        {
            _prompts = new List<string>();
            _prompts.Add("Think of a time when you stood up for someone else.");
            _prompts.Add("Think of a time when you did something really difficult.");
            _prompts.Add("Think of a time when you helped someone in need.");
            _prompts.Add("Think of a time when you did something truly selfless.");

            _questions = new List<string>();
            _questions.Add("Why was this experience meaningful to you?");
            _questions.Add("Have you ever done anything like this before?");
            _questions.Add("How did you get started?");
            _questions.Add("How did you feel when it was complete?");
        }

        public override void Start()
        {
            base.Start();

            Random rand = new Random();
            int index = rand.Next(0, _prompts.Count);
            string prompt = _prompts[index];

            Console.WriteLine();
            Console.WriteLine("Consider this prompt:");
            Console.WriteLine("-> " + prompt);

            Console.WriteLine();
            Console.WriteLine("Take some time to think about this...");

            System.Threading.Thread.Sleep(3000);

            End();
        }
    }
}
