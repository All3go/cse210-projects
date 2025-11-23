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
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Show Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save/Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("Choose an option: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateGoal(manager); break;
                case 2: manager.ShowGoals(); break;
                case 3: manager.RecordEvent(); break;
                case 4: manager.DisplayScore(); break;
                case 5: SaveLoadMenu(manager); break;
            }
        }

        Console.WriteLine("\nGoodbye!");
    }

    static void CreateGoal(GoalManager m)
    {
        Console.WriteLine("\nTypes of goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type? ");
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
            Console.Write("Target count: ");
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

        Console.Write("File name: ");
        string file = Console.ReadLine();

        if (option == 1) m.Save(file);
        else m.Load(file);
    }
}
