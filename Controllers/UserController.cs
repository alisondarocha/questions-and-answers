using Microsoft.AspNetCore.Mvc;
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
            _repository.Register(user);
            return await _repository.SaveChangesAsync()
                    ? Ok("Usuario registrado com sucesso.")
                    : BadRequest("Erro ao registrar usuario.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repository.GetUser(id);
            return user != null
                    ? Ok(user)
                    : NotFound("Esse usuario não foi encontrado ou não existe");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var datauser = await _repository.GetUser(id);
            if (datauser == null) return NotFound("Usuario não foi encontrado ou não existe");

            _repository.Delete(datauser);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuario deletado com sucesso")
                    : NotFound("Erro ao deletar usuario");
        }
    }
}