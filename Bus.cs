namespace VehicleClass;

class Bus : Vehicle
{
    // default values
    private const double DefaultSpeed = 30;               // km/h, low because of bus stops
    private const double DefaultCO2 = 1.1;                // kg CO2 per km for the whole bus (Sonderborg buses run on biogas)
    private const double DefaultCityPrice = 20.83;        // DKK, average adult/child/Rejsekort ticket within Sonderborg
    private const double DefaultIntercityPrice = 32.67;   // DKK, average intercity ticket, e.g. Graasten-Sonderborg
    private const double CityTripMaxKm = 7;               // max trip length for a city ticket
    private const int PassengersPerBus = 55;              // used to get one person's share of the emissions

    private double cityPrice;
    private double intercityPrice;

    // constructor for default values
    public Bus() : this(DefaultSpeed, DefaultCO2, DefaultCityPrice, DefaultIntercityPrice)
    {
    }

    // constructor for user values
    public Bus(double avgSpeed, double CO2Emission, double cityPrice, double intercityPrice)
    : base(avgSpeed, CO2Emission, 0)
    {
        name = "bus";
        this.cityPrice = cityPrice;
        this.intercityPrice = intercityPrice;
    }

    public override void GetUserValues()
    {
        base.GetUserValues(); // get speed from base class

        // get everything else needed
        CO2Emission = ExceptionHandler.GetDouble("Enter bus CO2 emission for the whole bus (kg/km):", 0, MaxCO2);
        cityPrice = ExceptionHandler.GetDouble($"Enter city ticket price, for trips up to {CityTripMaxKm} km (DKK):", 0, MaxPrice);
        intercityPrice = ExceptionHandler.GetDouble($"Enter intercity ticket price, for trips over {CityTripMaxKm} km (DKK):", 0, MaxPrice);
    }

    public override void CalculateStuff(double km)
    {
        time = km / avgSpeed;
        totalCO2Emission = km * CO2Emission / PassengersPerBus;

        // city ticket for short trips, intercity ticket for longer ones
        if (km <= CityTripMaxKm)
        {
            tripPrice = cityPrice;
        }
        else
        {
            tripPrice = intercityPrice;
        }
    }
}
