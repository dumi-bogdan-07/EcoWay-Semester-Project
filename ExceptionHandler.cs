public static class ExceptionHandler
{
    public static double GetDouble(string prompt, double minValue, double maxValue)
    {
        while (true)
        {

            Console.WriteLine(prompt);

            try
            {
                double input = double.Parse(Console.ReadLine() ?? "");

                if (input < minValue || input > maxValue)
                {
                    Console.WriteLine($"Please enter a number between {minValue} and {maxValue}.");
                    continue;
                }
                return input;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    public static int GetInt(string prompt, int minValue, int maxValue)
    {
        while (true)
        {

            Console.WriteLine(prompt);

            try
            {
                int input = int.Parse(Console.ReadLine() ?? "0");

                if (input < minValue || input > maxValue)
                {
                    Console.WriteLine($"Please enter a number between {minValue} and {maxValue}.");
                    continue;
                }
                return input;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too large or too small. Please enter a valid integer.");
            }
        }
    }
}