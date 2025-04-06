using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public abstract class MindfulnessActivity
{
    protected string activityName;
    protected string activityDescription;
    protected int duration;

    public MindfulnessActivity(string name, string description)
    {
        activityName = name;
        activityDescription = description;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {activityName}!");
        Console.WriteLine(activityDescription);
        Console.Write("Please enter the duration in seconds: ");
        duration = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nGet ready to begin...");
        Thread.Sleep(2000);
        Console.Clear();
    }

    public abstract void RunActivity();

    protected void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void EndActivity()
    {
        Console.Clear();
        Console.WriteLine($"Good job! You completed the {activityName}.");
        Console.WriteLine($"Duration: {duration} seconds.");
        Pause(3);
        Console.Clear();
    }
}

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public override void RunActivity()
    {
        int halfDuration = duration / 2;
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Clear();
            Console.WriteLine("Breathe in...");
            Pause(halfDuration);

            Console.Clear();
            Console.WriteLine("Breathe out...");
            Pause(halfDuration);
        }
    }
}

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    { }

    public override void RunActivity()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.Clear();
        Console.WriteLine(prompt);
        Thread.Sleep(3000);

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Clear();
            string question = reflectionQuestions[random.Next(reflectionQuestions.Count)];
            Console.WriteLine(question);
            Pause(3);
        }
    }
}

public class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    public override void RunActivity()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];

        Console.Clear();
        Console.WriteLine(prompt);
        Thread.Sleep(2000);

        List<string> userEntries = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        Console.Clear();
        Console.WriteLine("Start listing now (press Enter after each item).");
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            string entry = Console.ReadLine();
            userEntries.Add(entry);
        }

        Console.Clear();
        Console.WriteLine($"You listed {userEntries.Count} items.");
        Thread.Sleep(2000);
    }
}

public class MindfulnessProgram
{
    public static void Main(string[] args)
    {
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Please choose an activity (1-4): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    continue;
            }

            if (activity != null)
            {
                activity.StartActivity();
                activity.RunActivity();
                activity.EndActivity();
            }
        }

        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}
