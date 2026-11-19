namespace VehicleClass;
using FirstSemesterProject.Graphical_User_Interface;

class Bus : Vehicle
{
    // default values
    private const double DefaultSpeed = 30;               // km/h, low because of bus stops
    private const double DefaultCO2 = 1.1;                // kg CO2 per km for the whole bus (Sonderborg buses run on biogas)
    private const double DefaultCityPrice = 20.83;        // DKK, average adult/child/Rejsekort ticket within Sonderborg
    private const double DefaultIntercityPrice = 32.67;   // DKK, average intercity ticket, e.g. Graasten-Sonderborg
    private const double CityTripMaxKm = 7;               // max trip length for a city ticket
    private const int PassengersPerBus = 55;              // used to get one person's share of the emissions

    private double CityPrice;
    private double IntercityPrice;

    // constructor for default values
    public Bus() : this(DefaultSpeed, DefaultCO2, DefaultCityPrice, DefaultIntercityPrice)
    {
    }

    // constructor for user values
    public Bus(double avgSpeed, double CO2Emission, double cityPrice, double intercityPrice)
    : base("bus", avgSpeed, CO2Emission)
    {
        this.CityPrice = cityPrice;
        this.IntercityPrice = intercityPrice;
    }

    public override void GetUserValues()
    {
        base.GetUserValues(); // get speed from base class

        // get everything else needed
        CO2Emission = ExceptionHandler.GetDouble($"Enter bus CO2 emission for the whole bus (kg/km, 0-{MaxCO2}):", 0, MaxCO2);
        CityPrice = ExceptionHandler.GetDouble($"Enter city ticket price, for trips up to {CityTripMaxKm} km (DKK, 0-{MaxPrice}):", 0, MaxPrice);
        IntercityPrice = ExceptionHandler.GetDouble($"Enter intercity ticket price, for trips over {CityTripMaxKm} km (DKK, 0-{MaxPrice}):", 0, MaxPrice);
    }

    protected override double CalculateCO2(double km)
    {
        // one passenger's share of the whole bus's emissions
        return km * CO2Emission / PassengersPerBus;
    }

    protected override double CalculatePrice(double km)
    {
        // city ticket for short trips, intercity ticket for longer ones
        if (km <= CityTripMaxKm)
        {
            return CityPrice;
        }
        return IntercityPrice;
    }
}
