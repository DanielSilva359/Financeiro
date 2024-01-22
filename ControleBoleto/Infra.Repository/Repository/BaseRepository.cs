using Infra.Repository.Context;
using Infra.Repository.Repository.Interfaces;

namespace Infra.Repository.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly FinanceiroContext _context;

        public BaseRepository(FinanceiroContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
