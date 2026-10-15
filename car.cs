namespace CarClass;

class Car {
    public double avgSpeed = 40; // km/hour
    public double CO2Emission = 0.15; // CO2 per killometer average Euro4 n Euro5
    public double time;
    public double totalCO2Emission;

    public Car(double km) {
        time = km / avgSpeed;
        totalCO2Emission = km * CO2Emission;
    }
}

// Should there be a method, we can implement it later