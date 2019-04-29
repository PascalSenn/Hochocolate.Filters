using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using filtersplayground.Filters.Comparable.Equals;
using filtersplayground.Filters.Comparable.GreaterThan;
using filtersplayground.Filters.Comparable.GreaterThanOrEqual;
using filtersplayground.Filters.Comparable.In;
using filtersplayground.Filters.Comparable.LessThan;
using filtersplayground.Filters.Comparable.LessThanOrEqual;
using filtersplayground.Filters.Object.Object;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.Object
{
	public class ObjectFilterFieldsDescriptor<T, TFilterType, TValue> : FilterFieldsDescriptor<T, TValue>,  IObjectFilterFieldsDescriptor where TFilterType : IFilterType
	{
		public ObjectFilterFieldsDescriptor(IDescriptorContext context, IInputObjectTypeDescriptor descriptor, Expression<Func<T, TValue>> selector) : base(context, descriptor, selector)
		{
		}

		public IObjectFilterFieldsDescriptor AddAll()
		{
			AddObject(); 

			return this;
		}


		public IObjectFilterFieldsDescriptor AddObject(Action<IObjectFilterDescriptor> field = null)
		{
			var descriptor = new ObjectFilterDescriptor<T, TFilterType>(context, propertyInfo);
			field?.Invoke(descriptor);
			Filters["equals"] = descriptor;
			return this;
		}
		 
	}
}
