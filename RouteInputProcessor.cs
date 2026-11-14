public static class RouteInputProcessor
{
    private const double MinDistance = 1;
    private const double MaxDistance = 50;
    private const int MinModeCount = 2;

    // no MaxModeCount because we have validModes.Length

    public static double GetValidDistance()
    {
        return ExceptionHandler.GetDouble($"Please input a distance in km ({MinDistance}-{MaxDistance}): ", MinDistance, MaxDistance);
    }

    public static string[] GetValidTransportMode()
    {
        string[] validModes = ["car", "bike", "bus", "walk"]; // initialization of an array of the accepted modes of transport

        int modeCount = ExceptionHandler.GetInt($"Please enter how many transport modes you want to input ({MinModeCount}-{validModes.Length}): ", MinModeCount, validModes.Length);
        // get the user input and store it in modeCount, ExceptionHandler will handle any invalid input

        // initialize a new empty array of the modes that will be chosen by the user, with the length of modeCount
        string[] chosenModes = new string[modeCount];

        // Loop modeCount number of times to fill in our chosenModes array
        for (int i = 0; i < modeCount; i++)
        {
            // Loop until the user inputs a valid mode of transport (one contained in validModes[])
            while (true)
            {
                Console.WriteLine($"Please input a transport mode ({string.Join(", ", validModes)}): ");

                // once again if Console.ReadLine() returns null, return an "" instead
                // .Trim() trims blank spaces, .ToLower() makes sure we can process uppercase input as well.
                // so the input can be "     car" or "CAR" or " CAR     " and we can still process it!

                string userInput = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (validModes.Contains(userInput) && !chosenModes.Contains(userInput))
                {
                    chosenModes[i] = userInput;
                    break;
                }

                Console.WriteLine(
                    "Invalid transport mode.");
            }
        }

        return chosenModes;
    }

    public static string GetFilter()
    {
        string userChoice;

        while (true) // Run a loop until the user selects a valid filter
        {
            Console.WriteLine("Please choose the filter you would like to use (co2, time, cost):");
            string[] validResponses = ["co2", "time", "cost"]; // Initializing a list of valid filters that the user can choose from
            string userInput = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (validResponses.Contains(userInput))
            {
                userChoice = userInput; // Store the selected filter in userChoice
                break;
            }

            Console.WriteLine("Invalid filter."); // if the user hasn't selected a valid filter, write this out and run the loop again
        }
        
        return userChoice;
    }

    public static bool AskUseDefaultValues()
    {
        while (true) // run a loop until the user answers yes or no
        {
            Console.WriteLine("Would you like to use the default values? (yes/no)");
            string answer = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (answer == "yes")
            {
                return true; // use the default values
            }
            else if (answer == "no")
            {
                return false; // the user will enter their own values
            }
            Console.WriteLine("Please enter yes or no.");
        }
    }
}