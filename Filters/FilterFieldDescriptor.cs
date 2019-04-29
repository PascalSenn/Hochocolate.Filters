using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace filtersplayground.Filters
{
	public abstract class FilterFieldDescriptor<T> : InputFieldDescriptor, IFilterFieldDescriptor<T>
	{ 
		private FilterFieldDescriptor(IDescriptorContext context, NameString fieldName) : base(context, fieldName)
		{
			Configure();
		}

		public FilterFieldDescriptor(IDescriptorContext context, PropertyInfo property) : base(context, property)
		{
			Configure();

		}
		// ToDo probably wrong abstraction
		public abstract void Configure();


		protected virtual ITypeReference GetTypeReference()
		{  
			if (Definition.Type is ClrTypeReference type)
			{
				var innerType = type.Type;
				// TODO: This might not work 
				if (type.Type.IsValueType)
				{
					innerType = typeof(Nullable<>).MakeGenericType(type.Type);
				}
				return new ClrTypeReference(innerType, type.Context, true, true);

			}
			throw new ArgumentException("Definition has no valid Type");
		}
	}
}
