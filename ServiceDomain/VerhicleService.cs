using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using Data;

namespace ServiceDomain
{
    public class VerhicleService
    {
        private VehicleData vehicleData;
        public VerhicleService() { 
            vehicleData = new VehicleData();
        }

        public String getVehicle(int vehicleId)
        {
            String result;

            result = JsonSerializer.Serialize(vehicleData.GetVehicle(vehicleId));
        

           return result;
        }

        public String CreateVehicle(String vehicleRequest)
        {
            vehicle v = vehicleData.add(JsonSerializer.Deserialize<vehicle>(vehicleRequest));
            return JsonSerializer.Serialize(v);
        }
    }
}
