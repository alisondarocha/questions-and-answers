using Q.A.__social_network.Models;
using Q.A.__social_network.Repository;

namespace Q.A.__social_network.Commands
{
    public class DeleteQuestionCommand
    {
        private readonly IRepositoryQuestion _repository;
        private QuestionModel _question;
        
        public DeleteQuestionCommand (IRepositoryQuestion repository, QuestionModel question)
        {
            _repository = repository;
            _question = question;
        }
        public void Execute()
        {
            _repository.DeleteQuestion(_question);
        }
        public async Task<bool> Save()
        {
            return await _repository.SaveChangesAsync();
        }
    }
}