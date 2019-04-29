using filtersplayground.Filters;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filtersplayground
{
	public class TestQueryType : ObjectType<TestModel>
	{
		protected override void Configure(IObjectTypeDescriptor<TestModel> descriptor)
		{  
			descriptor.Field("foo").Argument("test", x=> x.Type<TestModelFilter>()).Type<StringType>().Resolver((context) => {
				

				return "bar";
				});
		}
	}
}
