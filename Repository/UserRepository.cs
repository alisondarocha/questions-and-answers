using Microsoft.EntityFrameworkCore;
using Q.A.__social_network.Data;
using Q.A.__social_network.Models;

namespace Q.A.__social_network.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Social_NetworkContext _context;

        public UserRepository(Social_NetworkContext context)
        {
            _context = context;
        }
        public void Register(UserModel user)
        {
            _context.Add(user);
        }
        public async Task<UserModel> Get(int id)
        {
            return await _context.Users.Where(iduser => iduser.IdUser == id).FirstOrDefaultAsync();
        }
        public void Delete(UserModel user)
        {
            _context.Remove(user);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}