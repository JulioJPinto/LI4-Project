using BlazorLeilart.Models.User;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using BlazorLeilart.Data.Interfaces;

namespace BlazorLeilart.Data.Interfaces.Users
{
    public class UserImp : IUser
    {
        private readonly IDBConnection _dbConnection;

        public UserImp(IDBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task<User> GetUserByEmailAsync(string email)
        {
            string query = "SELECT * FROM [user] WHERE email = @inputEmail";
            return await _dbConnection.Connection.QueryFirstOrDefaultAsync<User>(query, new { inputEmail = email });
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            string query = "SELECT * FROM [user] WHERE id = @inputId";
            return await _dbConnection.Connection.QueryFirstOrDefaultAsync<User>(query, new { inputId = id });
        }

        public async Task<int> ContainsKeyAsync(string email)
        {
            string query = "SELECT COUNT(*) FROM [user] WHERE email = @inputEmail";
            return await _dbConnection.Connection.ExecuteScalarAsync<int>(query, new { inputEmail = email });
        }

        public async Task<bool> PutUserAsync(User user)
        {
            if (await ContainsKeyAsync(user.Email) == 0)
            {
                string email = user.Email;
                string phone = user.Phone;
                string hashed_password = user.Password;
                bool admin = user.Admin;
                string insertQuery = "INSERT INTO [user] (email, phone, password, admin) VALUES (@Email, @Phone, @Password, @Admin)";
                await _dbConnection.Connection.ExecuteAsync(insertQuery, new { Email = email, Phone = phone, Password = hashed_password, Admin = admin });

                return true;
            }

            return false;
        }

        public async Task<bool> RemoveUserByEmailAsync(string email)
        {
            if (await ContainsKeyAsync(email) != 0)
            {
                string query = "DELETE FROM [user] WHERE email = @inputEmail";
                await _dbConnection.Connection.ExecuteAsync(query, new { inputEmail = email });

                return true;
            }

            return false;
        }
        
        public async Task<bool> UpdateUser(User user)
        {
            int existingUserCount = await ContainsKeyAsync(user.Email);
            
            if (existingUserCount > 0)
            {
                // Update the user details in the database
                string updateQuery = "UPDATE [user] SET phone = @Phone, password = @Password WHERE email = @Email";
                await _dbConnection.Connection.ExecuteAsync(updateQuery, new
                {
                    Email = user.Email,
                    Phone = user.Phone,
                    Password = user.Password
                });
            
                return true;
            }

            return false;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return (await _dbConnection.Connection.QueryAsync<User>("SELECT * FROM user")).ToList();
        }
        
    }
}
