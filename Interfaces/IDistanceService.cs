using DistanceService.Models.RequestModels;
using System.Threading.Tasks;

namespace DistanceService.Interfaces
{
    public interface IDistanceService
    {
        public Task<GetDistanceResponseModel> GetDistance(GetDistanceRequestModel request);
    }
}
