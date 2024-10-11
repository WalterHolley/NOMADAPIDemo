using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using Data;
using Data.db;

namespace ServiceDomain
{
    public class VerhicleService
    {
        private VehicleData vehicleData;
        public VerhicleService() { 
            vehicleData = new VehicleData();
        }

        public HttpResponseMessage getVehicle(int vehicleId)
        {
            HttpResponseMessage result;
    
            try
            {
                Vehicles v = vehicleData.GetVehicle(vehicleId);
                result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonSerializer.Serialize(v))};
            }
            catch(Exception e) 
            {
                result = new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(e.Message)};
            }
        

           return result;
        }

        public String CreateVehicle(String vehicleRequest)
        {
            Vehicles v = vehicleData.add(JsonSerializer.Deserialize<Vehicles>(vehicleRequest));
            return JsonSerializer.Serialize(v);
        }
    }
}
