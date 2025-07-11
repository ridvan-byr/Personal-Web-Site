using PersonalWebSite.Core.Models;

namespace PersonalWebSite.Business.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question?> GetQuestionByIdAsync(int id);
        Task<Question> CreateQuestionAsync(Question question);
        Task<Question> UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(int id);
        Task<IEnumerable<Question>> GetQuestionsByUserIdAsync(string userId);
    }
} 