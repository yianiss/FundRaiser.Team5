using FundRaiser.Team5.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace FundRaiser.Team5.Core.Options
{
    public class OptionStatusUpdate
    {
        public int StatusUpdateId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }

        public DateTime TimeUploaded { get; set; }

        public bool IsActive { get; set; }

        public int ProjectId { get; set; }

        public OptionStatusUpdate() { }

        public OptionStatusUpdate(StatusUpdate statusUpdate)
        {
            StatusUpdateId = statusUpdate.StatusUpdateId;

            Title = statusUpdate.Title;

            Text = statusUpdate.Text;

            TimeUploaded = statusUpdate.TimeUploaded;

            IsActive = statusUpdate.IsActive;

            ProjectId = statusUpdate.Project.ProjectId;
        }

        public StatusUpdate GetStatusUpdate()
        {
            StatusUpdate statusUpdate = new()
            {
                Title = Title,
                Text = Text,
                TimeUploaded = DateTime.Now,
                IsActive = true
            };

            return statusUpdate;
        }
    }
}
