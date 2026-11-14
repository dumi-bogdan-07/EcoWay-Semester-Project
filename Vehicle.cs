namespace VehicleClass;

public abstract class Vehicle{

    protected const double MinSpeed = 1;        // km/h, also prevents dividing by zero
    protected const double MaxSpeed = 200;      // km/h
    protected const double MaxPrice = 500;      // DKK
    protected const double MaxCO2 = 5;          // kg/km

    // public to read, but only set inside the class (encapsulation !!)
    public string Name { get; }
    public double Time { get; private set; }
    public double TotalCO2Emission { get; private set; }
    public double TripPrice { get; private set; }

    // only this class and its subclasses can see these
    protected double AvgSpeed { get; set; }
    protected double CO2Emission { get; set; }

    protected Vehicle(string name, double avgSpeed, double CO2Emission){
        Name = name;
        AvgSpeed = avgSpeed;
        this.CO2Emission = CO2Emission;
    }

    public virtual void GetUserValues()
    {
        // all vehicles share avgSpeed, so it's here
        AvgSpeed = ExceptionHandler.GetDouble($"Enter average {Name} speed (km/h, {MinSpeed}-{MaxSpeed}):", MinSpeed, MaxSpeed);
    }

    // shared things are here, not shared things are in their own vehicle class
    public void Calculate(double km){
        Time = km / AvgSpeed;                  // the same for every vehicle
        TotalCO2Emission = CalculateCO2(km);   // each vehicle can override this
        TripPrice = CalculatePrice(km);        // each vehicle can override this
    }

    // default is no emissions, but Car and Bus override this.
    protected virtual double CalculateCO2(double km){
        return 0;
    }

    // default is free (0) but Car and Bus override this.
    protected virtual double CalculatePrice(double km){
        return 0;
    }
}
