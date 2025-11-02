using Infrastructure.Persistence;
using Infrastructure.Repositories.Base.RepositoryBase;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{

		private readonly ApplicationDbContext _context;

		private readonly IHostEnvironment hostEnvironment;

		private readonly IHttpContextAccessor httpContextAccessor;

		public UnitOfWork(ApplicationDbContext dbContext , IHostEnvironment host , IHttpContextAccessor http )
		{
			_context = dbContext;
			hostEnvironment = host;
			httpContextAccessor = http;
		}

		public async Task<int> CompleteAsync(CancellationToken cancellationToken)
		{
			return await _context.SaveChangesAsync(cancellationToken);
		}

		public Task<int> CompleteAsync()
		{
			return _context.SaveChangesAsync();
		}

		public IRepositoryBase<T> Repository<T>() where T : class
		{
			IRepositoryBase<T> repo = new RepositoryBase<T>(_context);
			return repo;
		}
	}
}
