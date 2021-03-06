﻿//
// Copyright(C) 2019-2021, Daniel M. Porrey. All rights reserved.
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program. If not, see http://www.gnu.org/licenses/.
//
using System.Threading.Tasks;
using Diamond.Core.Workflow;
using Microsoft.Extensions.Logging;

namespace Diamond.Core.Example
{
	public class SampleWorkStep4 : WorkflowItem
	{
		public override string Name => $"Sample Step {this.Ordinal}";
		public override string Group { get => WellKnown.Workflow.SampleWorkflow; set => base.Group = value; }
		public override int Ordinal { get => 4; set => base.Ordinal = value; }

		protected override Task<bool> OnExecuteStepAsync(IContext context)
		{
			this.Logger.LogDebug($"Running '{nameof(OnExecuteStepAsync)}' on step [{this.Ordinal}] {this.Group}/{this.Name}.");
			return Task.FromResult(true);
		}

		protected override Task<bool> OnPrepareForExecutionAsync(IContext context)
		{
			this.Logger.LogDebug($"Running '{nameof(OnPrepareForExecutionAsync)}' on step [{this.Ordinal}] {this.Group}/{this.Name}.");
			return Task.FromResult(true);
		}
	}
}
