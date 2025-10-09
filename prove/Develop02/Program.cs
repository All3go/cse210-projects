using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();

        Random random = new Random();
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something I am grateful for today?",
            "What is something my spouse did for me today that I appreciate?",
            "Who did I help today and how?",
        };

        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal file");
            Console.WriteLine("4. Load journal file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

           if (choice == "1")
            {
                Console.Write("Enter today’s date (e.g., 10/3/2025): ");
                string date = Console.ReadLine();

                string prompt = prompts[random.Next(prompts.Length)];
                Console.WriteLine("\nPrompt: " + prompt);

                string response = "";

                Console.Write("Your Response: ");
                string line = Console.ReadLine();
                response += line + "\n";

                bool addingEvents = true;
                while (addingEvents)
                {
                    Console.Write("Do you want to add another event to this entry? (y/n): ");
                    string more = Console.ReadLine();
                    if (more.ToLower() != "y")
                    {
                        addingEvents = false;
                    }
                    else
                    {
                        Console.Write("Write your next event: ");
                        line = Console.ReadLine();
                        response += line + "\n";
                    }
                }

                Entry newEntry = new Entry
                {
                    Date = date,
                    Prompt = prompt,
                    Response = response
                };

                myJournal.AddEntry(newEntry);
                Console.WriteLine("\nEntry added!\n");
            }

            else if (choice == "2")
            {
                myJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
                Console.WriteLine("Journal saved!\n");
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded!\n");
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid option, try again.\n");
            }
        }
    }
}
