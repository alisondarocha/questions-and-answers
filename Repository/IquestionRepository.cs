using Q.A.__social_network.Models;

namespace Q.A.__social_network.Repository
{
    public interface IRepositoryQuestion
    {
        void QuestionPost(QuestionModel question);

        Task<QuestionModel> Get(int id);

        void DeleteQuestion(QuestionModel question);
                
        Task<bool> SaveChangesAsync();
    }
}