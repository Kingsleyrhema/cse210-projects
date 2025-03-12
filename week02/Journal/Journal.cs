using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            string json = JsonConvert.SerializeObject(_entries, Formatting.Indented);
            File.WriteAllText(filename, json);
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving journal: {e.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                _entries = JsonConvert.DeserializeObject<List<Entry>>(json) ?? new List<Entry>();
                Console.WriteLine($"Journal loaded from {filename}");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading journal: {e.Message}");
        }
    }

    public void SearchEntries(string keyword)
    {
        var results = _entries.Where(e => e.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                          e.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("No entries found with that keyword.");
            return;
        }

        Console.WriteLine("\n--- Search Results ---");
        foreach (var entry in results)
        {
            entry.Display();
        }
    }

    public void EditEntry(int index)
    {
        if (index < 0 || index >= _entries.Count)
        {
            Console.WriteLine("Invalid entry number.");
            return;
        }

        Console.WriteLine("Enter new response: ");
        string newResponse = Console.ReadLine();
        _entries[index].Response = newResponse;
        Console.WriteLine("Entry updated successfully!");
    }
}
