namespace UnitConversionApi.Services
{
    public interface IConversionService
    {
        double Convert(string fromUnit, string toUnit, double value);
    }
}
