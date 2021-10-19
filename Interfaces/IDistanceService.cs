using DistanceService.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistanceService.Interfaces
{
    public interface IDistanceService
    {
        public Task<GetDistanceResponseModel> GetDistance(GetDistanceRequestModel request);
    }
}
