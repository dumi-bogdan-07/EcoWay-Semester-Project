namespace BusClass;

class Bus {
    
    public double avgSpeed = 30; // in km/h, figure is low due to the inclusion of bus stops. 
    public double CO2Emission = 1.1; // This is CO2 emmissions per kilometer. It should be noted Sonderborg busses use biogas as fuel.
    public double time;
    public double totalCO2Emission;

    public Bus(double km){
        time = km / avgSpeed; // It calls upon the imputed distance from the Main file.
        totalCO2Emission = km * CO2Emission; // It does the CO2 output of a trip, based on the inputed kilometers from Main. 
    }

    // Should there be a need for methods, they will be implemented later.   
}