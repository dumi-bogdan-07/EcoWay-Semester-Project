using System.Text.Json;
using System.IO;
using System.Collection.General;

namespace Transport.Data{
    public class VehicleDefaultDto{
        public double AvgSpeed { get; set; }
        public double CO2Emission { get; set; }
        public double AverageConsumption { get; set; }
        public double AverageGasPrice { get; set; }
        public double CityPrice { get; set; }
        public double IntercityPrice { get; set; }
        public double TripPrice { get; set; }
    }
    public class VehicleRepository{
        private const string FilePath = "DefaultValues.json";

        public Dictionary<string, VehicleDefaultDto> LoadDefaults(){
            if(!File.Exists(FilePath)){
                throw new FileNotFoundException($"The default values file {FilePath} was not found.");  
            }

            string jsonString = File.ReadAllText(FilePath);

            var options = newJsonSerializerOptions {PropertyNameCaseInsensitive = true};
            return JsonSerializer.Deserialize<Dictionary<string, VehicleDefaultsDto>>(jsonString, options)
                    ?? new Dictionary<string, VehicleDefaultsDto>();
        }
    }
}