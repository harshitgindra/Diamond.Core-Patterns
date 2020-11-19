﻿// ***
// *** Copyright(C) 2019-2021, Daniel M. Porrey. All rights reserved.
// *** 
// *** This program is free software: you can redistribute it and/or modify
// *** it under the terms of the GNU Lesser General Public License as published
// *** by the Free Software Foundation, either version 3 of the License, or
// *** (at your option) any later version.
// *** 
// *** This program is distributed in the hope that it will be useful,
// *** but WITHOUT ANY WARRANTY; without even the implied warranty of
// *** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// *** GNU Lesser General Public License for more details.
// *** 
// *** You should have received a copy of the GNU Lesser General Public License
// *** along with this program. If not, see http://www.gnu.org/licenses/.
// *** 
using System.Threading.Tasks;

namespace Diamond.Patterns.Abstractions
{
	/// <summary>
	/// Defines a generic work flow manager.
	/// </summary>
	public interface IWorkFlowManager : ILoggerPublisher
	{
		/// <summary>
		/// The group name used to determine the work flow
		/// items that are part of this work flow.
		/// </summary>
		string Group { get; }
	}

	/// <summary>
	/// Defines a work flow manager that orchestrates the work flow for a
	/// given set of work flow items.
	/// </summary>
	/// <typeparam name="TContextDecorator">The type of context decorator used by the work flow item.</typeparam>
	/// <typeparam name="TContext">The type of context used by  the work flow item.</typeparam>
	public interface IWorkFlowManager<TContextDecorator, TContext> : IWorkFlowManager
		where TContext : IContext
		where TContextDecorator : IContextDecorator<TContext>
	{
		/// <summary>
		/// Gets the work flow items in their execution order.
		/// </summary>
		IWorkFlowItem<TContextDecorator, TContext>[] Steps { get; }

		/// <summary>
		/// Executes the work flow.
		/// </summary>
		/// <param name="context">The current context to be used for this instance of the work flow execution.</param>
		/// <returns>True if the work flow was successful; false otherwise.</returns>
		Task<bool> ExecuteWorkflowAsync(TContextDecorator context);
	}
}