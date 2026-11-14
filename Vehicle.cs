namespace VehicleClass;

public abstract class Vehicle{
    protected const double MinSpeed = 1;    // km/h, also prevents dividing by zero
    protected const double MaxSpeed = 200;  // km/h, anything above this is a typo
    protected const double MaxPrice = 500; 
    protected const double MaxCO2 = 5;

    public string? name;
    protected double avgSpeed { get; set; }
    public double time { get; set; }
    public double totalCO2Emission { get; set; }
    public double tripPrice { get; set; }
    protected double CO2Emission { get; set; }

    protected Vehicle(double avgSpeed, double CO2Emission, double tripPrice){
        this.avgSpeed = avgSpeed;
        this.CO2Emission = CO2Emission;
        this.tripPrice = tripPrice;
    }

    public virtual void GetUserValues()
    {
        // all vehicles share avgSpeed, so it's here
        avgSpeed = ExceptionHandler.GetDouble($"Enter average {name} speed (km/h, {MinSpeed}-{MaxSpeed}):", MinSpeed, MaxSpeed);
    }
    public abstract void CalculateStuff(double km);
}
