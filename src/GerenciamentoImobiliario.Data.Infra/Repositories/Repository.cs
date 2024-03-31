using GerenciamentoImobiliario.Data.Infra.DataContext;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
using GerenciamentoImobiliario.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoImobiliario.Data.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity 
    {
        private readonly GerenciamentoImobiliarioDataContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(GerenciamentoImobiliarioDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();    
        }
        public async Task Create(T entity)
        {
            var _dbSet = _context.Set<T>();
            entity.CriadoEm = DateTime.Now;
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            _dbSet.Remove(entity!);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GellAll()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<T> GetById(Guid id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }

        public async Task<T> Update(T entity)
        {
            entity.AtualizadoEm = DateTime.Now;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
