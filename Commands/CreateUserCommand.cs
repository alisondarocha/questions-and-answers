using Q.A.__social_network.Commands;
using Q.A.__social_network.Models;

namespace Q.A.__social_network.Command
{
    //ConcreteCommand
    public class CreateUserCommand : ICommand
    {    
        private readonly UserReceiver _repository;
        private UserModel _user;
        public CreateUserCommand (UserReceiver repository, UserModel user)
        {
            _repository = repository;
            _user = user;
        }
        public void Execute()
        {
            _repository.Register(_user);
        }
    }
}