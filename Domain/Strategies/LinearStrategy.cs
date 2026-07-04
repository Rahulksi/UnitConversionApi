namespace UnitConversionApi.Domain.Strategies
{
    public class LinearStrategy : IConversionStrategy
    {
        private readonly double _factorToBase;
        public LinearStrategy(double factorToBase) => _factorToBase = factorToBase;

        public double ConvertToBase(double value) => value * _factorToBase;
        public double ConvertFromBase(double value) => value / _factorToBase;
    }
}
