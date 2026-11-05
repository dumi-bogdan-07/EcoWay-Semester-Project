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

            // The transport modes selected by the user are stored in a list called chosenModes
            Program.GetTransportComparison(distance, chosenModes, chosenFilter);
        }
        while (Continue());
    }

    public static string DoTimeFormatting(double time){ // Split the time formatting into its own method cause we have to reuse it several times.
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

    public static void GetTransportComparison(double distance_val, string[] chosenModes_val, string chosenFilter){

        // List<string> transportList = new List<string>();

        Vehicle[] vehicles = new Vehicle[chosenModes_val.Length];

        for(int i=0; i<chosenModes_val.Length; i++){  
            string transport = chosenModes_val[i];
            
            Console.WriteLine($"\n--- Enter details for {transport} ---");

            switch(transport){
                case "walk": 
                    double walkSpeed = RouteInputProcessor.GetDoubleInput("Enter average walking speed (km/h):");
                    vehicles[i] = new Walk(walkSpeed);
                    break;
                case "bus":
                    double busSpeed = RouteInputProcessor.GetDoubleInput("Enter average bus speed (km/h):");
                    double busCo2 = RouteInputProcessor.GetDoubleInput("Enter Bus CO2 emission factor:");
                    double busPrice = RouteInputProcessor.GetDoubleInput("Enter Bus trip price (DKK):");
                    vehicles[i] = new Bus(busSpeed, busCo2, busPrice);
                    break;
                case "bike":
                    double bikeSpeed = RouteInputProcessor.GetDoubleInput("Enter average bike speed (km/h):");
                    vehicles[i] = new Bike(bikeSpeed);   
                    break;
                case "car":
                    double carSpeed = RouteInputProcessor.GetDoubleInput("Enter average car speed (km/h):");
                    double carCo2 = RouteInputProcessor.GetDoubleInput("Enter Car CO2 emission per km:");
                    double carConsumption = RouteInputProcessor.GetDoubleInput("Enter Car average consumption (km/liter):");
                    double carGasPrice = RouteInputProcessor.GetDoubleInput("Enter average gas price (DKK):");
                    vehicles[i] = new Car(carSpeed, carCo2, carConsumption, carGasPrice);
                    break;
            }
            
            vehicles[i].CalculateStuff(distance_val);
            
            // Every time the foreach loop runs, add the name of the method of transport to its list.
            // transportList.Add(transport);

        }
        Console.WriteLine(new string('-', 40));
        for(int i=0; i<vehicles.Length; i++){
            Console.WriteLine($"{vehicles[i].name}: {DoTimeFormatting(vehicles[i].time)}| Emissions: {vehicles[i].totalCO2Emission:0.00} m³/km | Price: {vehicles[i].tripPrice:0.00} DKK");
            Console.WriteLine(new string('-', 40));
        }

        Vehicle bestVehicle = GetBest_Vehicle(vehicles, chosenFilter);
        PrintFilter(bestVehicle, chosenFilter);
        
    }

    public static Vehicle GetBest_Vehicle(Vehicle[] vehicles, string chosenFilter){
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
    
    public static void PrintFilter(Vehicle bestVehicle, string chosenFilter){
        switch(chosenFilter){
            case "co2":
                Console.WriteLine($"The {bestVehicle.name} method of transport has the lowest emissions at {bestVehicle.totalCO2Emission:0.00} m³/km");
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
