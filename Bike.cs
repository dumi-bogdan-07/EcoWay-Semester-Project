namespace VehicleClass;

class Bike : Vehicle
{
    private const double DefaultSpeed = 15; // km/h

    // constructor for default values
    public Bike() : this(DefaultSpeed)
    {
    }

    // constructor for user values
    public Bike(double avgSpeed) : base(avgSpeed, 0, 0)
    {
        name = "bike";
        totalCO2Emission = 0;
        tripPrice = 0;
    }
    public override void CalculateStuff(double km)
    {
        time = km / avgSpeed;
    }
}
