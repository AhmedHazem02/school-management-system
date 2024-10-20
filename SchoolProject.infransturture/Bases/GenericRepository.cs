using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolProject.infransturture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infransturture.Bases
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _appContext;

        public GenericRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }


        public virtual async Task<T> AddAsync(T entity)
        {
           await _appContext.Set<T>().AddAsync(entity);
           await _appContext.SaveChangesAsync();
           return entity;
          
        }

        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
           await _appContext.Set<T>().AddRangeAsync(entities);
            await _appContext.SaveChangesAsync();
        }

        public void Commit()
        {
           _appContext.Database.CommitTransaction();
        }

        public virtual async Task DeleteAsync(T entity)
        {
             _appContext.Set<T>().Remove(entity);
            await _appContext.SaveChangesAsync();

        }

        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _appContext.Entry(entity).State=EntityState.Deleted;
            }
            await _appContext.SaveChangesAsync();

        }

        public virtual async Task<T> GetByIdAsync(int Id)
        {
            return await _appContext.Set<T>().FindAsync(Id);
        }

        public  IQueryable<T> GetTableAsTracking()
        {
            return _appContext.Set<T>().AsTracking().AsQueryable();
        }

        public IQueryable<T> GetTableNoTracking()
        {
            return _appContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public void Rollback()
        {
            _appContext.Database.RollbackTransaction();
        }

        public  async Task SaveChangesAsync()
        {
            await _appContext.SaveChangesAsync();
        }

        public IDbContextTransaction Transaction()
        {
           return _appContext.Database.BeginTransaction();
        }

        public virtual async Task UpdateAsync(T entity)
        {
             _appContext.Set<T>().Update(entity);
            await _appContext.SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _appContext.Set<T>().UpdateRange(entities);
            await _appContext.SaveChangesAsync();
        }
    }
}
