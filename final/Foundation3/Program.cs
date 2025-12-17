using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Boise", "ID", "USA");
        Address address2 = new Address("456 Maple Rd", "Toronto", "ON", "Canada");
        Address address3 = new Address("789 Park Ave", "Seattle", "WA", "USA");

        List<Event> events = new List<Event>();

        events.Add(new Lecture("C# Workshop", "Learn the basics of C#", "2025-12-20", "10:00 AM",
                               address1, "Alice Johnson", 30));
        events.Add(new Reception("Holiday Party", "End of year celebration", "2025-12-24", "6:00 PM",
                                 address2, "rsvp@party.com"));
        events.Add(new OutdoorGathering("Yoga in the Park", "Morning Yoga Session", "2025-12-21", "8:00 AM",
                                        address3, "Sunny with light breeze"));

        foreach (Event e in events)
        {
            Console.WriteLine("--- Standard Details ---");
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine("--- Full Details ---");
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine("--- Short Description ---");
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine();
        }
    }
}
