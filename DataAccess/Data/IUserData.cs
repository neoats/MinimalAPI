using DataAccessLayer.Models;

namespace DataAccessLayer.Data;

public interface IUserData
{
    Task<IEnumerable<UserModel>> GetUsers();
    Task<UserModel?> GetUser(int id);
    Task InsertUser(UserModel user);
    Task UpdateUser(UserModel user);
    Task Delete(int id);
}