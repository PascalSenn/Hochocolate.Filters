using filtersplayground.Filters.ComparableFilter;
using filtersplayground.Filters.Object;
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

		// I don't know how to unwrap generics 
		IObjectFilterFieldsDescriptor Filter<TFilterType, TValue>(Expression<Func<T, TValue>> propertyOrMethod) where TFilterType : IFilterType;
	}
}
