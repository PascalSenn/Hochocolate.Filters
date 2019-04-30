using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.Enumerable.Enumerable
{
	public class EnumerableFilterSomeDescriptor<T, TFilterType> : FilterFieldDescriptor<T>, IEnumerableFilterSomeDescriptor
	{
		
		public EnumerableFilterSomeDescriptor(IDescriptorContext context, PropertyInfo property) : base(context, property)
		{ 
		}

		 
		public override void Configure()
		{  
			Definition.Property = null;
			Definition.Name += "_some";

			/** What do I do here?! resolving a type */
			
			Definition.Type = GetTypeReference(); 

		}

		protected override ITypeReference GetTypeReference()
		{ 
			if(Definition.Type is ClrTypeReference type)
			{  
				return new ClrTypeReference(typeof(TFilterType), type.Context, true, true);

			}
			throw new ArgumentException("Definition has no valid Type");
		}
		 
	}
}
