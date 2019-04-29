using filtersplayground.Filters.Comparable.Equals;
using filtersplayground.Filters.Comparable.In;
using filtersplayground.Filters.String.Contains; 
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filtersplayground.Filters.String
{
	public interface IStringFilterFieldsDescriptor
	{
		IStringFilterFieldsDescriptor AddAll();
		IStringFilterFieldsDescriptor AddContains(Action<IStringFilterContainsDescriptor> field = null);
		IStringFilterFieldsDescriptor AddEquals(Action<IComparableFilterEqualsDescriptor> field = null);
		IStringFilterFieldsDescriptor AddIn(Action<IComparableFilterInDescriptor> field = null);

	}
}
