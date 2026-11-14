namespace VehicleClass;

class Bike : Vehicle
{
    private const double DefaultSpeed = 15; // km/h

    // constructor for default values
    public Bike() : this(DefaultSpeed)
    {
    }

    // constructor for user values
    public Bike(double avgSpeed) : base("bike", avgSpeed, 0)     // no emissions and free, so it uses Vehicle's default CalculateCO2 and CalculatePrice
    {
    }
}
