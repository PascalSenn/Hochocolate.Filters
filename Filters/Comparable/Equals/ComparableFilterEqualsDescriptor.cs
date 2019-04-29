using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.Comparable.Equals
{
	public class ComparableFilterEqualsDescriptor<T> : FilterFieldDescriptor<T>, IComparableFilterEqualsDescriptor
	{
		
		public ComparableFilterEqualsDescriptor(IDescriptorContext context, PropertyInfo property) : base(context, property)
		{ 
		}


		// for now using configure override to get all properties after initialization
		public override void Configure()
		{  
			Definition.Property = null;
			Definition.Type = GetTypeReference();
		}
		 
	}
}
