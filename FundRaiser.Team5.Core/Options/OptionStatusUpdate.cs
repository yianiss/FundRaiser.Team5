using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Options
{
    public class OptionStatusUpdate
    {
        public int StatusUpdateId { get; set; }
        //[Required]
        //[Display(Name = "Title")]
        public string Title { get; set; }
        //[Required]
        //[Display(Name = "Text")]
        public string Text { get; set; }
        public DateTime TimeUploaded { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public Project Project { get; set; }

        OptionStatusUpdate() { }

        OptionStatusUpdate(StatusUpdate statusUpdate)
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
