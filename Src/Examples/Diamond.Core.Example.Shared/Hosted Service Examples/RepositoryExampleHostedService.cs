﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Diamond.Core.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Diamond.Core.Example
{
	public class RepositoryExampleHostedService : IHostedService
	{
		private readonly ILogger<SpecificationExampleHostedService> _logger = null;
		private readonly IHostApplicationLifetime _appLifetime = null;
		private readonly IConfiguration _configuration = null;
		private readonly IRepositoryFactory _RepositoryFactory = null;

		private int _exitCode = 0;

		public RepositoryExampleHostedService(ILogger<SpecificationExampleHostedService> logger, IHostApplicationLifetime appLifetime, IConfiguration configuration, IRepositoryFactory RepositoryFactory)
		{
			_logger = logger;
			_appLifetime = appLifetime;
			_configuration = configuration;
			_RepositoryFactory = RepositoryFactory;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			_logger.LogInformation("Starting application.");

			// ***
			// *** Get a writable repository for the IInvoce entity.
			// ***
			IWritableRepository<IInvoice> repository = await this._RepositoryFactory.GetWritableAsync<IInvoice>();

			// ***
			// *** Ensure the database is created.
			// ***
			IRepositoryContext db = await repository.GetContextAsync();
			await db.EnsureCreated();

			// ***
			// *** Create 100 new items.
			// ***
			Random rnd = new Random();

			for (int i = 0; i < 100; i++)
			{
				// ***
				// *** Create a new empty model.
				// ***
				IInvoice model = await repository.ModelFactory.CreateAsync();

				// ***
				// *** Assign properties.
				// ***
				model.Total = rnd.Next(10, 10000);
				model.Number = $"INV{rnd.Next(1, 2000000):0000000}";
				model.Description = $"Invoice {i}.";

				// ***
				// *** Add the new item to the database.
				// ***
				(bool result, IInvoice invoice) = await repository.AddAsync(model);

				if (result)
				{
					_logger.LogInformation($"Successfully create invoice with ID = {invoice.Id} [{i}].");
				}
				else
				{
					_logger.LogError($"Failed to create new invoice [{i}].");
				}
			}

			// ***
			// *** Query the database and retrieve all of the invoices.
			// ***
			IEnumerable<IInvoice> items = await repository.GetAllAsync();
			_logger.LogInformation($"There are {items.Count()} invoices in the database.");

			foreach (IInvoice item in items)
			{
				_logger.LogInformation($"[ID = {item.Id}]Invoice Number: {item.Number}, Amount: {item.Total:$#,##0.00}");
			}
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			_logger.LogDebug($"Exiting with return code: {_exitCode}");

			// ***
			// *** Exit code.
			// ***
			Environment.ExitCode = _exitCode;
			return Task.CompletedTask;
		}
	}
}
