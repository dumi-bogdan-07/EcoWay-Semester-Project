using VehicleClass;
using System.Formats.Asn1;
public class Program{
    public static void Main(){
        do {
            // Initialization of routeInputProcessor
            RouteInputProcessor routeInputProcessor = new RouteInputProcessor();

            double distance = RouteInputProcessor.GetValidDistance();
            string[] chosenModes = RouteInputProcessor.GetValidTransportMode();
            string chosenFilter = RouteInputProcessor.GetFilter();
            bool useDefaults = RouteInputProcessor.AskUseDefaultValues();

            // The transport modes selected by the user are stored in a list called chosenModes
            GetTransportComparison(distance, chosenModes, chosenFilter, useDefaults);
        }
        while (Continue());
    }

    private static string DoTimeFormatting(double time){ // Split the time formatting into its own method cause we have to reuse it several times.
            int totalMinutes = (int)Math.Round(time*60);
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            string timeFormatted;
            if(hours > 0){
                timeFormatted = $"{hours}h {minutes} mins";
                return timeFormatted;
            }else{
                timeFormatted = $"{minutes} mins";
                return timeFormatted;
            }
    }

    private static void GetTransportComparison(double distance_val, string[] chosenModes_val, string chosenFilter, bool useDefaults){

        Vehicle[] vehicles = new Vehicle[chosenModes_val.Length];

        for(int i=0; i<chosenModes_val.Length; i++){  
            string transport = chosenModes_val[i];
            
            // create a vehicle with its default values
            switch(transport){
                case "walk": vehicles[i] = new Walk(); break;
                case "bus":  vehicles[i] = new Bus();  break;
                case "bike": vehicles[i] = new Bike(); break;
                case "car":  vehicles[i] = new Car();  break;
            }

            // if the user wants custom values, each vehicle asks its specific questions
            if (!useDefaults){
                Console.WriteLine($"\n--- Enter details for {transport} ---");
                vehicles[i].GetUserValues();
            }
            
            vehicles[i].CalculateStuff(distance_val);
        }
        Console.WriteLine(new string('-', 40));
        for(int i=0; i<vehicles.Length; i++){
            Console.WriteLine($"{vehicles[i].name}: {DoTimeFormatting(vehicles[i].time)}| Emissions: {vehicles[i].totalCO2Emission:0.00} kg/km | Price: {vehicles[i].tripPrice:0.00} DKK");
            Console.WriteLine(new string('-', 40));
        }

        Vehicle bestVehicle = GetBest_Vehicle(vehicles, chosenFilter);
        PrintFilter(bestVehicle, chosenFilter);
        
    }

    private static Vehicle GetBest_Vehicle(Vehicle[] vehicles, string chosenFilter){
        Vehicle bestVehicle = vehicles[0];
        foreach(Vehicle v in vehicles){
            switch(chosenFilter){
                case "co2":
                    if(v.totalCO2Emission <= bestVehicle.totalCO2Emission){
                        bestVehicle = v;
                    }
                    break;
                case "time":
                    if(v.time <= bestVehicle.time){
                        bestVehicle = v;
                    }
                    break;
                case "cost":
                    if(v.tripPrice <= bestVehicle.tripPrice){
                        bestVehicle = v;
                    }
                    break;
                    
            }
        }
        return bestVehicle;
    }
    
    private static void PrintFilter(Vehicle bestVehicle, string chosenFilter){
        switch(chosenFilter){
            case "co2":
                Console.WriteLine($"The {bestVehicle.name} method of transport has the lowest emissions at {bestVehicle.totalCO2Emission:0.00} kg/km");
                break;
            case "time":
                Console.WriteLine($"The {bestVehicle.name} method of transport has the fastest time at {DoTimeFormatting(bestVehicle.time)}");
                break;
            case "cost":
                Console.WriteLine($"The {bestVehicle.name} method of transport has the lowest cost at {bestVehicle.tripPrice} DKK");
                break;
        }
        Console.WriteLine(new string('-', 40));
    }
    
    
    private static bool Continue(){
        while (true){ 
            Console.WriteLine("Would you like to do another comparison?");
            string answer = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (answer == "yes"){
                return true;
            }
            else if (answer == "no"){
                return false;
            }
            Console.WriteLine("Please enter yes or no.");
        }
    }
}
