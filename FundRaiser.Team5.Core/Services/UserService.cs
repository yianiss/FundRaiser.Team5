using FundRaiser_Team5.Entities;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Model;
using FundRaiser_Team5.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Services
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

        public async Task<Result<User>> CreateUserAsync(OptionUser optionUser)
        {
            // Validations
            if (optionUser == null)
            {
                return new Result<User>(ErrorCode.BadRequest, "Null options.");
            }

            if (optionUser.Email == null)
            {
                return new Result<User>(ErrorCode.BadRequest, "Email must be provided.");
            }
            
            if (string.IsNullOrWhiteSpace(optionUser.FirstName) ||
                string.IsNullOrWhiteSpace(optionUser.LastName) ||
                string.IsNullOrWhiteSpace(optionUser.Password) ||
                string.IsNullOrWhiteSpace(optionUser.Email)
                )
            {
                return new Result<User>(ErrorCode.BadRequest, "Not all required customer options provided.");
            }

            var UserWithTheSameEmail = await _context.Users.SingleOrDefaultAsync(user => user.Email == optionUser.Email); //check the db if there is already user with the same email

            if(UserWithTheSameEmail != null)
            {
                return new Result<User>(ErrorCode.Conflict, $"User with #{optionUser.Email} already exists.");
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

                return new Result<User>(ErrorCode.InternalServerError, "Could not save user.");
            }

            return new Result<User>
            {
                Data = newUser
            };
        }

        public async Task<Result<List<User>>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return new Result<List<User>>
            {
                Data = users.Count > 0 ? users : new List<User>()
            };
        }

        public async Task<Result<User>> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new Result<User>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var userById = await _context.
                Users.
                SingleOrDefaultAsync(user => user.UserId == id);

            if (userById == null)
            {
                return new Result<User>(ErrorCode.NotFound, $"Customer with id #{id} not found.");
            }

            return new Result<User>
            {
                Data = userById
            };
        }

        //TODO : Search by criteria
        public async Task<Result<User>> GetUserAsync(OptionUser optionUser) 
        {
            // Search by criteria
            List<User> users = _context.Users
                //.Where(user => user.Email.Equals(optionUser.Email))
                //.Where(user => user.FirstName.Equals(optionUser.FirstName))
                .Where(user => user.LastName.Equals(optionUser.LastName))
                .ToList();

            List<OptionUser> optionUsers = new List<OptionUser>();

            users.ForEach(user => optionUsers.Add(new OptionUser(user)));
            return optionUsers;
        }

        //TODO : Implement the Update Action
        public async Task<Result<User>> UpdateUserAsync(OptionUser optionUser, int id)
        {
            var userToUpdate = await GetUserByIdAsync(id);

            if (userToUpdate.Error != null || userToUpdate.Data == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"User with id #{id} not found.");
            }

            userToUpdate.FirstName = optionUser.FirstName;
            userToUpdate.LastName = optionUser.LastName;
            userToUpdate.Email = optionUser.Email;
            userToUpdate.Password = optionUser.Password;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<int>(ErrorCode.Conflict, "Could not update user.");
            }

            return new Result<int>
            {
                Data = id
            };
        }

        public async Task<Result<int>> DeleteUserByIdAsync(int id)
        {
            var userToDelete = /*await _context.Users.FindAsync(id);*/ await GetUserByIdAsync(id);

            if (userToDelete.Error != null || userToDelete.Data == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"User with id #{id} not found.");
            }
        
            _context.Users.Remove(userToDelete);

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
