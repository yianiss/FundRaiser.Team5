using System.ComponentModel.DataAnnotations.Schema;

namespace FundRaiser.Team5.Core.Entities
{
    public class ImagePath
    {
        public int ImagePathId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public string Image { get; set; }

    }

 
}
