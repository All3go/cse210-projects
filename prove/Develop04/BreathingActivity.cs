using System;

namespace MindfulnessProgram
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() :
            base("Breathing Activity",
                 "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        public override void Run()
        {
            Start();
            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);

            while (TimeRemaining(end))
            {
                Console.Write("\nBreathe in... ");
                Countdown(4);
                Console.Write("\nBreathe out... ");
                Countdown(6);
                Console.WriteLine();
            }

            End();
        }
    }
}
