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
using System;
using System.IO;
using System.Threading.Tasks;
using Diamond.Core.System;
using Microsoft.Extensions.Logging;

#pragma warning disable DF0010

namespace Diamond.Core.WorkFlow
{
	/// <summary>
	/// 
	/// </summary>
	public class DeleteTemporaryFolderStep : WorkFlowItem
	{
		/// <summary>
		/// 
		/// </summary>
		public override string Name => "Delete Temporary Folder";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		protected override Task<bool> OnExecuteStepAsync(IContext context)
		{
			if (context.Properties.ContainsKey(DiamondWorkFlow.WellKnown.Context.TemporaryFolder))
			{
				ITemporaryFolder temporaryFolder = context.Properties.Get<ITemporaryFolder>(DiamondWorkFlow.WellKnown.Context.TemporaryFolder);

				// ***
				// *** Cache the name since the object is being disposed.
				// ***
				string tempPath = temporaryFolder.FullPath;
				this.Logger.LogTrace($"Deleting temporary folder '{tempPath}'.");

				TryDisposable<ITemporaryFolder>.Dispose(temporaryFolder);
				context.Properties.Remove(DiamondWorkFlow.WellKnown.Context.TemporaryFolder);

				if (Directory.Exists(tempPath))
				{
					this.Logger.LogWarning("The temporary folder '{0}' could not be deleted.", tempPath);
				}
				else
				{
					this.Logger.LogTrace("The temporary folder '{0}' was deleted successfully.", tempPath);
				}
			}

			// ***
			// *** Always return true.
			// ***
			return Task.FromResult(true);
		}
	}
}
