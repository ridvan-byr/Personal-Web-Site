using PersonalWebSite.Core.Models;

namespace PersonalWebSite.Business.Interfaces
{
    public interface IAnswerService
    {
        Task<IEnumerable<Answer>> GetAnswersByQuestionIdAsync(int questionId);
        Task<Answer?> GetAnswerByIdAsync(int id);
        Task<Answer> CreateAnswerAsync(Answer answer);
        Task DeleteAnswerAsync(int id);
    }
} 