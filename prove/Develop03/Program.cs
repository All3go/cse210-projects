using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>()
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding"),
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life"),
            new Scripture(new Reference("Psalm", 23, 1),
                "The Lord is my shepherd; I shall not want"),
            new Scripture(new Reference("Mosiah", 18, 9),
            "Stand fast in the faith, having a perfect brightness of hope, and a love of God and of all men"),
            new Scripture(new Reference("Ether", 12, 27),
                "My grace is sufficient for all men that humble themselves before me"),
            new Scripture(new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy"),
            new Scripture(new Reference("Alma", 37, 6),
                "By small and simple things are great things brought to pass; and small means in many instances doth confound the wise")
        };

        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);

            if (scripture.AllWordsHidden())
                break;
        }
    }
}
