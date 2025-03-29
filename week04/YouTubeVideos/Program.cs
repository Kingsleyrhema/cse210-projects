using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(string commenterName, string text)
    {
        comments.Add(new Comment(commenterName, text));
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Basics", "John Doe", 600);
        video1.AddComment("Alice", "Great tutorial!");
        video1.AddComment("Bob", "Very helpful, thanks!");
        video1.AddComment("Charlie", "Clear and concise explanation.");

        Video video2 = new Video("OOP in C#", "Jane Smith", 900);
        video2.AddComment("David", "Best OOP explanation I've seen.");
        video2.AddComment("Emma", "Super useful, thanks!");
        video2.AddComment("Frank", "I learned a lot from this.");

        Video video3 = new Video("Advanced C# Concepts", "Mike Johnson", 1200);
        video3.AddComment("George", "Mind-blowing stuff!");
        video3.AddComment("Hannah", "This helped me with my project.");
        video3.AddComment("Ian", "Please make more videos like this.");

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
