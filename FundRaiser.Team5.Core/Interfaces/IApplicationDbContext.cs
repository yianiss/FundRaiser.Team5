using FundRaiser_Team5.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Interfaces
{
   public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<UserFundingPackage> UserFundingPackages { get; set; }

        public DbSet<ImagePath> ImagePaths { get; set; }

        public DbSet<VideoPath> VideoPaths { get; set; }

        public DbSet<StatusUpdate> StatusUpdates { get; set; }

        public DbSet<FundingPackage> FundingPackages { get; set; }

        Task<int> SaveChangesAsync();
    }
}
