using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.Comparable.LessThanOrEqual
{
	public class ComparableFilterLessThanOrEqualDescriptor<T> : FilterFieldDescriptor<T>, IComparableFilterLessThanOrEqualDescriptor
	{
		
		public ComparableFilterLessThanOrEqualDescriptor(IDescriptorContext context, PropertyInfo property) : base(context, property)
		{ 
		}

		 
		public override void Configure()
		{  
			Definition.Property = null;
			Definition.Name += "_lte";
			Definition.Type = GetTypeReference();
		}
		 
	}
}
