using Microsoft.EntityFrameworkCore;
using PersonalWebSite.Business.Interfaces;
using PersonalWebSite.Core.Interfaces;
using PersonalWebSite.Core.Models;

namespace PersonalWebSite.Business.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Answer>> GetAnswersByQuestionIdAsync(int questionId)
        {
            return await _unitOfWork.Answers
                .GetAll()
                .Include(a => a.User)
                .Where(a => a.QuestionId == questionId)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        public async Task<Answer?> GetAnswerByIdAsync(int id)
        {
            return await _unitOfWork.Answers
                .GetAll()
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Answer> CreateAnswerAsync(Answer answer)
        {
            answer.CreatedAt = DateTime.UtcNow;
            await _unitOfWork.Answers.AddAsync(answer);
            await _unitOfWork.SaveChangesAsync();
            return answer;
        }

        public async Task DeleteAnswerAsync(int id)
        {
            var answer = await _unitOfWork.Answers.GetByIdAsync(id);
            if (answer != null)
            {
                _unitOfWork.Answers.Delete(answer);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
} 