﻿using Diamond.Core.Specification;
using Microsoft.Extensions.DependencyInjection;

namespace Diamond.Core.Example
{
	public static class SpecificationDependencies
	{
		public static IServiceCollection AddSpecificationExampleDependencies(this IServiceCollection services)
		{
			// ***
			// *** Add the default dependencies.
			// ***
			services.UseDiamondSpecificationPattern();

			// ***
			// *** Add the specification to qualify the widgets.
			// ***
			services.AddTransient<ISpecification, WidgetQualificationSpecification>();

			return services;
		}
	}
}
