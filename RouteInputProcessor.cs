using System.ComponentModel;
using System.Runtime.InteropServices;

public class RouteInputProcessor
{
    public static double GetValidDistance()
    {
        while (true)
        {
            Console.WriteLine("Please input distance (in kms): ");

            try // check if the input is a valid double, if not, catch the exception and prompt user to try again
            {
                // (?? "") means that if Console.ReadLine() returns null, return an empty string ("") instead, so it can be caught by our exceptions
                // this whole try catch method can be simplified by using TryParse... but Amir hasn't taught that yet!

                double input = double.Parse(Console.ReadLine() ?? "");
                if (input <= 0)     // check if input is negative
                {
                    Console.WriteLine("Please enter an actual distance");
                    continue;   // ...and if it is, prompt user to try again with different input
                }

                return input; // return the input to callers of this method
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number you entered is too large. Please enter a smaller value.");
            }
        }
    }

    public static string[] GetValidTransportMode()
    {
        string[] validModes = ["car", "bike", "bus", "walk"]; // initialization of an array of the accepted modes of transport
        int modeCount;

        // loop until user inputs a number between 2-4 inclusive 
        // ...because we need at least 2 modes to compare and at most 4 modes because we only have 4 valid modes

        while (true)
        {
            Console.WriteLine("Please enter how many transport modes you want to input (2-4): ");

            try // check if the input is a valid integer, if not, catch the exception and prompt user to try again
            {
                modeCount = int.Parse(Console.ReadLine() ?? "0");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            if (modeCount < 2 || modeCount > 4)
            {
                Console.WriteLine("Please enter a number between 2 and 4.");
                continue;
            }
            else
            {
                break;
            }
        }

        // initialize a new empty array of the modes that will be chosen by the user, with the length of modeCount (2-4)
        string[] chosenModes = new string[modeCount];

        // Loop modeCount number of times to fill in our chosenModes array
        for (int i = 0; i < modeCount; i++)
        {
            // Loop until the user inputs a valid mode of transport (one contained in validModes[])
            while (true)
            {
                Console.WriteLine("Please input a transport mode (car, bike, bus, walk): ");

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
}