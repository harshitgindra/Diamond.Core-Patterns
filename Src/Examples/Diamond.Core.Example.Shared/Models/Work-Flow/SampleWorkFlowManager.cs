﻿using Diamond.Core.WorkFlow;
using Microsoft.Extensions.Logging;

namespace Diamond.Core.Example
{
	public class SampleWorkFlowManager : LinearWorkFlowManager
	{
		public SampleWorkFlowManager(ILogger<SampleWorkFlowManager> logger, IWorkFlowItemFactory workFlowItemFactory)
			: base(workFlowItemFactory, WellKnown.WorkFlow.SampleWorkFlow)
		{
			logger.LogTrace($"An instance of {nameof(SampleWorkFlowManager)} with group name '{this.Group}' was created.");
		}
	}
}
