using FundRaiser_Team5.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace FundRaiser_Team5.Options
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

        public DateTime TimeUploaded { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public Project Project { get; set; }

        public OptionStatusUpdate() { }

        public OptionStatusUpdate(StatusUpdate statusUpdate)
        {
            StatusUpdateId = statusUpdate.StatusUpdateId;
            Title = statusUpdate.Title;
            Text = statusUpdate.Text;
            TimeUploaded = statusUpdate.TimeUploaded;
            IsActive = statusUpdate.IsActive;
        }

        public StatusUpdate GeStatusUpdate()
        {
            StatusUpdate statusUpdate = new()
            {
                Title = Title,
                Text = Text,
                TimeUploaded = DateTime.Now,
                IsActive = IsActive
            };
            return statusUpdate;
        }
    }
}
