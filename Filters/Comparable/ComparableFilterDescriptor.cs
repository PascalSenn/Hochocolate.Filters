using HotChocolate.Types.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace filtersplayground.Filters.ComparableFilter
{
	public abstract class ComparableFilterDescriptor<T, TValue> : FilterFieldDescriptor<T> where TValue : IComparable
	{

		public ComparableFilterDescriptor(IDescriptorContext context, PropertyInfo property) : base(context, property)
		{
		}

	}
}
