using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base.RepositoryBase
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		public RepositoryBase(ApplicationDbContext db)
		{
			this._context = db;
		}

		public void AddRange(IEnumerable<T> entities)
		{
			_context.Set<T>().AddRange(entities);
		}

		public void Create(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public void DeleteRange(IEnumerable<T> entities)
		{
			_context.Set<T>().RemoveRange(entities);
		}

		public IQueryable<T> FindAll()
		{
			return _context.Set<T>().AsNoTracking().AsQueryable();
		}

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
		{
			return _context.Set<T>().Where(expression).AsNoTracking().AsQueryable();
		}

		public IQueryable<T> FindByConditionAsTracking(Expression<Func<T , bool>> expression)
		{
			return _context.Set<T>().Where(expression).AsQueryable();
		}

		public async Task<T?> GetByIdAsync(string id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);	
		}
	}
}
