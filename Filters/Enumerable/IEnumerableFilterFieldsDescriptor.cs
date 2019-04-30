using filtersplayground.Filters.Comparable.Equals; 
using filtersplayground.Filters.Comparable.GreaterThan;
using filtersplayground.Filters.Comparable.GreaterThanOrEqual;
using filtersplayground.Filters.Comparable.In;
using filtersplayground.Filters.Comparable.LessThan;
using filtersplayground.Filters.Comparable.LessThanOrEqual;
using filtersplayground.Filters.Enumerable.Enumerable;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filtersplayground.Filters.Enumerable
{
	public interface IEnumerableFilterFieldsDescriptor
	{
		IEnumerableFilterFieldsDescriptor AddAll();
		IEnumerableFilterFieldsDescriptor AddSome(Action<IEnumerableFilterDescriptor> field = null);
		 

	}
}
