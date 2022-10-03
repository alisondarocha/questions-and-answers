using Q.A.__social_network.Models;
using Q.A.__social_network.Repository;

namespace Q.A.__social_network.Commands
{
    public class DeleteUserCommand : ICommand
    {
        private readonly IUserRepository _repository;
        private UserModel _user;
        
        public DeleteUserCommand (IUserRepository repository, UserModel user)
        {
            _repository = repository;
            _user = user;
        }
        public void Execute()
        {
            _repository.Delete(_user);
        }
        public async Task<bool> Save()
        {
            return await _repository.SaveChangesAsync();
        }
    }
}