using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PundoPH.Model;

namespace PundoPH.Data
{
    public class UserService
    {
        private readonly AppDbContext _appDbContext;

        // Constructor to inject AppDbContext
        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public UserService()
        {
            
        }
        // Method to fetch user details
        public User? GetUser(string userName, string password)
        {
            var user = _appDbContext.Users
                .FirstOrDefault(x =>
                    x.FirstName.Equals(userName) &&
                    x.Password == password); // Adjust based on password hashing if implemented
            // Check token
            //if (!string.IsNullOrEmpty(CheckToken(user)) || CheckToken(user) == "")
            //{
            //    return user = new User();
            //}
            if (user != null)
            {
                UpdateUserToken(user);
            }
            return user;
        }

        public string CheckToken(User user)
        {
            string errorMessage = "";
            if (TokenIsExpired(user.Token))
            {
                return errorMessage = "Token is expired!";
            } else
            {
                UpdateUserToken(user);
            }
            return errorMessage;
        }

        public void UpdateUserToken(User user)
        {
            user.Token = Guid.NewGuid().ToString();
            user.TokenExpirationDate = DateTime.Now;
            _appDbContext.SaveChanges();
        }

        public bool TokenIsExpired(string token)
        {
            var tokenIsExpired = _appDbContext.Users
                .Where(x => x.Token.Equals(token) && x.TokenExpirationDate >= DateTime.UtcNow.AddMinutes(-20))
                .Select(x => x.TokenExpirationDate)
                .FirstOrDefault();
            return tokenIsExpired != null;
        }

        public async Task<string> SaveCreateUser(User user)
        {
            string result = "";
            try 
            {
                _appDbContext.Users.Add(user);
                await _appDbContext.SaveChangesAsync();
                result = "";
            }
            catch(Exception ex)
            {
                result = ex.Message.ToString();
            }

            return result;
        }

        public User? CurrentUser { get; set; }
    }
}
