using Microsoft.EntityFrameworkCore;
using PersonalWebSite.Core.Interfaces;
using PersonalWebSite.Core.Models;
using PersonalWebSite.Data.Repositories;

namespace PersonalWebSite.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonalWebSiteDbContext _context;
        private IGenericRepository<Question>? _questions;
        private IGenericRepository<Answer>? _answers;

        public UnitOfWork(PersonalWebSiteDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Question> Questions
        {
            get { return _questions ??= new GenericRepository<Question>(_context); }
        }

        public IGenericRepository<Answer> Answers
        {
            get { return _answers ??= new GenericRepository<Answer>(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
} 