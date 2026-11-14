namespace VehicleClass;

class Walk : Vehicle
{
    private const double DefaultSpeed = 4.5; // km/h

    // constructor for default values
    public Walk() : this(DefaultSpeed)
    {
    }

    // constructor for user values
    public Walk(double avgSpeed) : base("walk", avgSpeed, 0)     // no emissions and free, so it uses Vehicle's default CalculateCO2 and CalculatePrice
    {
    }
}
