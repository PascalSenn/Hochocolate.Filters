using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.Comparable.In
{
	public class ComparableFilterInDescriptor<T> : FilterFieldDescriptor<T>, IComparableFilterInDescriptor
	{
		
		public ComparableFilterInDescriptor(IDescriptorContext context, PropertyInfo property) : base(context, property)
		{ 
		}

		 
		public override void Configure()
		{  
			Definition.Property = null;
			Definition.Name += "_in";
			Definition.Type = GetTypeReference();

		}

		protected override ITypeReference GetTypeReference()
		{
			var baseType = base.GetTypeReference();
			if(baseType is ClrTypeReference type)
			{ 
				var listType = typeof(IEnumerable<>).MakeGenericType(type.Type);
				return new ClrTypeReference(listType, type.Context, true, true);

			}
			throw new ArgumentException("Definition has no valid Type");
		}
		 
	}
}
