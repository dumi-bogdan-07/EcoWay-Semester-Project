Car :
    avgSpeed = 40; // km/hour
    CO2Emission = 0.15; // CO2 per killometer average Euro4 n Euro5
    averageGasPrice = 18.2; // 18 DKK/L. Average of 17.88 DKK/L on gas, 19.4 DKK/L on diesel. Rough average.
    averageConsumption = 15.8; // in km/L, average of Euro4 and Euro5 consumptions, both gas and diesel engines.

Bus :
    avgSpeed = 30; // in km/h, figure is low due to the inclusion of bus stops. 
    CO2Emission = 1.1; // This is CO2 emmissions per kilometer. It should be noted Sonderborg busses use biogas as fuel.
    busTicketPriceCity = 20.83; // Average of an adult, child and Rejeskort bought tickets for buses within the city of Soenderborg
    busTicketPriceIntercity = 32.67; // Average of an adult, child and Rejeskort bought tickets for intercity busses, like Graasten-Soenderborg

Bike :
    double avgSpeed = 15; // in km/h
    double totalCO2Emission = 0;
    double tripPrice = 0;

Walk :
    avgSpeed = 4.5; // km/hour
    CO2Emission = 0; // CO2 per killometer average Euro4 n Euro5
    tripPrice = 0;