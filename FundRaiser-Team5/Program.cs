using System;
using System.Collections.Generic;

namespace FundRaiser_Team5
{
    class Program
    {
        static void Main(string[] args)
        {
            Project project = new()
            {
                ProjectId = 8881,
                Category = 2,
                CreatorId = 3,
                Title = "Title 1",
                Description = "Description 1",
                Photos = new List<string>(),
                Videos = new List<string>(),
                StatusUpdates = new List<StatusUpdate>(),
                FundingGoal = 10000.00M,
                Deadline = DateTime.Now.AddDays(7)
            };

            project.Photos.Add("image1.png");
            project.Photos.Add("image2.png");

            project.Videos.Add("video1.mp4");
            project.Videos.Add("video2.mp4");
            project.Videos.Add("video3.mp4");

            project.StatusUpdates.Add(
                new()
                {
                    Title = "Update1",
                    Text = "Text of update 1"
                }
           );

            Console.WriteLine($"{project.ProjectId}");
            Console.WriteLine($"{project.CreatorId}");
            Console.WriteLine($"{project.Category}");
            Console.WriteLine($"{project.Title}");
            Console.WriteLine($"{project.Description}");

            project.Photos.ForEach(p => Console.WriteLine($"{p}"));
            project.Videos.ForEach(p => Console.WriteLine($"{p}"));

            project.StatusUpdates.ForEach(p => Console.WriteLine($"{p.Title} {p.Text} {p.TimeUploaded}"));

            Console.WriteLine($"{project.FundingGoal}");
            Console.WriteLine($"{project.CurrentFund}");
            Console.WriteLine($"{project.DateCreated}");
            Console.WriteLine($"{project.Deadline}");

        }
    }
}
