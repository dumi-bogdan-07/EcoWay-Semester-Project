using System.IO;
using System.Text.Json;

namespace FirstSemesterProject.Data_Layer;

// Mirrors the "Car"
public class CarDefaults
{
    public double AvgSpeed { get; set; }
    public double CO2Emission { get; set; }
    public double AverageGasPrice { get; set; }
    public double AverageConsumption { get; set; }
}

// Mirrors the "Bus" object;
public class BusDefaults
{
    public double AvgSpeed { get; set; }
    public double CO2Emission { get; set; }
    public double CityPrice { get; set; }
    public double IntercityPrice { get; set; }
}

// Mirrors the "Bike" object;
public class BikeDefaults
{
    public double AvgSpeed { get; set; }
    public double TotalCO2Emission { get; set; }
    public double TripPrice { get; set; }
}

// Mirrors the "Walk" object;
public class WalkDefaults
{
    public double AvgSpeed { get; set; }
    public double CO2Emission { get; set; }
    public double TripPrice { get; set; }
}

// Mirrors the top level of DefaultValues.json (one entry per transport mode); Load() reads the file
// from the app's output folder and deserializes it, falling back to empty defaults if the JSON is empty.
// This took me ages to figure out.
public class DefaultValues
{
    public CarDefaults Car { get; set; } = new();
    public BusDefaults Bus { get; set; } = new();
    public BikeDefaults Bike { get; set; } = new();
    public WalkDefaults Walk { get; set; } = new();

    public static DefaultValues Load()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "DefaultValues.json");
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<DefaultValues>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
    }
}