using System;
using System.Collections.Generic;
using System.Text;
using filtersplayground;
using filtersplayground.Filters;
using HotChocolate.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using HotChocolate.Utilities;

namespace filtersplayground
{
    public class FilterType<T>
    : InputObjectType<T>
    {
        private readonly Action<IFilterTypeDescriptor<T>> _configure;

        public FilterType()
        {
            _configure = Configure;
			
        }

        public FilterType(Action<IFilterTypeDescriptor<T>> configure)
        {
            _configure = configure
                ?? throw new ArgumentNullException(nameof(configure));
        }

        #region Configuration

        protected override InputObjectTypeDefinition CreateDefinition(
            IInitializationContext context)
        {
            var descriptor =
                FilterTypeDescriptor<T>.New(
                    MyDescriptorContext.Create(context.Services), GetType());
            _configure(descriptor);
            return descriptor.CreateDefinition();
        }

        protected virtual void Configure(
            IFilterTypeDescriptor<T> descriptor)
        {
			

		}
		 

		#endregion
	}
}
