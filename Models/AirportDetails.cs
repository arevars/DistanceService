using System.Text.Json.Serialization;

namespace DistanceService.Models
{
    public class AirportDetails
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("iata")]
        public string IATA { get; set; }

        [JsonPropertyName("timezone_region_name")]
        public string TimezoneRegionName { get; set; }

        [JsonPropertyName("country_iata")]
        public string CountryIATA { get; set; }

        [JsonPropertyName("rating")]
        public int? rating { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("location")]
        public Location LocationData { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
