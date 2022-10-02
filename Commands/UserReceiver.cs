using Q.A.__social_network.Models;
using Q.A.__social_network.Repository;

namespace Q.A.__social_network.Commands
{
    public class UserReceiver
    {
        private readonly IUserRepository _repository;
        public UserReceiver (IUserRepository repository)
        {
            _repository = repository;
        }
        public void Register(UserModel user)
        {
            _repository.Register(user);
        }
        public void Delete(UserModel user)
        {
            _repository.Delete(user);
        }
        public async Task<bool> Save()
        {
            return await _repository.SaveChangesAsync();
        }
    }
}