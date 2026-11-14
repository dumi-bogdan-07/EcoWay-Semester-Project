namespace VehicleClass;

class Car : Vehicle
{
    private const double DefaultSpeed = 40;          // km/h
    private const double DefaultCO2 = 0.15;          // kg CO2 per km, average of Euro4 and Euro5 cars
    private const double DefaultConsumption = 15.8;  // km/L, average of Euro4/Euro5, gas and diesel engines
    private const double DefaultGasPrice = 18.2;     // DKK/L, rough average of 17.88 (gas) and 19.4 (diesel)
    private const double MinConsumption = 1;         // km/L, also prevents dividing by zero

    private const double MaxConsumption = 100;      // km/L

    private double averageGasPrice;
    private double averageConsumption;

    // constructor for default values
    public Car() : this(DefaultSpeed, DefaultCO2, DefaultConsumption, DefaultGasPrice)
    {
    }

    // constructor for user values
    public Car(double avgSpeed, double CO2Emission, double averageConsumption, double averageGasPrice)
    : base(avgSpeed, CO2Emission, 0)
    {
        name = "car";
        this.averageGasPrice = averageGasPrice;
        this.averageConsumption = averageConsumption;
    }

    public override void GetUserValues()
    {
        base.GetUserValues(); // get speed from base class

        // get everything else needed
        CO2Emission = ExceptionHandler.GetDouble($"Enter car CO2 emission (kg/km 0-{MaxCO2}):", 0, MaxCO2);
        averageConsumption = ExceptionHandler.GetDouble($"Enter car consumption (km/L, at least {MinConsumption}):", MinConsumption, MaxConsumption);
        averageGasPrice = ExceptionHandler.GetDouble("Enter gas price (DKK/L):", 0, MaxPrice);
    }

    public override void CalculateStuff(double km)
    {
        time = km / avgSpeed;
        totalCO2Emission = km * CO2Emission;
        tripPrice = km / averageConsumption * averageGasPrice;
    }
}
