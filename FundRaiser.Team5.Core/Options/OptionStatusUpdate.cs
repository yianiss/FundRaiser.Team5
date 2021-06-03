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

        public Project Project { get; set; }
    }
}
