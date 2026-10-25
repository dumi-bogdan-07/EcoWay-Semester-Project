using CarClass;
using BikeClass;
using BusClass;
using WalkClass;
using System.Formats.Asn1;
public class Program
{
    public static void Main()
    {
        do {
            // Initialization of routeInputProcessor
            RouteInputProcessor routeInputProcessor = new RouteInputProcessor();

            double distance = RouteInputProcessor.GetValidDistance();
            string[] chosenModes = RouteInputProcessor.GetValidTransportMode();

            // The transport modes selected by the user are stored in a list called chosenModes

            for (int i = 0; i < chosenModes.Length; i++)    // Printing every transport mode selected by the user
            {
                // Console.Write(chosenModes[i] + " ");
                if (chosenModes[i] == "car"){
                    Car car = new Car(distance);
                    Console.WriteLine($"Car: {car.time:0.00} hours | {car.totalCO2Emission:0.00} CO2");
                } else if(chosenModes[i] == "bike"){
                    Bike bike = new Bike(distance);
                    Console.WriteLine($"Bike: {bike.time:0.00} hours | {bike.totalCO2Emission:0.00} CO2");
                } else if(chosenModes[i] == "bus"){
                    Bus bus = new Bus(distance);
                    Console.WriteLine($"Bus: {bus.time:0.00} hours | {bus.totalCO2Emission:0.00} CO2");
                } else{
                    Walk walk = new Walk(distance);
                    Console.WriteLine($"Walk: {walk.time:0.00} hours | {walk.totalCO2Emission:0.00} CO2");
                }
            }
        }
        while (Continue());
    }

    private static bool Continue()
    {
        while (true) { 
            Console.WriteLine("Would you like to do another comparison?");
            string answer = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (answer == "yes")
            {
                return true;
            }
            else if (answer == "no")
            {
                return false;
            }
            Console.WriteLine("Please enter yes or no.");
        }
    }
}
