using Microsoft.EntityFrameworkCore;
using PersonalWebSite.Business.Interfaces;
using PersonalWebSite.Core.Interfaces;
using PersonalWebSite.Core.Models;

namespace PersonalWebSite.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _unitOfWork.Questions
                .GetAll()
                .Include(q => q.User)
                .Include(q => q.Answers)
                    .ThenInclude(a => a.User)
                .OrderByDescending(q => q.CreatedAt)
                .ToListAsync();
        }

        public async Task<Question?> GetQuestionByIdAsync(int id)
        {
            return await _unitOfWork.Questions
                .GetAll()
                .Include(q => q.User)
                .Include(q => q.Answers)
                    .ThenInclude(a => a.User)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Question> CreateQuestionAsync(Question question)
        {
            question.CreatedAt = DateTime.UtcNow;
            await _unitOfWork.Questions.AddAsync(question);
            await _unitOfWork.SaveChangesAsync();
            return question;
        }

        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            question.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Questions.Update(question);
            await _unitOfWork.SaveChangesAsync();
            return question;
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var question = await _unitOfWork.Questions.GetByIdAsync(id);
            if (question != null)
            {
                _unitOfWork.Questions.Delete(question);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Question>> GetQuestionsByUserIdAsync(string userId)
        {
            return await _unitOfWork.Questions
                .GetAll()
                .Where(q => q.UserId == userId)
                .OrderByDescending(q => q.CreatedAt)
                .ToListAsync();
        }
    }
} 