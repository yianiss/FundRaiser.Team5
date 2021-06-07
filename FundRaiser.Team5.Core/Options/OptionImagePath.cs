using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Entities;

namespace FundRaiser_Team5.Options
{
    public class OptionImagePath
    {
        public int ImagePathId { get; set; }

        public int ProjectId { get; set; }

        public string Image { get; set; }

        public OptionImagePath() { }

        public OptionImagePath(ImagePath imagePath)
        {
            if (imagePath != null)
            {
                ImagePathId = imagePath.ImagePathId;
                ProjectId = imagePath.Project.ProjectId;
                Image = imagePath.Image;
            }
        }

        public ImagePath GetImagePath()
        {
            return new ImagePath
            {
                ImagePathId = ImagePathId,
                Image = Image,
            };
        }
    }
}
