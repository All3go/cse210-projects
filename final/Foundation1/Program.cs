using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C#", "Coder101", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "bangin tutorial my man."));

        Video video2 = new Video("Mastering Algorithms", "AlgoExpert", 900);
        video2.AddComment(new Comment("Dave", "This was a bit tough but worth it."));
        video2.AddComment(new Comment("Evie", "Clear explanations!"));
        video2.AddComment(new Comment("Frank", "i culd do better in teaching in my sleep"));

        Video video3 = new Video("Basic Arduino", "ArduiUniverse", 750);
        video3.AddComment(new Comment("Gracie", "Can't wait to try this out!"));
        video3.AddComment(new Comment("Emmett", "Imma build a a trap for my dad with this."));
        video3.AddComment(new Comment("Hannah", "So cool!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}