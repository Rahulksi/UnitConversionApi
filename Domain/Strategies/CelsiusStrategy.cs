namespace UnitConversionApi.Domain.Strategies
{
    public class CelsiusStrategy : IConversionStrategy
    {
        public double ConvertToBase(double value) => value;
        public double ConvertFromBase(double value) => value;
    }
}
