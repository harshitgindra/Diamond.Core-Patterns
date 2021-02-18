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
using Diamond.Core.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Diamond.Core.Example
{
	public class ErpContext : RepositoryContext<ErpContext>
	{
		public ErpContext()
			: base()
		{
		}

		public ErpContext(DbContextOptions<ErpContext> options)
			: base(options)
		{
		}

		public ErpContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<InvoiceEntity> Invoices { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//
			// Invoice number must be unique.
			//
			modelBuilder.Entity<InvoiceEntity>().HasIndex(p => p.Number).IsUnique();

			base.OnModelCreating(modelBuilder);
		}
	}
}
