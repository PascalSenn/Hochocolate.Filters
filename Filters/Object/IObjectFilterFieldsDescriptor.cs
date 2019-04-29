using filtersplayground.Filters.Comparable.Equals; 
using filtersplayground.Filters.Comparable.GreaterThan;
using filtersplayground.Filters.Comparable.GreaterThanOrEqual;
using filtersplayground.Filters.Comparable.In;
using filtersplayground.Filters.Comparable.LessThan;
using filtersplayground.Filters.Comparable.LessThanOrEqual;
using filtersplayground.Filters.Object.Object;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filtersplayground.Filters.Object
{
	public interface IObjectFilterFieldsDescriptor
	{
		IObjectFilterFieldsDescriptor AddAll();
		IObjectFilterFieldsDescriptor AddObject(Action<IObjectFilterDescriptor> field = null);
		 

	}
}
