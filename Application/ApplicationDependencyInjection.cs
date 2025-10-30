using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public static class ApplicationDependencyInjection
	{
		public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMediator();
			return services;
			
		}




		private static void AddMediator(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
		}
	}
}
