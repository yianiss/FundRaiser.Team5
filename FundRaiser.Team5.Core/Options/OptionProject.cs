using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FundRaiser.Team5.Core.Entities;

namespace FundRaiser.Team5.Core.Options
{
    public class OptionProject
    {
        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Category")]
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "List of Funding Packages")]
        public List<FundingPackage> FundingPackages { get; set; }

        public List<ImagePath> Images { get; set; }

        public List<VideoPath> Videos { get; set; }

        public List<StatusUpdate> StatusUpdates { get; set; }

        [Required]
        [Display(Name = "Funding Goal")]
        public decimal FundingGoal { get; set; }

        [Display(Name = "Current Fund")]
        public decimal CurrentFund { get; set; } = 0;

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Deadline")]
        public DateTime Deadline { get; set; }

        public bool IsActive { get; set; }

        public int UserId { get; set; }

        public OptionProject() { }

        public OptionProject(Project project)
        {
            if (project != null)
            {
                ProjectId = project.ProjectId;

                Title = project.Title;

                Category = project.Category;

                Description = project.Description;

                FundingPackages = project.FundingPackages;

                Images = project.Images;

                Videos = project.Videos;

                StatusUpdates = project.StatusUpdates;

                FundingGoal = project.FundingGoal;

                CurrentFund = project.CurrentFund;

                DateCreated = project.DateCreated;

                Deadline = project.Deadline;

                UserId = project.User.UserId;

                IsActive = project.IsActive;
            }
        }

        public Project GetProject()
        {
            Project project = new()
            {
                ProjectId = ProjectId,
                Title = Title,
                Category = Category,
                Description = Description,
                FundingPackages = FundingPackages,
                Images = Images,
                Videos = Videos,
                StatusUpdates = StatusUpdates,
                FundingGoal = FundingGoal,
                CurrentFund = 0,
                DateCreated = DateTime.Now,
                Deadline = Deadline,
                IsActive = true
            };

            return project;
        }
    }
}
