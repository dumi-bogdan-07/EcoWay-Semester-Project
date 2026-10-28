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
            Program.GetTransportComparison(distance, chosenModes);
        }
        while (Continue());
    }

    public static void GetTransportComparison(double distance_val, string[] chosenModes_val){
        foreach(string transport in chosenModes_val){
            double time = 0;
            double emissions = 0;
            switch(transport){
                case "walk": Walk WalkObj = new Walk(distance_val);
                    time = WalkObj.time;
                    emissions = WalkObj.totalCO2Emission;
                    break;
                case "bus": Bus BusObj = new Bus(distance_val);
                    time = BusObj.time;
                    emissions = BusObj.totalCO2Emission;
                    break;
                case "bike": Bike BikeObj = new Bike(distance_val);
                    time = BikeObj.time;
                    emissions = BikeObj.totalCO2Emission;
                    break;
                case "car": Car CarObj = new Car(distance_val);
                    time = CarObj.time;
                    emissions = CarObj.totalCO2Emission;
                    break;
            }
            int totalMinutes = (int)Math.Round(time*60);
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;
            string timeFormatted;
            if(hours > 0){
                timeFormatted = $"{hours}h {minutes} mins";
            } else{
                timeFormatted = $"{minutes} mins";
            }
            Console.WriteLine($"{transport}: {timeFormatted}| {emissions:0.00} CO2");
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
