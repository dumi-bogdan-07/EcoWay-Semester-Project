namespace CarClass;

class Car {
    public double avgSpeed = 40; // km/hour
    public double CO2Emission = 0.15; // CO2 per killometer average Euro4 n Euro5
    public double time;
    public double totalCO2Emission;
    public double averageGasPrice = 18.2; // 18 DKK/L. Average of 17.88 DKK/L on gas, 19.4 DKK/L on diesel. Rough average.
    public double averageConsumption = 15.8; // in km/L, average of Euro4 and Euro5 consumptions, both gas and diesel engines.
    public double tripPrice;

    public Car(double km) {
        time = km / avgSpeed;
        totalCO2Emission = km * CO2Emission;
        tripPrice = (km / averageConsumption) * averageGasPrice; 
    }
}

// Should there be a method, we can implement it later