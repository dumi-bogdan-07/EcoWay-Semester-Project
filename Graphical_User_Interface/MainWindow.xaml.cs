namespace FirstSemesterProject.Graphical_User_Interface;

using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

public partial class MainWindow : System.Windows.Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    // The averages. Keep them in sync with the gray hints (the Tag="Average: ..." values in the XAML file please 🙏).
    private const double AvgCarCo2 = 120, AvgCarSpeed = 50, AvgCarConsumption = 6.5, AvgCarFuelPrice = 13.50;
    private const double AvgBusCo2 = 70, AvgBusSpeed = 30, AvgBusTicket = 20;
    private const double AvgBikeSpeed = 15, AvgWalkSpeed = 5;

    // Fires whenever any of the 4 checkboxes is ticked/unticked
    private void Transport_Changed(object sender, RoutedEventArgs e) => UpdateUiState();

    // Fires on every keystroke in the kilometer box
    private void txtDistance_TextChanged(object sender, TextChangedEventArgs e) => UpdateUiState();

    // Valid distance = a number between 1 and 50 (matches the hint in the XAML)
    private bool TryGetDistance(out double km) =>
        double.TryParse(txtDistance.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out km)
        && km >= 1 && km <= 50;

    private void UpdateUiState()
    {
        // These events can fire while InitializeComponent is still building the window
        if (btnCalculate == null || txtSelectionHint == null || txtDistance == null) return;

        int selected = new[] { cbCar, cbBus, cbBike, cbWalk }.Count(c => c.IsChecked == true);
        bool distanceOk = TryGetDistance(out _);

        // max 4 is automatic: there are only 4 boxes
        btnCalculate.IsEnabled = selected >= 2 && distanceOk;

        txtSelectionHint.Text =
            selected < 2   ? "Select at least 2 options" :
            !distanceOk    ? $"{selected} options selected - now enter a distance between 1 and 50 km" :
                             $"{selected} options selected";
    }

    // Empty box or invalid text -> use the average, simple as
    private static double ValueOrDefault(TextBox box, double average) =>
        double.TryParse(box.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out var v) ? v : average;
    
    private void btnCalculate_Click(object sender, RoutedEventArgs e)
    {
        if (!TryGetDistance(out double km)) return;   // km = journey length for all the calculations below

        if (cbCar.IsChecked == true)
        {
            double co2         = ValueOrDefault(txtCarCo2, AvgCarCo2);
            double speed       = ValueOrDefault(txtCarSpeed, AvgCarSpeed);
            double consumption = ValueOrDefault(txtCarConsumption, AvgCarConsumption);
            double fuelPrice   = ValueOrDefault(txtCarFuelPrice, AvgCarFuelPrice);
            // ... calculate car results / call the methods
        }
        if (cbBus.IsChecked == true)
        {
            double co2    = ValueOrDefault(txtBusCo2, AvgBusCo2);
            double speed  = ValueOrDefault(txtBusSpeed, AvgBusSpeed);
            double ticket = ValueOrDefault(txtBusTicket, AvgBusTicket);
            // ... calculate bus results / call the methods
        }
        if (cbBike.IsChecked == true)
        {
            double speed = ValueOrDefault(txtBikeSpeed, AvgBikeSpeed);
            // ... bike results / call the methods
        }
        if (cbWalk.IsChecked == true)
        {
            double speed = ValueOrDefault(txtWalkSpeed, AvgWalkSpeed);
            // ... walking results / call the methods
        }
    }
}