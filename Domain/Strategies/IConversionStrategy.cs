namespace UnitConversionApi.Domain.Strategies
{
    public interface IConversionStrategy
    {
        double ConvertToBase(double value);
        double ConvertFromBase(double value);
    }
}
