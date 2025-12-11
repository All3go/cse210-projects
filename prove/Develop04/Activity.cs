using System;

namespace MindfulnessProgram
{
    public class Activity
    {
        public string Name;
        public string Description;
        public int Duration;

        public Activity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual void Start()
        {
            Console.Clear();
            Console.WriteLine($"Beginning {Name}...");
            Console.WriteLine(Description);

            Console.Write("\nEnter duration in seconds: ");
            int seconds;

            if (!int.TryParse(Console.ReadLine(), out seconds))
            {
                seconds = 30; 
            }

            Duration = seconds;

            Console.WriteLine($"Get ready to begin!)");
            Thread.Sleep(2000);
        }
        public virtual void End()
        {
            Console.WriteLine($"\nYou have completed the {Name} for {Duration} seconds.");
            Console.WriteLine("Well done!");
            Thread.Sleep(1500);
        }
    }
}
