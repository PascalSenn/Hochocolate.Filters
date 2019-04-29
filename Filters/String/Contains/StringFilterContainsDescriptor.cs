using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.String.Contains
{
	public class StringFilterContainsDescriptor<T> : FilterFieldDescriptor<T>, IStringFilterContainsDescriptor
	{
		public StringFilterContainsDescriptor(IDescriptorContext context, PropertyInfo property) : base(context, property)
		{
		}


		// for now using configure override to get all properties after initialization
		public override void Configure()
		{
			Type<ListType<StringType>>();
			Definition.Name += "_contains";
			Definition.Property = null;
			
		}
		 
	}
}
