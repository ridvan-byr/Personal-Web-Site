using PersonalWebSite.Core.Models;

namespace PersonalWebSite.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Question> Questions { get; }
        IGenericRepository<Answer> Answers { get; }
        Task<int> SaveChangesAsync();
    }
} 