using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.Object.Object
{
	public class ObjectFilterDescriptor<T, TFilterType> : FilterFieldDescriptor<T>, IObjectFilterDescriptor where TFilterType: IFilterType
	{
		
		public ObjectFilterDescriptor(IDescriptorContext context, PropertyInfo property) : base(context, property)
		{ 
		}

		 
		public override void Configure()
		{  
			Definition.Property = null; 
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
