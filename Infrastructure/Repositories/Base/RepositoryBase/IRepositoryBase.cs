using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base.RepositoryBase
{
	public interface IRepositoryBase<T>
	{
		// Queries
		IQueryable<T> FindAll();
		IQueryable<T> FindByCondition(Expression<Func<T , bool>> expression);
		IQueryable<T> FindByConditionAsTracking(Expression<Func<T , bool>> expression);
		Task<T?> GetByIdAsync(string id);

		// CURD 
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
		void AddRange(IEnumerable<T> entities);
		void DeleteRange(IEnumerable<T> entities);
	}
}
