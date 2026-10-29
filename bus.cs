namespace BusClass;

class Bus {
    
    public double avgSpeed = 30; // in km/h, figure is low due to the inclusion of bus stops. 
    public double CO2Emission = 1.1; // This is CO2 emmissions per kilometer. It should be noted Sonderborg busses use biogas as fuel.
    public double time;
    public double totalCO2Emission;
    public double busTicketPriceCity = 20.83; // Average of an adult, child and Rejeskort bought tickets for buses within the city of Soenderborg
    public double busTicketPriceIntercity = 32.67; // Average of an adult, child and Rejeskort bought tickets for intercity busses, like Graasten-Soenderborg
    public double tripPrice;

    public Bus(double km){
        time = km / avgSpeed; // It calls upon the imputed distance from the Main file.
        totalCO2Emission = (km * CO2Emission) / 55; // It does the CO2 output of a trip, based on the inputed kilometers from Main. Division by 55 is to account for personal footprint, not the entire bus.

        if (km <= 7)
        {
            tripPrice = busTicketPriceCity;
        }
        else
        {
            tripPrice = busTicketPriceIntercity;
        }
    }

    // Should there be a need for methods, they will be implemented later.   
}
