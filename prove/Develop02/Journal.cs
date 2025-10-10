using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

        public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                // Attempt to fix extra events to be displayed after save/load
                string safeResponse = entry.Response.Replace("\r\n", "<br>").Replace("\n", "<br>");
                outputFile.WriteLine($"{entry.Date}|{entry.Prompt}|{safeResponse}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        entries.Clear();

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                // Restore line breaks when displaying
                string restoredResponse = parts[2].Replace("<br>", Environment.NewLine);

                Entry entry = new Entry
                {
                    Date = parts[0],
                    Prompt = parts[1],
                    Response = restoredResponse
                };
                entries.Add(entry);
            }
        }
    }

}
