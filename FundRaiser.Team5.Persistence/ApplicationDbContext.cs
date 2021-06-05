using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<UserFundingPackage> UserFundingPackages { get; set; }

        public DbSet<ImagePath> ImagePaths { get; set; }

        public DbSet<VideoPath> VideoPaths { get; set; }

        public DbSet<StatusUpdate> StatusUpdates { get; set; }

        public DbSet<FundingPackage> FundingPackages { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=RegenerationCrm; User Id=sa; Password=admin!@#123");
        }*/

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
