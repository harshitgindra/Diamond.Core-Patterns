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
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Diamond.Core.Example
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class ListCommandBase : Command
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger"></param>
		public ListCommandBase(ILogger<ListCommandBase> logger)
			: base("list", "List all invoices in the data storage.")
		{
			this.Logger = logger;

			this.Handler = CommandHandler.Create<string>(async _ =>
			{
				return await this.OnHandleCommand();
			});
		}

		/// <summary>
		/// 
		/// </summary>
		protected ILogger<ListCommandBase> Logger { get; set; } = new NullLogger<ListCommandBase>();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected virtual Task<int> OnHandleCommand()
		{
			return Task.FromResult(0);
		}
	}
}