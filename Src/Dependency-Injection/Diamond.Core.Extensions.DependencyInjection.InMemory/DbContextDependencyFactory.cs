﻿using System;
using Diamond.Core.Extensions.DependencyInjection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Diamond.Core.Extensions.DependencyInjection.InMemory
{
	/// <summary>
	/// 
	/// </summary>
	public class DbContextDependencyFactory : BaseDbContextDependencyFactory
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="implementationType"></param>
		/// <param name="configuration"></param>
		public DbContextDependencyFactory(Type implementationType, ServiceDescriptorConfiguration configuration)
			: base(implementationType, configuration)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		/// <param name="parameters"></param>
		protected override void OnDbContextOptionsBuilder(DbContextOptionsBuilder builder, object[] parameters)
		{
			builder.UseInMemoryDatabase((string)parameters[0]);
		}
	}
}
