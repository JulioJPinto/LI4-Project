using BlazorLeilart.Models.User;
using System.Data;
using System.Data.SqlClient;

namespace BlazorLeilart.Data.Interfaces;

public interface IUser
{
    Task<User> GetUserByEmailAsync(string email);

    Task<User> GetUserByIdAsync(string id);

    Task<int> ContainsKeyAsync(string email);

    Task<bool> PutUserAsync(User user);

    Task<bool> RemoveUserByEmailAsync(string email);
    
    Task<bool> UpdateUser(User user);

    Task<List<User>> GetAllUsersAsync();

    Task<bool> IsAdmin(string user);
    
    Task<bool> MakeAdmin(User u);

    Task<bool> RemoveAdmin(User u);
}