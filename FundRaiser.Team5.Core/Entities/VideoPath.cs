using System.ComponentModel.DataAnnotations.Schema;
namespace FundRaiser.Team5.Core.Entities
{
    public class VideoPath
    {
        public int VideoPathId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public string Video { get; set; }
    }
}
