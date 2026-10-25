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
        // Loop to He's backhe'sscared yeah uhwait letme letmesharemyscreen for somereasonJ is superbroken forme by thewayI likeevery timeIcoverevery timeIcover over something likeI don't know how to experimentmaybesharemyscreen okay nowI can'tI can't like okayevery timeIhover over something like you see how thehoverablesticks likeitdoesn't disappearI don't knowwhyitdoes that yeahwait nowI can't clickit because of thefuckinghover thingit'ssoannoying okayI thinkI have to changemybrowser yeah uhwakemeI haveafilterfilter how thefuturefilter can you okay perfect these four these four yeah
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
