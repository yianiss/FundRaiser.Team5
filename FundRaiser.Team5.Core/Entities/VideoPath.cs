namespace FundRaiser.Team5.Core.Entities
{
    public class VideoPath
    {
        public int VideoPathId { get; set; }

        public Project Project { get; set; }

        public string Video { get; set; }
    }
}
