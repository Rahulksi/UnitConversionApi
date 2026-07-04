using System.Collections.Concurrent;
using UnitConversionApi.Domain.Strategies;
using UnitConversionApi.Domain;

namespace UnitConversionApi.Services
{
    public class ConversionService : IConversionService
    {
        private readonly ConcurrentDictionary<string, UnitDefinition> _registry = new(StringComparer.OrdinalIgnoreCase);

        public ConversionService()
        {
            InitializeDefaultUnits();
        }

        private void InitializeDefaultUnits()
        {
            // Length (Base: Meter)
            Register(new UnitDefinition("m", "Meter", ConversionCategory.Length, new LinearStrategy(1.0)));
            Register(new UnitDefinition("ft", "Feet", ConversionCategory.Length, new LinearStrategy(0.3048)));
            Register(new UnitDefinition("in", "Inch", ConversionCategory.Length, new LinearStrategy(0.0254)));
            Register(new UnitDefinition("yd", "Yard", ConversionCategory.Length, new LinearStrategy(0.9144)));
            Register(new UnitDefinition("mi", "Mile", ConversionCategory.Length, new LinearStrategy(1609.344)));
            Register(new UnitDefinition("cm", "Centimeter", ConversionCategory.Length, new LinearStrategy(0.01)));
            Register(new UnitDefinition("mm", "Millimeter", ConversionCategory.Length, new LinearStrategy(0.001)));
            Register(new UnitDefinition("km", "Kilometer", ConversionCategory.Length, new LinearStrategy(1000.0)));

            // Mass (Base: Kilogram)
            Register(new UnitDefinition("kg", "Kilogram", ConversionCategory.Mass, new LinearStrategy(1.0)));
            Register(new UnitDefinition("lb", "Pound", ConversionCategory.Mass, new LinearStrategy(0.45359237)));
            Register(new UnitDefinition("g", "Gram", ConversionCategory.Mass, new LinearStrategy(0.001)));
            Register(new UnitDefinition("mg", "Milligram", ConversionCategory.Mass, new LinearStrategy(0.000001)));
            Register(new UnitDefinition("t", "Metric Ton", ConversionCategory.Mass, new LinearStrategy(1000.0)));
            Register(new UnitDefinition("lb", "Pound", ConversionCategory.Mass, new LinearStrategy(0.45359237)));
            Register(new UnitDefinition("oz", "Ounce", ConversionCategory.Mass, new LinearStrategy(0.028349523125)));
            Register(new UnitDefinition("st", "Stone", ConversionCategory.Mass, new LinearStrategy(6.35029318)));

            // Temperature (Base: Celsius)
            Register(new UnitDefinition("c", "Celsius", ConversionCategory.Temperature, new CelsiusStrategy()));
            Register(new UnitDefinition("f", "Fahrenheit", ConversionCategory.Temperature, new FahrenheitStrategy()));
            Register(new UnitDefinition("k", "Kelvin", ConversionCategory.Temperature, new KelvinStrategy()));
        }

        private void Register(UnitDefinition unit) => _registry[unit.Code] = unit;

        public double Convert(string fromUnit, string toUnit, double value)
        {
            if (!_registry.TryGetValue(fromUnit, out var from) || !_registry.TryGetValue(toUnit, out var to))
                throw new KeyNotFoundException("One or both unit codes are unsupported.");

            if (from.Category != to.Category)
                throw new InvalidOperationException($"Cannot convert between different categories: {from.Category} and {to.Category}.");

            // Strategy workflow: Source Unit -> Base Unit -> Target Unit
            double baseValue = from.Strategy.ConvertToBase(value);
            return to.Strategy.ConvertFromBase(baseValue);
        }
    }
}
