using Q.A.__social_network.Models;
using Q.A.__social_network.Repository;

namespace Q.A.__social_network.Commands
{
    public class CreateUserCommand : ICommand
    {    
        private readonly IUserRepository _repository;
        private UserModel _user;

        public CreateUserCommand (IUserRepository repository, UserModel user)
        {
            _repository = repository;
            _user = user;
        }
        public void Execute()
        {
            _repository.Register(_user);
        }
        public async Task<bool> Save()
        {
            return await _repository.SaveChangesAsync();
        }
    }
}