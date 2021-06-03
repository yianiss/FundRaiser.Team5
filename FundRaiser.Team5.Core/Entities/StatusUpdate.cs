﻿using System;

namespace FundRaiser_Team5
{
    public class StatusUpdate
    {
        public int StatusUpdateId { get; set; }
        public string Title{ get; set; }
        public string Text { get; set; }
        public DateTime TimeUploaded { get; set; } = DateTime.Now;
        public Project Project { get; set; }
        public bool IsActive { get; set; }
    }
}
