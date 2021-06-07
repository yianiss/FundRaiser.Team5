using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Entities;

namespace FundRaiser_Team5.Options
{
    public class OptionVideoPath
    {
        public int VideoPathId { get; set; }

        public int ProjectId { get; set; }

        public string Video { get; set; }

        public OptionVideoPath() { }

        public OptionVideoPath(VideoPath videoPath)
        {
            if (videoPath != null)
            {
                VideoPathId = videoPath.VideoPathId;
                ProjectId = videoPath.Project.ProjectId;
                Video = videoPath.Video;
            }
        }

        public VideoPath GetVideoPath()
        {
            return new VideoPath
            {
                VideoPathId = VideoPathId,
                Video = Video,
            };
        }
    }
}
