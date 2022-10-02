using Microsoft.AspNetCore.Mvc;
using Q.A.__social_network.Command;
using Q.A.__social_network.Commands;
using Q.A.__social_network.Data;
using Q.A.__social_network.Models;
using Q.A.__social_network.Repository;

namespace Q.A.__social_network.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel user)
        {   
            var receiver = new UserReceiver(_repository);
            var createcommand = new CreateUserCommand(receiver, user);
            createcommand.Execute();

            return await receiver.Save()
                    ? Ok("Usuario registrado com sucesso.")
                    : BadRequest("Erro ao registrar usuario.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = _repository.GetUser(id);
            return await user != null
                    ? Ok(user)
                    : NotFound("Esse usuario não foi encontrado ou não existe");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var datauser = await _repository.GetUser(id);
            if (datauser == null) return NotFound("Usuario não foi encontrado ou não existe");

            var receiver = new UserReceiver(_repository);
            var deletecommand = new DeleteUserCommand(receiver, datauser);
            deletecommand.Execute();

            return await receiver.Save()
                    ? Ok("Usuario deletado com sucesso")
                    : NotFound("Erro ao deletar usuario");
        }
    }
}