using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Options;
using FundRaiser.Team5.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Scenario
{

    public class CreateScenario
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<UserService> _loggerUser;
        private readonly ILogger<ProjectService> _loggerProject;
        private readonly ILogger<StatusUpdateService> _loggerStatusUpdate;
        private readonly ILogger<FundingPackageService> _loggerFundingPackage;
        private readonly ILogger<UserFundingPackageService> _loggerUserFundingPackage;

        public CreateScenario(IApplicationDbContext context)
        {
            _context = context;

            CreateOrUpdateUser(1, new OptionUser() { FirstName = "User1F", LastName = "User1L", Email = "User1@email.com", Password = "User1_1234", IsActive = true });
            CreateOrUpdateUser(2, new OptionUser() { FirstName = "User2F", LastName = "User2L", Email = "User2@email.com", Password = "User2_1234", IsActive = true });
            CreateOrUpdateUser(3, new OptionUser() { FirstName = "User3F", LastName = "User3L", Email = "User3@email.com", Password = "User3_1234", IsActive = true });
            CreateOrUpdateUser(4, new OptionUser() { FirstName = "User5F", LastName = "User5L", Email = "User5@email.com", Password = "User5_1234", IsActive = true });
            CreateOrUpdateUser(5, new OptionUser() { FirstName = "User6F", LastName = "User6L", Email = "User6@email.com", Password = "User6_1234", IsActive = true });
            CreateOrUpdateUser(6, new OptionUser() { FirstName = "User7F", LastName = "User7L", Email = "User7@email.com", Password = "User7_1234", IsActive = true });
            CreateOrUpdateUser(7, new OptionUser() { FirstName = "User4F", LastName = "User4L", Email = "User4@email.com", Password = "User4_1234", IsActive = true });
            CreateOrUpdateUser(8, new OptionUser() { FirstName = "User8F", LastName = "User8L", Email = "User8@email.com", Password = "User8_1234", IsActive = true });
            CreateOrUpdateUser(9, new OptionUser() { FirstName = "User9F", LastName = "User9L", Email = "User9@email.com", Password = "User9_1234", IsActive = true });
            CreateOrUpdateUser(10, new OptionUser() { FirstName = "User0F", LastName = "User0L", Email = "User0@email.com", Password = "User0_1234", IsActive = true });


            CreateOrUpdateProject(1, new OptionProject() { UserId = 1, Title = "Project1", Description = "Description1", CurrentFund = 0, FundingGoal = 100, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            CreateOrUpdateProject(2, new OptionProject() { UserId = 1, Title = "Project2", Description = "Description2", CurrentFund = 0, FundingGoal = 100, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            CreateOrUpdateProject(3, new OptionProject() { UserId = 1, Title = "Project3", Description = "Description3", CurrentFund = 0, FundingGoal = 100, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            CreateOrUpdateProject(4, new OptionProject() { UserId = 1, Title = "Project4", Description = "Description4", CurrentFund = 0, FundingGoal = 100, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            CreateOrUpdateProject(5, new OptionProject() { UserId = 1, Title = "Project5", Description = "Description5", CurrentFund = 0, FundingGoal = 100, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            CreateOrUpdateProject(6, new OptionProject() { UserId = 2, Title = "Project6", Description = "Description6", CurrentFund = 0, FundingGoal = 100, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            CreateOrUpdateProject(7, new OptionProject() { UserId = 2, Title = "Project7", Description = "Description7", CurrentFund = 0, FundingGoal = 100, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            CreateOrUpdateProject(8, new OptionProject() { UserId = 2, Title = "Project8", Description = "Description8", CurrentFund = 0, FundingGoal = 100, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            CreateOrUpdateProject(9, new OptionProject() { UserId = 3, Title = "Project9", Description = "Description9", CurrentFund = 0, FundingGoal = 100, Deadline = DateTime.Now.AddDays(1), IsActive = true });
            CreateOrUpdateProject(10, new OptionProject() { UserId = 3, Title = "Project0", Description = "Description0", CurrentFund = 0, FundingGoal = 100, Deadline = DateTime.Now.AddDays(1), IsActive = true });


            CreateOrUpdateStatusUpdate(1, new OptionStatusUpdate() { ProjectId = 1, Title = "PostStatusUpdate1", Text = "Message1", IsActive = true });
            CreateOrUpdateStatusUpdate(2, new OptionStatusUpdate() { ProjectId = 1, Title = "PostStatusUpdate2", Text = "Message2", IsActive = true });
            CreateOrUpdateStatusUpdate(3, new OptionStatusUpdate() { ProjectId = 1, Title = "PostStatusUpdate3", Text = "Message3", IsActive = true });
            CreateOrUpdateStatusUpdate(4, new OptionStatusUpdate() { ProjectId = 2, Title = "PostStatusUpdate4", Text = "Message4", IsActive = true });
            CreateOrUpdateStatusUpdate(5, new OptionStatusUpdate() { ProjectId = 2, Title = "PostStatusUpdate5", Text = "Message5", IsActive = true });
            CreateOrUpdateStatusUpdate(6, new OptionStatusUpdate() { ProjectId = 2, Title = "PostStatusUpdate6", Text = "Message6", IsActive = true });
            CreateOrUpdateStatusUpdate(7, new OptionStatusUpdate() { ProjectId = 3, Title = "PostStatusUpdate7", Text = "Message7", IsActive = true });
            CreateOrUpdateStatusUpdate(8, new OptionStatusUpdate() { ProjectId = 3, Title = "PostStatusUpdate8", Text = "Message8", IsActive = true });
            CreateOrUpdateStatusUpdate(9, new OptionStatusUpdate() { ProjectId = 4, Title = "PostStatusUpdate9", Text = "Message9", IsActive = true });
            CreateOrUpdateStatusUpdate(10, new OptionStatusUpdate() { ProjectId = 4, Title = "PostStatusUpdate0", Text = "Message0", IsActive = true });

            CreateOrUpdateFundingPackage(1, new OptionFundingPackage() { ProjectId = 1, Title = "FundingPackage1", Description = "Description1", MinPrice = 10, NumberOfAvailablePackages = 1000, IsActive = true });
            CreateOrUpdateFundingPackage(2, new OptionFundingPackage() { ProjectId = 1, Title = "FundingPackage2", Description = "Description2", MinPrice = 20, NumberOfAvailablePackages = 1000, IsActive = true });
            CreateOrUpdateFundingPackage(3, new OptionFundingPackage() { ProjectId = 1, Title = "FundingPackage3", Description = "Description3", MinPrice = 50, NumberOfAvailablePackages = 1000, IsActive = true });
            CreateOrUpdateFundingPackage(4, new OptionFundingPackage() { ProjectId = 2, Title = "FundingPackage4", Description = "Description4", MinPrice = 10, NumberOfAvailablePackages = 1000, IsActive = true });
            CreateOrUpdateFundingPackage(5, new OptionFundingPackage() { ProjectId = 2, Title = "FundingPackage5", Description = "Description5", MinPrice = 30, NumberOfAvailablePackages = 1000, IsActive = true });
            CreateOrUpdateFundingPackage(6, new OptionFundingPackage() { ProjectId = 2, Title = "FundingPackage6", Description = "Description6", MinPrice = 80, NumberOfAvailablePackages = 1000, IsActive = true });
            CreateOrUpdateFundingPackage(7, new OptionFundingPackage() { ProjectId = 3, Title = "FundingPackage7", Description = "Description7", MinPrice = 15, NumberOfAvailablePackages = 1000, IsActive = true });
            CreateOrUpdateFundingPackage(8, new OptionFundingPackage() { ProjectId = 3, Title = "FundingPackage8", Description = "Description8", MinPrice = 150, NumberOfAvailablePackages = 1000, IsActive = true });
            CreateOrUpdateFundingPackage(9, new OptionFundingPackage() { ProjectId = 4, Title = "FundingPackage9", Description = "Description9", MinPrice = 25, NumberOfAvailablePackages = 1000, IsActive = true });
            CreateOrUpdateFundingPackage(10, new OptionFundingPackage() { ProjectId = 4, Title = "FundingPackage0", Description = "Description0", MinPrice = 500, NumberOfAvailablePackages = 1000, IsActive = true });

            CreateOrUpdateUserFundingPackage(1, new OptionUserFundingPackage() { UserId = 9, FundingPackageId = 1, Price = 10, IsActive = true });
            CreateOrUpdateUserFundingPackage(2, new OptionUserFundingPackage() { UserId = 9, FundingPackageId = 1, Price = 10, IsActive = true });
            CreateOrUpdateUserFundingPackage(3, new OptionUserFundingPackage() { UserId = 9, FundingPackageId = 2, Price = 20, IsActive = true });
            CreateOrUpdateUserFundingPackage(4, new OptionUserFundingPackage() { UserId = 9, FundingPackageId = 2, Price = 20, IsActive = true });
            CreateOrUpdateUserFundingPackage(5, new OptionUserFundingPackage() { UserId = 8, FundingPackageId = 3, Price = 50, IsActive = true });
            CreateOrUpdateUserFundingPackage(6, new OptionUserFundingPackage() { UserId = 8, FundingPackageId = 4, Price = 10, IsActive = true });
            CreateOrUpdateUserFundingPackage(7, new OptionUserFundingPackage() { UserId = 8, FundingPackageId = 5, Price = 30, IsActive = true });
            CreateOrUpdateUserFundingPackage(8, new OptionUserFundingPackage() { UserId = 7, FundingPackageId = 6, Price = 80, IsActive = true });
            CreateOrUpdateUserFundingPackage(9, new OptionUserFundingPackage() { UserId = 7, FundingPackageId = 7, Price = 15, IsActive = true });
            CreateOrUpdateUserFundingPackage(10, new OptionUserFundingPackage() { UserId = 7, FundingPackageId = 4, Price = 10, IsActive = true });
            CreateOrUpdateUserFundingPackage(11, new OptionUserFundingPackage() { UserId = 6, FundingPackageId = 5, Price = 30, IsActive = true });
            CreateOrUpdateUserFundingPackage(12, new OptionUserFundingPackage() { UserId = 6, FundingPackageId = 6, Price = 80, IsActive = true });
            CreateOrUpdateUserFundingPackage(13, new OptionUserFundingPackage() { UserId = 6, FundingPackageId = 4, Price = 10, IsActive = true });
        }

        public async void CreateOrUpdateUser(int id, OptionUser optionUser)
        {
            UserService userService = new(_context, _loggerUser);
            if (userService.GetUserByIdAsync(id) != null)
            {
                await userService.UpdateUserAsync(optionUser, id);
            }
            else
            {
                await userService.CreateUserAsync(optionUser);
            }
        }

        public async void CreateOrUpdateProject(int id, OptionProject optionProject)
        {
            ProjectService projectService = new(_context, _loggerProject);
            if (projectService.GetProjectByIdAsync(id) != null)
            {
                await projectService.EditProjectAsync(id, optionProject);
            }
            else
            {
                await projectService.CreateProjectAsync(optionProject);
            }
        }

        public async void CreateOrUpdateStatusUpdate(int id, OptionStatusUpdate optionStatusUpdate)
        {
            StatusUpdateService statusUpdateService = new(_context, _loggerStatusUpdate);
            if (statusUpdateService.GetStatusUpdateByIdAsync(id) != null)
            {
                await statusUpdateService.EditStatusUpdateAsync(id, optionStatusUpdate);
            }
            else
            {
                await statusUpdateService.CreateStatusUpdateAsync(optionStatusUpdate);
            }
        }

        public async void CreateOrUpdateFundingPackage(int id, OptionFundingPackage optionFundingPackage)
        {
            FundingPackageService fundingPackageService = new(_context, _loggerFundingPackage);
            if (fundingPackageService.ReadFundingPackageAsync(id) != null)
            {
                await fundingPackageService.UpdateFundingPackageAsync(id, optionFundingPackage);
            }
            else
            {
                await fundingPackageService.CreateFundingPackageAsync(optionFundingPackage);
            }
        }
        public async void CreateOrUpdateUserFundingPackage(int id, OptionUserFundingPackage optionUserFundingPackage)
        {
            UserFundingPackageService userFundingPackageService = new(_context, _loggerUserFundingPackage);
            if (userFundingPackageService.ReadUserFundingPackageAsync(id) != null)
            {
                await userFundingPackageService.UpdateUserFundingPackageAsync(id, optionUserFundingPackage);
            }
            else
            {
                await userFundingPackageService.CreateUserFundingPackageAsync(optionUserFundingPackage);
            }
        }
    }
}
