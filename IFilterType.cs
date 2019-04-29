using HotChocolate.Types;

namespace filtersplayground
{
	public interface IFilterType : INamedInputType, INamedType, INullableType, IType, ITypeSystem, IHasName, IHasDescription, IInputType, IHasClrType
	{
	}
}