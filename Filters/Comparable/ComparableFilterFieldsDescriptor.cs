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
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace filtersplayground.Filters.ComparableFilter
{
	public class ComparableFilterFieldsDescriptor<T, TValue> : FilterFieldsDescriptor<T, TValue>,  IComparableFilterFieldsDescriptor where TValue : IComparable
	{
		public ComparableFilterFieldsDescriptor(IDescriptorContext context, IInputObjectTypeDescriptor descriptor, Expression<Func<T, TValue>> selector) : base(context, descriptor, selector)
		{
		}

		public IComparableFilterFieldsDescriptor AddAll()
		{
			AddEquals();
			AddGreaterThan();
			AddGreaterThanOrEquals();
			AddIn();
			AddLessThan();
			AddLessThanOrEquals();

			return this;
		}


		public IComparableFilterFieldsDescriptor AddEquals(Action<IComparableFilterEqualsDescriptor> field = null)
		{
			var descriptor = new ComparableFilterEqualsDescriptor<T>(context, propertyInfo);
			field?.Invoke(descriptor);
			Filters["equals"] = descriptor;
			return this;
		}

		public IComparableFilterFieldsDescriptor AddGreaterThan(Action<IComparableFilterGreaterThanDescriptor> field = null)
		{
			var descriptor = new ComparableFilterGreaterThanDescriptor<T>(context, propertyInfo);
			field?.Invoke(descriptor);
			Filters["gt"] = descriptor;
			return this;
		}

		public IComparableFilterFieldsDescriptor AddGreaterThanOrEquals(Action<IComparableFilterGreaterThanOrEqualDescriptor> field = null)
		{
			var descriptor = new ComparableFilterGreaterThanOrEqualDescriptor<T>(context, propertyInfo);
			field?.Invoke(descriptor);
			Filters["gte"] = descriptor;
			return this;
		}

		public IComparableFilterFieldsDescriptor AddIn(Action<IComparableFilterInDescriptor> field = null)
		{
			var descriptor = new ComparableFilterInDescriptor<T>(context, propertyInfo);
			field?.Invoke(descriptor);
			Filters["in"] = descriptor;
			return this;
		}

		public IComparableFilterFieldsDescriptor AddLessThan(Action<IComparableFilterLessThanDescriptor> field = null)
		{
			var descriptor = new ComparableFilterLessThanDescriptor<T>(context, propertyInfo);
			field?.Invoke(descriptor);
			Filters["lt"] = descriptor;
			return this;
		}

		public IComparableFilterFieldsDescriptor AddLessThanOrEquals(Action<IComparableFilterLessThanOrEqualDescriptor> field = null)
		{
			var descriptor = new ComparableFilterLessThanOrEqualDescriptor<T>(context, propertyInfo);
			field?.Invoke(descriptor);
			Filters["lte"] = descriptor;
			return this;
		}
	}
}
