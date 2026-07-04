namespace UnitConversionApi.Models
{
    public record ConversionResponse(double OriginalValue, string FromUnit, double ConvertedValue, string ToUnit);
}
