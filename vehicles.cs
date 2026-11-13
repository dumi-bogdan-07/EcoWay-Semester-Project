namespace VehicleClass;

public abstract class Vehicle{
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
        avgSpeed = RouteInputProcessor.GetDoubleInput($"Enter average {name} speed (km/h):");
    }
    public abstract void CalculateStuff(double km);
}

class Bike : Vehicle{
    private const double DefaultSpeed = 15; // km/h

    // constructor for default values
    public Bike() : this(DefaultSpeed){
    }

    // constructor for user values
    public Bike(double avgSpeed) : base(avgSpeed, 0, 0){
        name = "bike";
        totalCO2Emission = 0;
        tripPrice = 0;
    }
    public override void CalculateStuff(double km){
        time = km/avgSpeed;
    }
}

class Walk : Vehicle{
    private const double DefaultSpeed = 4.5; // km/h

    public Walk() : this(DefaultSpeed){}

    public Walk(double avgSpeed) : base(avgSpeed, 0, 0)
    {
        name = "walk";
        totalCO2Emission = 0;
        tripPrice = 0;
    }
    public override void CalculateStuff(double km)
    {
        time = km/avgSpeed;
    }
}

class Car : Vehicle{
    private const double DefaultSpeed = 40;          // km/h
    private const double DefaultCO2 = 0.15;          // kg/km
    private const double DefaultConsumption = 15.8;  // km/L
    private const double DefaultGasPrice = 18.2;     // DKK/L

    private double averageGasPrice;
    private double averageConsumption;

    public Car() : this(DefaultSpeed, DefaultCO2, DefaultConsumption, DefaultGasPrice) {}

    public Car(double avgSpeed, double CO2Emission, double averageConsumption, double averageGasPrice): 
        base(avgSpeed, CO2Emission, 0){
        name = "car";
        this.averageGasPrice = averageGasPrice;
        this.averageConsumption = averageConsumption;
    }

    public override void GetUserValues()
    {
        base.GetUserValues(); // get speed from base class

        // get everything else needed
        CO2Emission = RouteInputProcessor.GetDoubleInput("Enter car CO2 emission (kg/km):");
        averageConsumption = RouteInputProcessor.GetDoubleInput("Enter car consumption (km/L):");
        averageGasPrice = RouteInputProcessor.GetDoubleInput("Enter gas price (DKK/L):");
    }

    public override void CalculateStuff(double km)
    {
        time = km/avgSpeed;
        totalCO2Emission = km*CO2Emission;
        tripPrice = (km / averageConsumption) * averageGasPrice;
    }
}

class Bus : Vehicle{
    private const double DefaultSpeed = 30;               // km/h
    private const double DefaultCO2 = 1.1;                // kg/km
    private const double DefaultCityPrice = 20.83;        // DKK, average adult/child/Rejsekort ticket within Sonderborg
    private const double DefaultIntercityPrice = 32.67;   // DKK, average intercity ticket, e.g. Graasten-Sonderborg
    private const double CityTripMaxKm = 7;               // max length for city ticket
    private const int PassengersPerBus = 55;              // used to get one person's share of the emissions

    private double cityPrice;
    private double intercityPrice;

    public Bus() : this(DefaultSpeed, DefaultCO2, DefaultCityPrice, DefaultIntercityPrice) {}

    public Bus(double avgSpeed, double CO2Emission, double cityPrice, double intercityPrice)
    : base(avgSpeed, CO2Emission, 0){
        name = "bus";
        this.cityPrice = cityPrice;
        this.intercityPrice = intercityPrice;
    }

    public override void GetUserValues(){
        base.GetUserValues(); // get speed from the base class (again)

        // get everything else needed (again)
        CO2Emission = RouteInputProcessor.GetDoubleInput("Enter bus CO2 emission for the whole bus (kg/km):");
        cityPrice = RouteInputProcessor.GetDoubleInput($"Enter city ticket price, for trips up to {CityTripMaxKm} km (DKK):");
        intercityPrice = RouteInputProcessor.GetDoubleInput($"Enter intercity ticket price, for trips over {CityTripMaxKm} km (DKK):");
    }

    public override void CalculateStuff(double km){
        time = km/avgSpeed;
        totalCO2Emission = (km*CO2Emission)/PassengersPerBus;

        // city ticket for short trips, intercity ticket for longer ones
        if (km <= CityTripMaxKm){
            tripPrice = cityPrice;
        }else{
            tripPrice = intercityPrice;
        }
    }
}
