using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.Comparable.GreaterThan
{
	public class ComparableFilterGreaterThanDescriptor<T> : FilterFieldDescriptor<T>, IComparableFilterGreaterThanDescriptor
	{
		
		public ComparableFilterGreaterThanDescriptor(IDescriptorContext context, PropertyInfo property) : base(context, property)
		{ 
		}

		 
		public override void Configure()
		{  
			Definition.Property = null;
			Definition.Name += "_gt";
			Definition.Type = GetTypeReference();
		}
		 
	}
}
