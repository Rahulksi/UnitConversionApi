namespace UnitConversionApi.Domain.Strategies
{
    public class FahrenheitStrategy : IConversionStrategy
    {
        public double ConvertToBase(double value) => (value - 32) * 5 / 9;
        public double ConvertFromBase(double value) => (value * 9 / 5) + 32;
    }
}
