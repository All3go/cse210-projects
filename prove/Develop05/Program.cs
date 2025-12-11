using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        int choice = 0;

        Console.WriteLine("Welcome to the Eternal Quest Program!");

        while (choice != 6)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Show goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save/Load");
            Console.WriteLine("6. Quit");

            Console.Write("Choose: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1) CreateGoal(manager);
            else if (choice == 2) manager.ShowGoals();
            else if (choice == 3) manager.RecordEvent();
            else if (choice == 4) manager.DisplayScore();
            else if (choice == 5) SaveLoadMenu(manager);
        }

        Console.WriteLine("\nGoodbye!");
    }

    static void CreateGoal(GoalManager m)
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Choose: ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            m.AddGoal(new SimpleGoal(name, desc, points));
        }
        else if (type == 2)
        {
            m.AddGoal(new EternalGoal(name, desc, points));
        }
        else
        {
            Console.Write("Target amount: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            m.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    static void SaveLoadMenu(GoalManager m)
    {
        Console.WriteLine("\n1. Save");
        Console.WriteLine("2. Load");
        Console.Write("Choose: ");
        int option = int.Parse(Console.ReadLine());

        Console.Write("Filename: ");
        string file = Console.ReadLine();

        if (option == 1)
            m.Save(file);
        else
            m.Load(file);
    }
}
