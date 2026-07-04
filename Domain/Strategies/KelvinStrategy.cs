namespace UnitConversionApi.Domain.Strategies
{
    public class KelvinStrategy : IConversionStrategy
    {
        public double ConvertToBase(double value) => value - 273.15;
        public double ConvertFromBase(double value) => value + 273.15;
    }
}
