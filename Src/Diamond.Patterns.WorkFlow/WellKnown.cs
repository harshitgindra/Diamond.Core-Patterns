﻿// ***
// *** Copyright(C) 2019-2020, Daniel M. Porrey. All rights reserved.
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
namespace Diamond.Patterns.WorkFlow
{
	public static class DiamondWorkFlow
	{
		public static class WellKnown
		{
			public static class Context
			{
				public const string LastStepSuccess = "LastStepSuccess";
				public const string WorkFlowError = "WorkFlowError";
				public const string WorkFlowErrorMessage = "WorkFlowErrorMessage";
				public const string WorkFlowFailed = "WorkFlowFailed";
				public const string TemporaryFolder = "TemporaryFolder";
				public const string IStateDictionaryArray = "IStateDictionaryArray";
			}
		}
	}
}
