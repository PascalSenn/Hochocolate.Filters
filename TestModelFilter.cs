using System;
using System.Collections.Generic;
using System.Text;

namespace filtersplayground
{
    public class TestModelFilter : FilterType<TestModel>
    {
        protected override void Configure(IFilterTypeDescriptor<TestModel> descriptor)
		{
			Name = "TestModelFilter";
			descriptor.Filter(x => x.Test).AddAll();
			descriptor.Filter(x => x.TestInt).AddAll();
			descriptor.Filter<TestModelFilter, TestModel>(x => x.TestModal).AddAll();


		}
	}
}
