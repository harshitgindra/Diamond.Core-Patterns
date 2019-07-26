﻿using System;
using System.Data.Entity;
using Diamond.Patterns.Abstractions;

namespace Diamond.Patterns.DatabaseStrategy.MsSql
{
	public class MsSqlDropCreateDatabaseIfModelChangesStrategy<TContext> : IDatabaseStrategy<TContext> where TContext : DbContext
	{
		public object GetInitializer(object modelBuilder, EventHandler<TContext> onSeed)
		{
			object returnValue = null;

			if (modelBuilder is DbModelBuilder dbModelBuilder)
			{
				returnValue = new MsSqlDropCreateDatabaseIfModelChanges<TContext>(onSeed);
			}

			return returnValue;
		}
	}
}