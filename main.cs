// using CarClass;
// using BikeClass;
// using BusClass;
// using WalkClass;
using VehicleClass;
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
            string chosenFilter = RouteInputProcessor.GetFilter();

            // The transport modes selected by the user are stored in a list called chosenModes
            Program.GetTransportComparison(distance, chosenModes, chosenFilter);
        }
        while (Continue());
    }

    public static string DoTimeFormatting(double time) // Split the time formatting into its own method cause we have to reuse it several times.
    {
            int totalMinutes = (int)Math.Round(time*60);
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            string timeFormatted;
            if(hours > 0){
                timeFormatted = $"{hours}h {minutes} mins";
                return timeFormatted;
            } else{
                timeFormatted = $"{minutes} mins";
                return timeFormatted;
            }
    }

    public static void GetTransportComparison(double distance_val, string[] chosenModes_val, string chosenFilter){

        List<double> priceList = new List<double>();
        List<double> timeList = new List<double>(); // only initialised as List<> so i could use .Add :P
        List<double> emissionsList = new List<double>();
        List<string> transportList = new List<string>();

        double lowestTime = double.MaxValue;
        double lowestEmissions = double.MaxValue;
        double lowestCost = double.MaxValue;

        foreach(string transport in chosenModes_val){
            double time = 0;
            double emissions = 0;
            double price = 0;

            Console.WriteLine($"\n--- Enter details for {transport} ---");

            switch(transport){
                case "walk": 
                    double walkSpeed = RouteInputProcessor.GetDoubleInput("Enter average walking speed (km/h):");
                    Walk WalkObj = new Walk(walkSpeed);
                    WalkObj.CalculateStuff(distance_val);
                    time = WalkObj.time;
                    emissions = WalkObj.totalCO2Emission;
                    price = WalkObj.tripPrice;
                    break;
                case "bus":
                    double busSpeed = RouteInputProcessor.GetDoubleInput("Enter average bus speed (km/h):");
                    double busCo2 = RouteInputProcessor.GetDoubleInput("Enter Bus CO2 emission factor:");
                    double busPrice = RouteInputProcessor.GetDoubleInput("Enter Bus trip price (DKK):");
                    Bus BusObj = new Bus(busSpeed, busCo2, busPrice);
                    BusObj.CalculateStuff(distance_val);
                    time = BusObj.time;
                    emissions = BusObj.totalCO2Emission;
                    price = BusObj.tripPrice;
                    break;
                case "bike":
                    double bikeSpeed = RouteInputProcessor.GetDoubleInput("Enter average bike speed (km/h):");
                    Bike BikeObj = new Bike(bikeSpeed);
                    BikeObj.CalculateStuff(distance_val);
                    time = BikeObj.time;
                    emissions = BikeObj.totalCO2Emission;     
                    price = BikeObj.tripPrice;    
                    break;
                case "car":
                    double carSpeed = RouteInputProcessor.GetDoubleInput("Enter average car speed (km/h):");
                    double carCo2 = RouteInputProcessor.GetDoubleInput("Enter Car CO2 emission per km:");
                    double carConsumption = RouteInputProcessor.GetDoubleInput("Enter Car average consumption (km/liter):");
                    double carGasPrice = RouteInputProcessor.GetDoubleInput("Enter average gas price (DKK):");
                    Car CarObj = new Car(carSpeed, carCo2, carConsumption, carGasPrice);
                    CarObj.CalculateStuff(distance_val);
                    time = CarObj.time;
                    emissions = CarObj.totalCO2Emission;
                    price = CarObj.tripPrice;
                    break;
            }

            // Every time the foreach loop runs, add the time, emissions and name of the method of transport to its list.
            timeList.Add(time);
            emissionsList.Add(emissions);
            transportList.Add(transport);
            priceList.Add(price);

        }
        Console.WriteLine(new string('-', 40));
        for(int i=0; i<chosenModes_val.Length; i++){
            Console.WriteLine($"{transportList[i]}: {DoTimeFormatting(timeList[i])}| Emissions: {emissionsList[i]:0.00} m³/km | Price: {priceList[i]:0.00} DKK");
            Console.WriteLine(new string('-', 40));
        }
        
        // Filter checks
        if (chosenFilter == "co2")
            {
                // Initialize an index to keep track of where the lowest value is
                int lowestIndex = 0;

                for (int i = 0; i < emissionsList.Count; i++)
                {
                    if (emissionsList[i] <= lowestEmissions)
                    {
                        // Every loop, if we encounter a new lowest emission number, set lowestEmissions equal to it.
                        lowestEmissions = emissionsList[i];
                        lowestIndex = i; // Keep track of which index the lowest emissions number is at
                    }
                }

                Console.WriteLine($"The {transportList[lowestIndex]} method of transport has the lowest emissions at {lowestEmissions:0.00} m³/km");
            }
        else if (chosenFilter == "time")
            {
                int lowestIndex = 0;

                for (int i = 0; i < timeList.Count; i++)
                {
                    if (timeList[i] <= lowestTime)
                    {
                        lowestTime = timeList[i];
                        lowestIndex = i;
                    }
                }

                Console.WriteLine($"The {transportList[lowestIndex]} method of transport has the fastest time at {DoTimeFormatting(lowestTime)}");
            }
        else if (chosenFilter == "cost")
        {
            int lowestIndex = 0;

            for (int i = 0; i < priceList.Count; i++)
            {
                if (priceList[i] <= lowestCost)
                {
                    lowestCost = priceList[i];
                    lowestIndex = i;
                }
            }

            Console.WriteLine($"The {transportList[lowestIndex]} method of transport has the lowest cost at {lowestCost} DKK");
        }
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
