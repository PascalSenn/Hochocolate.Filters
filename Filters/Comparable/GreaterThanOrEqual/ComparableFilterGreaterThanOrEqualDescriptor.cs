using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.Comparable.GreaterThanOrEqual
{
	public class ComparableFilterGreaterThanOrEqualDescriptor<T> : FilterFieldDescriptor<T>, IComparableFilterGreaterThanOrEqualDescriptor
	{
		
		public ComparableFilterGreaterThanOrEqualDescriptor(IDescriptorContext context, PropertyInfo property) : base(context, property)
		{ 
		}

		 
		public override void Configure()
		{  
			Definition.Property = null;
			Definition.Name += "_gte";
			Definition.Type = GetTypeReference();
		}
		 
	}
}
