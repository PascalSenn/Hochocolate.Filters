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
	public abstract class FilterFieldsDescriptor<T, TValue> : IFilterFieldsDescriptor<T, TValue>
	{
		public Dictionary<NameString, FilterFieldDescriptor<T>> Filters { get; } = new Dictionary<NameString, FilterFieldDescriptor<T>>();

		public IDescriptorContext Context {get;}
		public IInputObjectTypeDescriptor Descriptor { get; }
		public PropertyInfo PropertyInfo { get; }
		public Expression<Func<T, TValue>> Selector { get; }

		public FilterFieldsDescriptor(IDescriptorContext context,
			IInputObjectTypeDescriptor descriptor, Expression<Func<T, TValue>> selector)
		{
			this.Context = context;
			this.Descriptor = descriptor;
			this.Selector = selector;
			this.PropertyInfo = GetPropertyInfo(selector);
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
