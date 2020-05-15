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
using Diamond.Patterns.Abstractions;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Diamond.Patterns.Repository.EntityFrameworkCore
{
	public class StorageConfiguration : IStorageConfiguration
	{
		public StorageConfiguration(string connectionString)
		{
			this.ConnectionString = connectionString;
		}

		public string Description { get; set; }
		public string ConnectionString { get; set; }

		protected virtual void OnConfiguring(IDbContextOptionsBuilderInfrastructure optionsBuilder)
		{
		}
	}
}
