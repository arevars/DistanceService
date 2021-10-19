using DistanceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistanceService.Interfaces
{
    public interface IAirportDetailsService
    {
        public Task<AirportDetails> GetAirportDetailsByIATA(string iata);
    }
}
