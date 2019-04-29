using HotChocolate.Types.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filtersplayground
{
	internal sealed class MyDescriptorContext
		: IDescriptorContext
	{
		private MyDescriptorContext(
			INamingConventions naming,
			ITypeInspector inspector)
		{
			if (naming == null)
			{
				throw new ArgumentNullException(nameof(naming));
			}

			if (inspector == null)
			{
				throw new ArgumentNullException(nameof(inspector));
			}

			Naming = naming;
			Inspector = inspector;
		}

		public INamingConventions Naming { get; }

		public ITypeInspector Inspector { get; }

		public static MyDescriptorContext Create(IServiceProvider services)
		{
			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			var naming =
				(INamingConventions)services.GetService(
					typeof(INamingConventions));
			if (naming == null)
			{
				naming = new DefaultNamingConventions();
			}

			var inspector =
				(ITypeInspector)services.GetService(
					typeof(ITypeInspector));
			if (inspector == null)
			{
				inspector = new DefaultTypeInspector();
			}

			return new MyDescriptorContext(naming, inspector);
		}
	}
}
