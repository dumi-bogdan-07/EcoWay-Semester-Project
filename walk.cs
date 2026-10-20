namespace WalkClass;

class Walk {
    public double avgSpeed = 4.5; // km/hour
    public double CO2Emission = 0; // CO2 per killometer average Euro4 n Euro5
    public double time;
    public double totalCO2Emission;

    public Walk(double km) {
        time = km / avgSpeed;
        totalCO2Emission = 0;
    }
}

// Should there be a method, we can implement it later
