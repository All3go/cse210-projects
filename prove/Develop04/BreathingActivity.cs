using System;

namespace MindfulnessProgram
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() :
            base("Breathing Activity",
                 "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {}

        public override void Start()
        {
            base.Start();

            int inhaleTime = 4;
            int exhaleTime = 3;
            int cycleTime = inhaleTime + exhaleTime;

            int cycles = Duration / cycleTime;

            for (int i = 0; i < cycles; i++)
            {
                Console.WriteLine("\nBreathe in...");
                System.Threading.Thread.Sleep(inhaleTime * 1000);

                Console.WriteLine("Breathe out...");
                System.Threading.Thread.Sleep(exhaleTime * 1000);
            }

            End();
        }
    }
}

