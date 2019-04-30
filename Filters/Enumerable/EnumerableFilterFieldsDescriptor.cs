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
using filtersplayground.Filters.Enumerable.Enumerable;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.Enumerable
{
	public class EnumerableFilterFieldsDescriptor<T, TValue> : FilterFieldsDescriptor<T, TValue>,  IEnumerableFilterFieldsDescriptor 
	{
		public EnumerableFilterFieldsDescriptor(IFilterFieldsDescriptor<T, TValue> descriptor ) : base(descriptor.Context, descriptor.Descriptor, descriptor.Selector)
		{
		}

		public IEnumerableFilterFieldsDescriptor AddAll()
		{
			AddSome(); 

			return this;
		}


		public IEnumerableFilterFieldsDescriptor AddSome(Action<IEnumerableFilterDescriptor> field = null)
		{
			var descriptor = new EnumerableFilterDescriptor<T, TFilterType>(context, propertyInfo);
			field?.Invoke(descriptor);
			Filters["equals"] = descriptor;
			return this;
		}
		 
	}
}
