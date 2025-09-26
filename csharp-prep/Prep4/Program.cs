using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Number tracker!");
        Console.WriteLine("You can enter as many numbers as you like, and when you're done, Enter the Number '0' to see the results.");
        List<int> numbers = new List<int>();
        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        if (numbers.Count > 0)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            double average = (double)sum / numbers.Count;
            Console.WriteLine($"The sum of the numbers is: {sum}");
            Console.WriteLine($"The average of the numbers is: {average}");
            Console.WriteLine($"The largest number is: {numbers.Max()}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}