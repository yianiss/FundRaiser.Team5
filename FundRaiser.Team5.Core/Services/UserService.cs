using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _context;

        private readonly ILogger<UserService> _logger; // out of the box services for not returning null in our crud functions

        public UserService(IApplicationDbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<OptionUser>> CreateUserAsync(OptionUser optionUser)
        {
            // Validations
            if (optionUser == null)
            {
                return new Result<OptionUser>(ErrorCode.BadRequest, "Null options.");
            }

            if (optionUser.Email == null)
            {
                return new Result<OptionUser>(ErrorCode.BadRequest, "Email must be provided.");
            }
            
            if (string.IsNullOrWhiteSpace(optionUser.FirstName) ||
                string.IsNullOrWhiteSpace(optionUser.LastName) ||
                string.IsNullOrWhiteSpace(optionUser.Password) ||
                string.IsNullOrWhiteSpace(optionUser.Email)
                )
            {
                return new Result<OptionUser>(ErrorCode.BadRequest, "Not all required customer options provided.");
            }

            var UserWithTheSameEmail = await _context.Users.SingleOrDefaultAsync(user => user.Email == optionUser.Email); //check the db if there is already user with the same email

            if(UserWithTheSameEmail != null)
            {
                return new Result<OptionUser>(ErrorCode.Conflict, $"User with #{optionUser.Email} already exists.");
            }

            var newUser = optionUser.GetUser();

            await _context.Users.AddAsync(newUser);

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<OptionUser>(ErrorCode.InternalServerError, "Could not save user.");
            }

            return new Result<OptionUser>
            {
                Data = new OptionUser(newUser)
            };
        }

        public async Task<Result<List<OptionUser>>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            List<OptionUser> optionUsers = new();

            users.ForEach(user => optionUsers.Add(new OptionUser(user)));

            return new Result<List<OptionUser>>
            {
                Data = users.Count > 0 ? optionUsers : new List<OptionUser>()
            };
        }

        public async Task<Result<OptionUser>> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new Result<OptionUser>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var userById = await _context.
                Users.
                SingleOrDefaultAsync(user => user.UserId == id);

            if (userById == null)
            {
                return new Result<OptionUser>(ErrorCode.NotFound, $"Customer with id #{id} not found.");
            }

            return new Result<OptionUser>
            {
                Data = new OptionUser (userById)
            };
        }

        //TODO : Search by criteria
        public async Task<Result<List<OptionUser>>> GetUsersAsync(OptionUser optionUser) 
        {
            var dbUsers = _context.Users;

            if (!(string.IsNullOrWhiteSpace(optionUser.Email)) &&
                !(string.IsNullOrWhiteSpace(optionUser.Password)))
            {
                dbUsers.
                Where(user => user.Email.Equals(optionUser.Email)).
                Where(user => user.Password.Equals(optionUser.Password));
            }
            else
            {
                return new Result<List<OptionUser>>(ErrorCode.InternalServerError, "Email and Password are Required.");
            }

            List<User> users = await dbUsers.ToListAsync();

            if(users.Count != 1 )
                return new Result<List<OptionUser>>(ErrorCode.InternalServerError, "Fatal Error.");

            List<OptionUser> optionUsers = new();

            users.ForEach(user => optionUsers.Add(new OptionUser(user)));

            return new Result<List<OptionUser>>
            {
                Data = optionUsers
            };
        }

        //TODO : Implement the Update Action
        public async Task<Result<OptionUser>> UpdateUserAsync(OptionUser optionUser, int id)
        {
            if (id <= 0)
            {
                return new Result<OptionUser>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            User dbUser = await _context.Users.SingleOrDefaultAsync(user => user.UserId == id);
            
            if (dbUser == null)
            {
                return new Result<OptionUser>(ErrorCode.NotFound, $"User with id #{id} not found.");
            }

            dbUser.FirstName = optionUser.FirstName;

            dbUser.LastName = optionUser.LastName;

            dbUser.Email = optionUser.Email;

            if(dbUser.Email == optionUser.Email)
            {

            }

            dbUser.Password = optionUser.Password;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Result<OptionUser>(ErrorCode.InternalServerError, "Could not save FundingPackage.");
            }

             return new Result<OptionUser>
             {
                 Data = new OptionUser(dbUser)
             };
        }

        public async Task<Result<int>> DeleteUserByIdAsync(int id)
        {
            var userToDelete = /*await _context.Users.FindAsync(id);*/ await GetUserByIdAsync(id);

            if (userToDelete.Error != null || userToDelete.Data == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"User with id #{id} not found.");
            }

            userToDelete.Data.IsActive = false;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<int>(ErrorCode.InternalServerError, "Could not delete user.");
            }

            return new Result<int>
            {
                Data = id
            };
        }
    }
}
