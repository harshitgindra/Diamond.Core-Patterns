﻿using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Diamond.Patterns.Example
{
	class Program
	{
		public static IHostBuilder CreateConsoleBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseConsoleLifetime()
				.ConfigureServices(services => Program.ConfigureServices(services));

		private static void ConfigureServices(IServiceCollection services)
		{
			// ***
			// *** Add the Diamond Patterns dependencies needed for the examples.
			// ***
			services.AddWorkFlowDependencies();
			services.AddSpecificationDependencies();

			// ***
			// *** Add the example application services.
			// ***
			services.AddHostedService<WorkFlowExampleHostedService>();
			services.AddHostedService<SpecificationExampleHostedService>();
		}

		static Task Main(string[] args)
		{
			// ***
			// *** Run as console application
			// ***
			return CreateConsoleBuilder(args).Build().RunAsync();
		}
	}
}
