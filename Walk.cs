namespace VehicleClass;

class Walk : Vehicle
{
    private const double DefaultSpeed = 4.5; // km/h

    // constructor for default values
    public Walk() : this(DefaultSpeed)
    {
    }

    // constructor for user values
    public Walk(double avgSpeed) : base(avgSpeed, 0, 0)
    {
        name = "walk";
        totalCO2Emission = 0;
        tripPrice = 0;
    }
    public override void CalculateStuff(double km)
    {
        time = km / avgSpeed;
    }
}
