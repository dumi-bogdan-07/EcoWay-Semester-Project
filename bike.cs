namespace BikeClass;

class Bike {
    
    public double avgSpeed = 15; // in km/h, figure is low due to the inclusion of bus stops. 
    public double time;
    public double totalCO2Emission = 0;

    public Bike(double km){
        time = km / avgSpeed; // It calls upon the imputed distance from the Main file.
    }

    // Should there be a need for methods, they will be implemented later.   
}
