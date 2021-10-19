using DistanceService.Interfaces;
using DistanceService.Models;
using DistanceService.Models.RequestModels;
using System;
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

        public double CalculateDistance(Location point1, Location point2, char unit = 'M')
        {
            double rlat1 = Math.PI * point1.Latitude / 180;
            double rlat2 = Math.PI * point2.Latitude / 180;
            double theta = point1.Longitude - point2.Longitude;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }
        
    }
}
