namespace VehicleClass;

public abstract class Vehicle{
    public string? name;
    public double avgSpeed { get; set; }
    public double time { get; set; }
    public double totalCO2Emission { get; set; }
    public double tripPrice { get; set; }
    public double CO2Emission { get; set; }

    protected Vehicle(double avgSpeed, double CO2Emission, double tripPrice){
        this.avgSpeed = avgSpeed;
        this.CO2Emission = CO2Emission;
        this.tripPrice = tripPrice;
    }
    public abstract void CalculateStuff(double km);
}

class Bike : Vehicle{
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
    public Walk(double avgSpeed) : base(avgSpeed, 0, 0){
        name = "walk";
        totalCO2Emission = 0;
        tripPrice = 0;
    }
    public override void CalculateStuff(double km){
        time = km/avgSpeed;
    }
}

class Car : Vehicle{
    public double averageGasPrice;
    public double averageConsumption;
    
    public Car(double avgSpeed, double CO2Emission, double averageConsumption, double averageGasPrice)
    : base(avgSpeed, CO2Emission, 0){
        name = "car";
        this.averageGasPrice = averageGasPrice;
        this.averageConsumption = averageConsumption;
    }
    public override void CalculateStuff(double km){
        time = km/avgSpeed;
        totalCO2Emission = km*CO2Emission;
        tripPrice = (km / averageConsumption) * averageGasPrice;
    }
}

class Bus : Vehicle{
    public Bus(double avgSpeed, double CO2Emission, double tripPrice)
    : base(avgSpeed, CO2Emission, tripPrice){
        name = "bus";
        this.tripPrice = tripPrice;
    }
    public override void CalculateStuff(double km){
        time = km/avgSpeed;
        totalCO2Emission = (km*CO2Emission)/55;
    }
}