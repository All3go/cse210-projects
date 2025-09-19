using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please Enter Youre Grade Percentage: ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);
        string letterGrade;

        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        Console.WriteLine($"Your grade is a: {letterGrade}");
    }
}