using UnitConversionApi.Domain.Strategies;

namespace UnitConversionApi.Domain
{
    public record UnitDefinition(
        string Code,
        string Name,
        ConversionCategory Category,
        IConversionStrategy Strategy
        );
}
