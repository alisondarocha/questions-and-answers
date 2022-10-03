using Q.A.__social_network.Models;

namespace Q.A.__social_network.Repository
{
    public interface IUserRepository 
    {
        void Register (UserModel user);
        Task <UserModel> GetUser(int id);
        void Delete (UserModel user);
        Task<bool> SaveChangesAsync();
    }
}