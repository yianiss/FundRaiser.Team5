using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser_Team5.Model;

namespace FundRaiser_Team5.Data
{
    class FrDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<BackerFundingPackage> backerFundingPackages { get; set; }
        public DbSet<ImagePath> ImagePaths { get; set; }
        public DbSet<VideoPath> VideoPaths { get; set; }
        public DbSet<StatusUpdate> StatusUpdates { get; set; }
        public DbSet<FundingPackage> FundingPackages { get; set; }



    }
}
