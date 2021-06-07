namespace FundRaiser.Team5.Core.Entities
{
    public class ImagePath
    {
        public int ImagePathId { get; set; }

        public Project Project { get; set; }

        public string Image { get; set; }
    }
}
