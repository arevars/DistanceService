using DistanceService.Interfaces;
using DistanceService.Models;
using DistanceService.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistanceService.Sevices
{
    public class DistanceService : IDistanceService
    {
        private readonly IAirportDetailsService _detailsService;

        public DistanceService(IAirportDetailsService detailsService)
        {
            _detailsService = detailsService;
        }
        public async Task<GetDistanceResponseModel> GetDistance(GetDistanceRequestModel request)
        {
            var result1 = await _detailsService.GetAirportDetailsByIATA(request.IataFrom);
            var result2 = await _detailsService.GetAirportDetailsByIATA(request.IataTo);

            var point1 = new Location
            {
                Longitude = result1.LocationData.Longitude,
                Latitude = result1.LocationData.Latitude,
            };

            var point2 = new Location
            {
                Longitude = result2.LocationData.Longitude,
                Latitude = result2.LocationData.Latitude,
            };

            var result = CalculateDistance(point1, point2);

            return new GetDistanceResponseModel()
            {
                Distance = result.ToString()
            };
        }

        public double CalculateDistance(Location point1, Location point2)
        {
            var d1 = point1.Latitude * (Math.PI / 180.0);
            var num1 = point1.Longitude * (Math.PI / 180.0);
            var d2 = point2.Latitude * (Math.PI / 180.0);
            var num2 = point2.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
