using DistanceService.Interfaces;
using DistanceService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace DistanceService.Sevices
{
    public class AirportDetailsService : IAirportDetailsService
    {
        private readonly IConfiguration _config;

        public AirportDetailsService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<AirportDetails> GetAirportDetailsByIATA(string iata)
        {
            AirportDetails details = null;
            string Url = _config.GetValue<string>("AirportDetailsServiceUrl");

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(Url+iata);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        details = JsonSerializer.Deserialize<AirportDetails>(result);
                    }
                }

                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return details;
        }
    }
}
