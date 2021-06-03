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
