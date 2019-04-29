using filtersplayground.Overrides;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace filtersplayground.Filters
{
	public abstract class FilterFieldsDescriptor<T, TValue> : IFilterFieldsDescriptor<T>
	{  
		public Dictionary<NameString, FilterFieldDescriptor<T>> Filters { get; } = new Dictionary<NameString, FilterFieldDescriptor<T>>();

		protected readonly IDescriptorContext context;
		protected readonly IInputObjectTypeDescriptor descriptor;
		protected readonly PropertyInfo propertyInfo;
		protected readonly Expression<Func<T, TValue>> selector;

		public FilterFieldsDescriptor(IDescriptorContext context,
			IInputObjectTypeDescriptor descriptor, Expression<Func<T, TValue>> selector)
		{
			this.context = context;
			this.descriptor = descriptor;
			this.selector = selector;
			this.propertyInfo = GetPropertyInfo(selector);
		}

		private PropertyInfo GetPropertyInfo<TPropertyType>(
			 Expression<Func<T, TPropertyType>> propertyOrMethod)
		{
			if (propertyOrMethod == null)
			{
				throw new ArgumentNullException(nameof(propertyOrMethod));
			}

			MemberInfo member = propertyOrMethod.ExtractMember();
			if (member is PropertyInfo propertyInfo)
			{
				return propertyInfo;
			}

			// TODO : resources
			throw new ArgumentException(
				"A filter has to be a property.",
				nameof(member));
		}
	}
}
