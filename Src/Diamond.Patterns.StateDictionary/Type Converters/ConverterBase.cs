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
using System;
using Diamond.Patterns.Abstractions;

namespace Diamond.Patterns.StateDictionary
{
	public class ConverterBase<TTargetType> : IStateTypeConverter
	{
		public Type TargetType => typeof(TTargetType);

		protected string SourceStringValue { get; set; }
		protected object SourceObjectValue { get; set; }

		public Type SpecificTargetType { get; set; }

		public virtual (bool, string, object) ConvertSource(object sourceValue, Type specificTargetType)
		{
			this.SourceObjectValue = sourceValue;
			this.SourceStringValue = Convert.ToString(sourceValue);
			this.SpecificTargetType = specificTargetType;
			return this.OnConvertSource();
		}

		protected virtual (bool, string, object) OnConvertSource()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return this.TargetType.Name;
		}
	}
}
