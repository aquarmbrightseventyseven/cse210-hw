using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        // Create video 1
        Video video1 = new Video(
            "Introduction to C#",
            "Programming Academy",
            600
        );

        video1.AddComment(new Comment(
            "John",
            "This was a great introduction to C#."
        ));

        video1.AddComment(new Comment(
            "Mary",
            "I learned a lot from this video."
        ));

        video1.AddComment(new Comment(
            "David",
            "Very clear and easy to understand."
        ));

        // Create video 2
        Video video2 = new Video(
            "Learn Object-Oriented Programming",
            "Code Master",
            900
        );

        video2.AddComment(new Comment(
            "Sarah",
            "The explanation of classes was excellent."
        ));

        video2.AddComment(new Comment(
            "Michael",
            "This helped me understand abstraction."
        ));

        video2.AddComment(new Comment(
            "James",
            "I would like to see more examples."
        ));

        video2.AddComment(new Comment(
            "Linda",
            "Very useful lesson."
        ));

        // Create video 3
        Video video3 = new Video(
            "C# Collections Explained",
            "Tech Learning",
            750
        );

        video3.AddComment(new Comment(
            "Robert",
            "The explanation of lists was very helpful."
        ));

        video3.AddComment(new Comment(
            "Emma",
            "I finally understand how List works."
        ));

        video3.AddComment(new Comment(
            "Daniel",
            "Great examples in this video."
        ));

        // Create video 4
        Video video4 = new Video(
            "Building Your First C# Program",
            "Coding World",
            1200
        );

        video4.AddComment(new Comment(
            "Peter",
            "This is exactly what I needed."
        ));

        video4.AddComment(new Comment(
            "Grace",
            "Very helpful tutorial."
        ));

        video4.AddComment(new Comment(
            "Samuel",
            "The step-by-step approach was excellent."
        ));

        video4.AddComment(new Comment(
            "Anna",
            "I enjoyed this lesson."
        ));

        // Put all videos into a list
        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display each video and its comments
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    $"- {comment.GetCommenterName()}: {comment.GetText()}"
                );
            }

            Console.WriteLine();
        }
    }
}