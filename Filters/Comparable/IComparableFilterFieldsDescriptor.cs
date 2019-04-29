using filtersplayground.Filters.Comparable.Equals; 
using filtersplayground.Filters.Comparable.GreaterThan;
using filtersplayground.Filters.Comparable.GreaterThanOrEqual;
using filtersplayground.Filters.Comparable.In;
using filtersplayground.Filters.Comparable.LessThan;
using filtersplayground.Filters.Comparable.LessThanOrEqual; 
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filtersplayground.Filters.ComparableFilter
{
	public interface IComparableFilterFieldsDescriptor
	{
		IComparableFilterFieldsDescriptor AddAll();
		IComparableFilterFieldsDescriptor AddEquals(Action<IComparableFilterEqualsDescriptor> field = null);
		IComparableFilterFieldsDescriptor AddGreaterThan(Action<IComparableFilterGreaterThanDescriptor> field = null);
		IComparableFilterFieldsDescriptor AddGreaterThanOrEquals(Action<IComparableFilterGreaterThanOrEqualDescriptor> field = null);
		IComparableFilterFieldsDescriptor AddLessThan(Action<IComparableFilterLessThanDescriptor> field = null);
		IComparableFilterFieldsDescriptor AddLessThanOrEquals(Action<IComparableFilterLessThanOrEqualDescriptor> field = null);
		IComparableFilterFieldsDescriptor AddIn(Action<IComparableFilterInDescriptor> field = null);

	}
}
