using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Scenario
{
    public class Test : ITest
    {

        private readonly IApplicationDbContext _context;

        public Test(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Createdb()
        {

            //await _context.Users.AddAsync(new User() { FirstName = "User1F", LastName = "User1L", Email = "User1@email.com", Password = "User1_1234", IsActive = true });
            //await _context.Users.AddAsync(new User() { FirstName = "User2F", LastName = "User2L", Email = "User2@email.com", Password = "User2_1234", IsActive = true });
            //await _context.Users.AddAsync(new User() { FirstName = "User3F", LastName = "User3L", Email = "User3@email.com", Password = "User3_1234", IsActive = true });
            //await _context.Users.AddAsync(new User() { FirstName = "User5F", LastName = "User5L", Email = "User5@email.com", Password = "User5_1234", IsActive = true });
            //await _context.Users.AddAsync(new User() { FirstName = "User6F", LastName = "User6L", Email = "User6@email.com", Password = "User6_1234", IsActive = true });
            //await _context.Users.AddAsync(new User() { FirstName = "User7F", LastName = "User7L", Email = "User7@email.com", Password = "User7_1234", IsActive = true });
            //await _context.Users.AddAsync(new User() { FirstName = "User4F", LastName = "User4L", Email = "User4@email.com", Password = "User4_1234", IsActive = true });
            //await _context.Users.AddAsync(new User() { FirstName = "User8F", LastName = "User8L", Email = "User8@email.com", Password = "User8_1234", IsActive = true });
            //await _context.Users.AddAsync(new User() { FirstName = "User9F", LastName = "User9L", Email = "User9@email.com", Password = "User9_1234", IsActive = true });
            //await _context.Users.AddAsync(new User() { FirstName = "User0F", LastName = "User0L", Email = "User0@email.com", Password = "User0_1234", IsActive = true });
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}

            //catch (Exception ex)
            //{
            //    return new Result<int>(ErrorCode.InternalServerError, "Could not save users.");
            //}

            //var User1 = _context.Users.Find(1);
            //var User2 = _context.Users.Find(2);
            //var User3 = _context.Users.Find(3);

            //await _context.Projects.AddAsync(new Project() { User = User1, Title = "Project1", Description = "Description1", CurrentFund = 0, FundingGoal = 100, DateCreated = DateTime.Now, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            //await _context.Projects.AddAsync(new Project() { User = User1, Title = "Project2", Description = "Description2", CurrentFund = 0, FundingGoal = 100, DateCreated = DateTime.Now, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            //await _context.Projects.AddAsync(new Project() { User = User1, Title = "Project3", Description = "Description3", CurrentFund = 0, FundingGoal = 100, DateCreated = DateTime.Now, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            //await _context.Projects.AddAsync(new Project() { User = User1, Title = "Project4", Description = "Description4", CurrentFund = 0, FundingGoal = 100, DateCreated = DateTime.Now, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            //await _context.Projects.AddAsync(new Project() { User = User1, Title = "Project5", Description = "Description5", CurrentFund = 0, FundingGoal = 100, DateCreated = DateTime.Now, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            //await _context.Projects.AddAsync(new Project() { User = User2, Title = "Project6", Description = "Description6", CurrentFund = 0, FundingGoal = 100, DateCreated = DateTime.Now, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            //await _context.Projects.AddAsync(new Project() { User = User2, Title = "Project7", Description = "Description7", CurrentFund = 0, FundingGoal = 100, DateCreated = DateTime.Now, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            //await _context.Projects.AddAsync(new Project() { User = User2, Title = "Project8", Description = "Description8", CurrentFund = 0, FundingGoal = 100, DateCreated = DateTime.Now, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            //await _context.Projects.AddAsync(new Project() { User = User3, Title = "Project9", Description = "Description9", CurrentFund = 0, FundingGoal = 100, DateCreated = DateTime.Now, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            //await _context.Projects.AddAsync(new Project() { User = User3, Title = "Project0", Description = "Description0", CurrentFund = 0, FundingGoal = 100, DateCreated = DateTime.Now, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}

            //catch (Exception ex)
            //{
            //    return new Result<int>(ErrorCode.InternalServerError, "Could not save Projects.");
            //}

            //var Project1 = _context.Projects.Find(1);
            //var Project2 = _context.Projects.Find(2);
            //var Project3 = _context.Projects.Find(3);
            //var Project4 = _context.Projects.Find(4);

            //await _context.StatusUpdates.AddAsync(new StatusUpdate() { Project = Project1, Title = "PostStatusUpdate1", Text = "Message1", TimeUploaded = DateTime.Now, IsActive = true });
            //await _context.StatusUpdates.AddAsync(new StatusUpdate() { Project = Project1, Title = "PostStatusUpdate2", Text = "Message2", TimeUploaded = DateTime.Now, IsActive = true });
            //await _context.StatusUpdates.AddAsync(new StatusUpdate() { Project = Project1, Title = "PostStatusUpdate3", Text = "Message3", TimeUploaded = DateTime.Now, IsActive = true });
            //await _context.StatusUpdates.AddAsync(new StatusUpdate() { Project = Project2, Title = "PostStatusUpdate4", Text = "Message4", TimeUploaded = DateTime.Now, IsActive = true });
            //await _context.StatusUpdates.AddAsync(new StatusUpdate() { Project = Project2, Title = "PostStatusUpdate5", Text = "Message5", TimeUploaded = DateTime.Now, IsActive = true });
            //await _context.StatusUpdates.AddAsync(new StatusUpdate() { Project = Project2, Title = "PostStatusUpdate6", Text = "Message6", TimeUploaded = DateTime.Now, IsActive = true });
            //await _context.StatusUpdates.AddAsync(new StatusUpdate() { Project = Project3, Title = "PostStatusUpdate7", Text = "Message7", TimeUploaded = DateTime.Now, IsActive = true });
            //await _context.StatusUpdates.AddAsync(new StatusUpdate() { Project = Project3, Title = "PostStatusUpdate8", Text = "Message8", TimeUploaded = DateTime.Now, IsActive = true });
            //await _context.StatusUpdates.AddAsync(new StatusUpdate() { Project = Project4, Title = "PostStatusUpdate9", Text = "Message9", TimeUploaded = DateTime.Now, IsActive = true });
            //await _context.StatusUpdates.AddAsync(new StatusUpdate() { Project = Project4, Title = "PostStatusUpdate0", Text = "Message0", TimeUploaded = DateTime.Now, IsActive = true });
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}

            //catch (Exception ex)
            //{
            //    return new Result<int>(ErrorCode.InternalServerError, "Could not save status Update.");
            //}

            //var FProject1 = _context.Projects.Find(1);
            //var FProject2 = _context.Projects.Find(2);
            //var FProject3 = _context.Projects.Find(3);
            //var FProject4 = _context.Projects.Find(4);

            //await _context.FundingPackages.AddAsync(new FundingPackage() { Project = FProject1, Title = "FundingPackage1", Description = "Description1", MinPrice = 10, NumberOfAvailablePackages = 1000, IsActive = true });
            //await _context.FundingPackages.AddAsync(new FundingPackage() { Project = FProject1, Title = "FundingPackage2", Description = "Description2", MinPrice = 20, NumberOfAvailablePackages = 1000, IsActive = true });
            //await _context.FundingPackages.AddAsync(new FundingPackage() { Project = FProject1, Title = "FundingPackage3", Description = "Description3", MinPrice = 50, NumberOfAvailablePackages = 1000, IsActive = true });
            //await _context.FundingPackages.AddAsync(new FundingPackage() { Project = FProject2, Title = "FundingPackage4", Description = "Description4", MinPrice = 10, NumberOfAvailablePackages = 1000, IsActive = true });
            //await _context.FundingPackages.AddAsync(new FundingPackage() { Project = FProject2, Title = "FundingPackage5", Description = "Description5", MinPrice = 30, NumberOfAvailablePackages = 1000, IsActive = true });
            //await _context.FundingPackages.AddAsync(new FundingPackage() { Project = FProject2, Title = "FundingPackage6", Description = "Description6", MinPrice = 80, NumberOfAvailablePackages = 1000, IsActive = true });
            //await _context.FundingPackages.AddAsync(new FundingPackage() { Project = FProject3, Title = "FundingPackage7", Description = "Description7", MinPrice = 15, NumberOfAvailablePackages = 1000, IsActive = true });
            //await _context.FundingPackages.AddAsync(new FundingPackage() { Project = FProject3, Title = "FundingPackage8", Description = "Description8", MinPrice = 150, NumberOfAvailablePackages = 1000, IsActive = true });
            //await _context.FundingPackages.AddAsync(new FundingPackage() { Project = FProject4, Title = "FundingPackage9", Description = "Description9", MinPrice = 25, NumberOfAvailablePackages = 1000, IsActive = true });
            //await _context.FundingPackages.AddAsync(new FundingPackage() { Project = FProject4, Title = "FundingPackage0", Description = "Description0", MinPrice = 500, NumberOfAvailablePackages = 1000, IsActive = true });
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    return new Result<int>(ErrorCode.InternalServerError, "Could not save FundingPackage.");
            //}

            //var User6 = _context.Users.Find(6);
            //var User7 = _context.Users.Find(7);
            //var User8 = _context.Users.Find(8);
            //var User9 = _context.Users.Find(9);

            //var Fpackage1 = _context.FundingPackages.Find(1);
            //var Fpackage2 = _context.FundingPackages.Find(2);
            //var Fpackage3 = _context.FundingPackages.Find(3);
            //var Fpackage4 = _context.FundingPackages.Find(4);
            //var Fpackage5 = _context.FundingPackages.Find(5);
            //var Fpackage6 = _context.FundingPackages.Find(6);
            //var Fpackage7 = _context.FundingPackages.Find(7);

            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User9, FundingPackage = Fpackage1, CreateDate = DateTime.Now, Price = 10, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User9, FundingPackage = Fpackage1, CreateDate = DateTime.Now, Price = 10, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User9, FundingPackage = Fpackage2, CreateDate = DateTime.Now, Price = 20, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User9, FundingPackage = Fpackage2, CreateDate = DateTime.Now, Price = 20, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User8, FundingPackage = Fpackage3, CreateDate = DateTime.Now, Price = 50, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User8, FundingPackage = Fpackage4, CreateDate = DateTime.Now, Price = 10, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User8, FundingPackage = Fpackage5, CreateDate = DateTime.Now, Price = 30, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User7, FundingPackage = Fpackage6, CreateDate = DateTime.Now, Price = 80, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User7, FundingPackage = Fpackage7, CreateDate = DateTime.Now, Price = 15, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User7, FundingPackage = Fpackage4, CreateDate = DateTime.Now, Price = 10, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User6, FundingPackage = Fpackage5, CreateDate = DateTime.Now, Price = 30, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User6, FundingPackage = Fpackage6, CreateDate = DateTime.Now, Price = 80, IsActive = true });
            //await _context.UserFundingPackages.AddAsync(new UserFundingPackage() { User = User6, FundingPackage = Fpackage4, CreateDate = DateTime.Now, Price = 10, IsActive = true });
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}

            //catch (Exception ex)
            //{
            //    return new Result<int>(ErrorCode.InternalServerError, "Could not save UserFundingPackage.");
            //}

            return new Result<int>
            {
                Data = 1
            };
        }
    }
}
