using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using filtersplayground.Filters.Comparable.Equals;
using filtersplayground.Filters.Comparable.In;
using filtersplayground.Filters.String.Contains;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.String
{
	public class StringFilterFieldsDescriptor<T> : FilterFieldsDescriptor<T, string>,  IStringFilterFieldsDescriptor
	{
		public StringFilterFieldsDescriptor(IDescriptorContext context, IInputObjectTypeDescriptor descriptor, Expression<Func<T, string>> selector) : base(context, descriptor, selector)
		{
		}

		public IStringFilterFieldsDescriptor AddAll()
		{
			AddIn();
			AddEquals();
			AddContains();
			return this;
		}
		 

		public IStringFilterFieldsDescriptor AddContains(Action<IStringFilterContainsDescriptor> field = null)
		{
			var descriptor = new StringFilterContainsDescriptor<T>(context, propertyInfo);
			field?.Invoke(descriptor);
			Filters["contains"] = descriptor;
			return this;
		}

		public IStringFilterFieldsDescriptor AddEquals(Action<IComparableFilterEqualsDescriptor> field = null)
		{
			var descriptor = new ComparableFilterEqualsDescriptor<T>(context, propertyInfo);
			field?.Invoke(descriptor);
			Filters["equals"] = descriptor;
			return this;
		} 
		 

		public IStringFilterFieldsDescriptor AddIn(Action<IComparableFilterInDescriptor> field = null)
		{
			var descriptor = new ComparableFilterInDescriptor<T>(context, propertyInfo);
			field?.Invoke(descriptor);
			Filters["in"] = descriptor;
			return this;
		}
	}
}
