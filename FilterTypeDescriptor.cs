using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using filtersplayground.Filters;
using filtersplayground.Filters.ComparableFilter;
using filtersplayground.Filters.Object;
using filtersplayground.Filters.String;
using HotChocolate;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;

namespace filtersplayground
{
    public class FilterTypeDescriptor<T> : InputObjectTypeDescriptor, IFilterTypeDescriptor<T>
    {
		protected List<IFilterFieldsDescriptor<T>> Filters { get; } = new List<IFilterFieldsDescriptor<T>>();
		public FilterTypeDescriptor(IDescriptorContext context) : base(context)
		{ 
		}

		public FilterTypeDescriptor(IDescriptorContext context, Type clrType) : base(context, clrType)
		{
		}

		public new static FilterTypeDescriptor<T> New(
			IDescriptorContext context, Type clrType) =>
			new FilterTypeDescriptor<T>(context, clrType); 

		public IStringFilterFieldsDescriptor Filter(Expression<Func<T, string>> propertyOrMethod)
		{
			var filter = new StringFilterFieldsDescriptor<T>(Context, this, propertyOrMethod);
			Filters.Add(filter);
			return filter; 
		}
		 

		public IComparableFilterFieldsDescriptor Filter<TValue>(Expression<Func<T, TValue>> propertyOrMethod) where TValue : IComparable
		{
			var filter = new ComparableFilterFieldsDescriptor<T, TValue>(Context, this, propertyOrMethod);
			Filters.Add(filter);
			return filter;
		}
		public IObjectFilterFieldsDescriptor Filter<TFilterType, TValue>(Expression<Func<T, TValue>> propertyOrMethod) where TFilterType : IFilterType
		{
			var filter = new ObjectFilterFieldsDescriptor<T, TFilterType, TValue>(Context, this, propertyOrMethod);
			Filters.Add(filter);
			return filter;
		}


		protected override void OnCreateDefinition(InputObjectTypeDefinition definition)
		{ 
			Fields.AddRange(Filters.SelectMany(x => x.Filters.Values));
			base.OnCreateDefinition(definition);
		}

	}
}
