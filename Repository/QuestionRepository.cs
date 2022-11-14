using Microsoft.EntityFrameworkCore;
using Q.A.__social_network.Data;
using Q.A.__social_network.Models;

namespace Q.A.__social_network.Repository
{
    public class QuestionRepository : IRepositoryQuestion
    {
        private readonly Social_NetworkContext _context;

        public QuestionRepository(Social_NetworkContext context)
        {
            _context = context;
        }
        public void QuestionPost(QuestionModel question)
        {
            _context.Add(question);
        }
        public async Task<QuestionModel> Get(int id)
        {
            return await _context.Questions.Where(idquestion => idquestion.IdQuestion == id).FirstOrDefaultAsync();
        }
        public void DeleteQuestion(QuestionModel question)
        {
            _context.Remove(question);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}