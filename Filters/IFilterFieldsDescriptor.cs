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
	public interface IFilterFieldsDescriptor<T>

	{
		Dictionary<NameString, FilterFieldDescriptor<T>> Filters { get; }

		IDescriptorContext Context { get; }
		IInputObjectTypeDescriptor Descriptor { get; }
		PropertyInfo PropertyInfo
		{
			get;
		}
	}

	public interface IFilterFieldsDescriptor<T, TValue> : IFilterFieldsDescriptor<T>

	{ 
		Expression<Func<T, TValue>> Selector { get; }
	}
}
