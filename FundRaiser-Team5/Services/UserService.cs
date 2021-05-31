using FundRaiser_Team5.Data;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Services
{
    public class UserService : IUserInterface
    {
        private readonly FrDbContext _context;
        private readonly ILogger<UserService> _logger; // out of the box services for not returning null in our crud functions

        public UserService(FrDbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User> CreateUserAsync(OptionUser optionUser)
        {
            // Validations
            if (optionUser == null)
            {
                _logger.LogError("Null options");
                return null;
            }

            if (optionUser.Email == null)
            {
                _logger.LogError("Email must be provided");
                return null;
            }
            
            if (string.IsNullOrWhiteSpace(optionUser.FirstName) ||
                string.IsNullOrWhiteSpace(optionUser.LastName) ||
                string.IsNullOrWhiteSpace(optionUser.Password) ||
                string.IsNullOrWhiteSpace(optionUser.Email)
                )
            {
                _logger.LogError("Not all required parameters passed");
                return null;
            }

            var UserWithTheSameEmail = await _context.Users.SingleOrDefaultAsync(user => user.Email == optionUser.Email); //check the db if there is already user with the same email

            if(UserWithTheSameEmail != null)
            {
                _logger.LogError($"User with email {optionUser.Email} already exists");
                return null;
            }

            var newUser = new User
            {
                FirstName = optionUser.FirstName,
                LastName = optionUser.LastName,
                Email = optionUser.Email,
                Password = optionUser.Password
            };

            await _context.Users.AddAsync(newUser);

            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync(); 
        }


        public async Task<User> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogError("Id cannot be less than or equal to 0");
                return null;
            }
            var userById = await _context.
                Users.
                SingleOrDefaultAsync(user => user.UserId == id);

            if (userById == null)
            {
                _logger.LogError($"User with id {id} not found");

                return null;
            }

            return userById;
        }

        //TODO : Search by criteria
        public Task<User> GetUserAsync(OptionUser options) 
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(OptionUser optionUser, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteUserByIdAsync(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id); //await GetUserByIdAsync(int id);

            if (userToDelete == null)
            {
                _logger.LogError($"User with id {id} not found");

                return -1;
            }

            _context.Users.Remove(userToDelete);

            return await _context.SaveChangesAsync();
        }

        /*********************************************************/

        // CRUD METHODS

        /*private FrDbContext db;

         public UserService()
         {
             db = new();
         }
        */
        private FrDbContext db;
        public UserService(FrDbContext _db)
        {
            db = _db;
        }
        //public User CreateUser(User user)
        //{
        //    /* Validations of the customer:
        //    1) Add email for the creation
        //    2) Do not create user with the same email
        //    3) Passwords need to be strong
        //    */
        //    if (user == null) // You need to make sure that the object is not Null
        //    {
        //        return null;  // It is not good to return null, you need to return an explanation
        //    }

        //    if (user.Email == null) // if User is Null you will get Null pointer exception,                               
        //    {                       // so you need to check if User is Null before that
        //        return null;
        //    }

        //    //using FrDbContext db = new(); // Added a constructor to use the db

        //    db.Users.Add(user);
        //    db.SaveChanges();
        //    return user;
        //}

        public OptionUser CreateUser(OptionUser optionUser)
        {
            if (optionUser == null)
            {
                return null;
            }

            if (optionUser.Email == null)
            {
                return null;
            }

            User user = optionUser.GetUser();

            db.Users.Add(user);
            db.SaveChanges();
            return new OptionUser(user);
        }

        /*
        // Read all users
        public List<User> ReadUser()
        {
           // using FrDbContext db = new();
            return db.Users.ToList();
        }
        */
        public List<OptionUser> ReadUser()
        {
            // using FrDbContext db = new();
            List<User> users = db.Users.ToList();
            List<OptionUser> optionUsers = new List<OptionUser>();

            /*foreach(User user in users)
            {
                optionUsers.Add(new OptionUser(user));
            }*/
            users.ForEach(user => optionUsers.Add(new OptionUser(user)));
            return optionUsers;
        }

        public OptionUser ReadUser(int userId)
        {
            User user = db.Users.Find(userId);
            if (user == null)
            {
                return null;
            }
            return new OptionUser(user);
        }

        public List<OptionUser> ReadUser(OptionUser optionUser)
        {
            // Search by criteria
            List<User> users = db.Users
                //.Where(user => user.Email.Equals(optionUser.Email))
                //.Where(user => user.FirstName.Equals(optionUser.FirstName))
                .Where(user => user.LastName.Equals(optionUser.LastName))
                .ToList();

            List<OptionUser> optionUsers = new List<OptionUser>();

            users.ForEach(user => optionUsers.Add(new OptionUser(user)));
            return optionUsers;
        }

        public OptionUser UpdateUser(int UserId, OptionUser optionUser)
        {
            //using FrDbContext db = new();

            User DbUser = db.Users.Find(UserId);

            if (DbUser == null)
            {
                return null;
            }

            DbUser.Email = optionUser.Email;
            DbUser.Password = optionUser.Password;
            DbUser.FirstName = optionUser.FirstName;
            DbUser.LastName = optionUser.LastName;
            db.SaveChanges();

            return new OptionUser(DbUser);
        }

        public bool DeleteUser(int UserId)
        {
            //using FrDbContext db = new();

            User DbUser = db.Users.Find(UserId);
            if (DbUser == null)
            {
                return false;
            }
            else
            {         
                db.Users.Remove(DbUser);
            }
            return true;
        }
    }
}
