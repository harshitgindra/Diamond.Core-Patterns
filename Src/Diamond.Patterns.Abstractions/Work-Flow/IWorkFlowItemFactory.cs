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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diamond.Patterns.Abstractions
{
	/// <summary>
	/// Defines a factory to create/retrieve work flow items.
	/// </summary>
	public interface IWorkFlowItemFactory : ILoggerPublisher
	{
		/// <summary>
		/// gets all work flow items instances with the given key.
		/// </summary>
		/// <typeparam name="TContextDecorator">The type of context decorator used by the work flow item.</typeparam>
		/// <typeparam name="TContext">The type of context used by  the work flow item.</typeparam>
		/// <param name="key">The key that groups two or more work flow items into a single sequence.</param>
		/// <returns>A list of work flow items.</returns>
		Task<IEnumerable<IWorkFlowItem<TContextDecorator, TContext>>> GetItemsAsync<TContextDecorator, TContext>(string key)
			where TContext : IContext
			where TContextDecorator : IContextDecorator<TContext>;
	}
}
