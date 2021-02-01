﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Diamond.Patterns.Abstractions;
using Diamond.Patterns.Context;
using Diamond.Patterns.WorkFlow;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Diamond.Patterns.Example
{
	public class WorkFlowExampleHostedService : IHostedService
	{
		private readonly ILogger<WorkFlowExampleHostedService> _logger = null;
		private readonly IHostApplicationLifetime _appLifetime = null;
		private readonly IConfiguration _configuration = null;
		private readonly IWorkFlowManagerFactory _workFlowManagerFactory = null;

		private int _exitCode = 0;

		public WorkFlowExampleHostedService(ILogger<WorkFlowExampleHostedService> logger, IHostApplicationLifetime appLifetime, IConfiguration configuration, IWorkFlowManagerFactory workFlowManagerFactory)
		{
			_logger = logger;
			_appLifetime = appLifetime;
			_configuration = configuration;
			_workFlowManagerFactory = workFlowManagerFactory;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			_logger.LogInformation("Starting application.");

			try
			{
				IWorkFlowManager wk1 = await _workFlowManagerFactory.GetAsync("Group1");

				using (GenericContext context = new GenericContext())
				{
					bool result = await wk1.ExecuteWorkflowAsync(context);
				}
			}
			catch
			{

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
