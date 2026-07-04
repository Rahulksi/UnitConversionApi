# Unit Conversion API

A scalable, clean-architecture ASP.NET Core Web API built to manage and process multiple units of measurement conversions seamlessly.

## Features
- **Extensible Registry Design**: Built with the Strategy Pattern to easily handle hundreds of units.
- **Cross-Category Guardrails**: Prevents illegal domain operations (e.g., converting Meters to Fahrenheit).
- **Auto-Documentation**: Includes fully configured Swagger/OpenAPI support out of the box.

## Requirements
- .NET 8.0 SDK (or latest stable version)

## How to Run Locally

### 1. Using the .NET CLI
1. Open your terminal in the root project directory (`UnitConversionApi/`).
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Run the application:
   ```bash
   dotnet run
   ```
4. Look for the application URLs in the console output (usually `https://localhost:7001` or `http://localhost:5000`).

### 2. Accessing API Documentation
Once the app is running in the `Development` environment, open your browser and navigate to:
```text
https://localhost:7161/swagger/index.html
```

## API Usage Example

### POST `/api/conversion/convert`

**Payload:**
```json
{
  "value": 100,
  "fromUnit": "m",
  "toUnit": "ft"
}
```

**Response (200 OK):**
```json
{
  "originalValue": 100,
  "fromUnit": "m",
  "convertedValue": 328.0839895013123,
  "toUnit": "ft"
}
```
