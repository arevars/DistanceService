using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DistanceService.Models.RequestModels
{
    public class GetDistanceRequestModel
    {
        public string IataFrom { get; set; }
        public string IataTo { get; set; }
    }
}
