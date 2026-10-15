public class Program
{
    public static void Main()
    {

        // Initialization of routeInputProcessor
        RouteInputProcessor routeInputProcessor = new RouteInputProcessor();

        double distance = RouteInputProcessor.GetValidDistance();
        string[] chosenModes = RouteInputProcessor.GetValidTransportMode();

        // The transport modes selected by the user are stored in a list called chosenModes

        for (int i = 0; i < chosenModes.Length; i++)    // Printing every transport mode selected by the user
        {
            Console.Write(chosenModes[i] + " ");
        }
    }
}
