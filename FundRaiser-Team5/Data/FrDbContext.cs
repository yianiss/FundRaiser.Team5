using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Data
{
    class FrDbContext : DbContext
    {
        public DbSet<IUser> Users;
        public DbSet<Project> Projects;
        public DbSet<StatusUpdate> StatusUpdates;
    }
}
