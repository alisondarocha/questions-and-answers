using Q.A.__social_network.Models;

namespace Q.A.__social_network.Commands
{
    public class DeleteUserCommand
    {
        private readonly UserReceiver _repository;
        private UserModel _user;
        public DeleteUserCommand (UserReceiver repository, UserModel user)
        {
            _repository = repository;
            _user = user;
        }
        public void Execute()
        {
            _repository.Delete(_user);
        }
    }
}