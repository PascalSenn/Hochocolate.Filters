using filtersplayground.Filters.ComparableFilter;
using filtersplayground.Filters.String;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace filtersplayground
{
    public interface IFilterTypeDescriptor<T>
	{
		IStringFilterFieldsDescriptor Filter(Expression<Func<T, string>> propertyOrMethod);
		IComparableFilterFieldsDescriptor Filter<TValue>(Expression<Func<T, TValue>> propertyOrMethod) where TValue : IComparable;
	}
}
