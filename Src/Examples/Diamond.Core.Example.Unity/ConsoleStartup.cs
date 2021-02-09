﻿using Diamond.Core.Extensions.Hosting;
using Diamond.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnityBuilder = Unity.Microsoft.DependencyInjection.ServiceProviderExtensions;

namespace Diamond.Core.Example
{
	/// <summary>
	/// 
	/// </summary>
	public class ConsoleStartup : IStartupConfigureServices, IStartupConfigureContainer
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="IUnityContainer"></typeparam>
		/// <param name="services"></param>
		/// <returns></returns>
		public void ConfigureContainer<IUnityContainer>(IUnityContainer container)
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public void ConfigureServices(IServiceCollection services)
		{
			// ***
			// *** Add the default dependencies.
			// ***
			services.UseDiamondRepositoryPattern();

			// ***
			// *** Add the entity factory and repository to the container.
			// ***
			services.AddSingleton<IEntityFactory<IInvoice>, InvoiceEntityFactory>();
			services.AddTransient<IRepository<IInvoice>, InvoiceRepository>();

			// ***
			// *** Get the configuration.
			// ***
			IConfiguration configuration = UnityBuilder.BuildServiceProvider(services).GetRequiredService<IConfiguration>();

			services.AddDbContext<ErpContext>(options =>
			{
				options.UseInMemoryDatabase(configuration["ErpDatabase:InMemory"]);
				//options.UseNpgsql(configuration["ErpDatabase:PostgreSQL"]);
				//options.UseSqlite(configuration["ErpDatabase:SQLite"]);
				//options.UseSqlServer(configuration["ErpDatabase:SqlServer"]);
			});

			services.AddHostedService<RepositoryExampleHostedService>();
		}
	}
}
