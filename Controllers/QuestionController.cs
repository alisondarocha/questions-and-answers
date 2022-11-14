using Microsoft.AspNetCore.Mvc;
using Q.A.__social_network.Commands;
using Q.A.__social_network.Data;
using Q.A.__social_network.DTO;
using Q.A.__social_network.Models;
using Q.A.__social_network.Repository;

namespace Q.A.__social_network.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private readonly IRepositoryQuestion _repository;
        private readonly Social_NetworkContext _context;

        public QuestionController(IRepositoryQuestion repository, Social_NetworkContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateQuestion(CreateQuestionDTO request)
        {   
            var user = await _context.Users.FindAsync(request.IdUser);
            if(user == null) return NotFound("Usuário não existe");

            var question = new QuestionModel
            {
                IdQuestion = request.IdQuestion,
                Question = request.Question,
                User = user
            };

            var createcommand = new CreateQuestionCommand(_repository, question);
            createcommand.Execute();
             
            return await createcommand.Save()      
                    ? Ok("Pergunta postada com sucesso.")
                    : BadRequest("Erro ao postar pergunta.");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetQuestion(int id)
        {
            var question = await _repository.Get(id);
            return question != null
                    ? Ok(question)
                    : NotFound("Pergunta não encontrada");
        }
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteQuestion(int id, int idUser)
        {
            var user = await _context.Users.FindAsync(idUser);
            if (user == null) return NotFound("Usuário não existe");

            var dataquestion = await _repository.Get(id);
            if (dataquestion == null) return NotFound("Pergunta não encontrada");

            var deletecommand = new DeleteQuestionCommand(_repository, dataquestion);
            deletecommand.Execute();

            return await deletecommand.Save()
                    ? Ok("Pergunta deletada com sucesso")
                    : NotFound("Erro ao deletar pergunta");
        }
    }
}