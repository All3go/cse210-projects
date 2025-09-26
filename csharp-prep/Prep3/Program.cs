using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Number Guesser! Enter a number between 1 and 100 and we will tell you if it's higher or lower.");
        Random random = new Random();
        int SecretNumber = random.Next(1, 100);

        Console.Write("Enter your guess: ");
        int UserGuess = int.Parse(Console.ReadLine());

        while (UserGuess != SecretNumber)
        {
            if (UserGuess < SecretNumber)
            {
                Console.WriteLine("Higher");
                Console.Write("Enter your guess: ");
                UserGuess = int.Parse(Console.ReadLine());
            }
            else if (UserGuess > SecretNumber)
            {
                Console.WriteLine("Lower");
                Console.Write("Enter your guess: ");
                UserGuess = int.Parse(Console.ReadLine());
            }

            if (UserGuess == SecretNumber)
            {
                Console.WriteLine("That is my secret Number! You Win!");
                Console.Write("Would you like to play again? (y/n): ");
                string playAgain = Console.ReadLine().ToLower();
                if (playAgain == "y")
                {
                    SecretNumber = random.Next(1, 100);
                    Console.Write("Enter your guess: ");
                    UserGuess = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Thanks for playing! Goodbye!");
                    break;
                }
            }

        }
    }     
}