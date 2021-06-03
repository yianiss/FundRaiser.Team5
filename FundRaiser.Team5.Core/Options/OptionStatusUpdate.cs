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

        public DateTime TimeUploaded { get; set; } = DateTime.Now;

        public Project Project { get; set; }
    }
}
