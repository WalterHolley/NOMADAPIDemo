using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using Data;
using Data.db;
using ServiceDomain.models;

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

        public HttpResponseMessage UpdateVehicle(Vehicles v)
        {
            HttpResponseMessage result;

            try
            {
                result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonSerializer.Serialize(vehicleData.update(v))) };
            }
            catch (ArgumentNullException e)
            {
                result = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(e.Message)};
            }
            catch (Exception e)
            {
				result = new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(e.Message) };
			}
            return result;
            
        }

        public HttpResponseMessage CreateVehicle(VehicleModel vehicleRequest)
        {
            HttpResponseMessage result;
            try
            {
                Vehicles v = new Vehicles {make = vehicleRequest.make, model = vehicleRequest.model, trim = vehicleRequest.trim, year = vehicleRequest.year};
                vehicleData.add(v);
				result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Success") };

            }
            catch (ArgumentNullException e)
            {
                result = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(e.Message)};
            }
            catch (Exception e)
            {
                result = new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(e.Message) };
            }

            return result;
        }

        public HttpResponseMessage FindVehicle(Vehicles vehicle)
        {
            HttpResponseMessage result;
            try
            {
                List<Vehicles> v = vehicleData.GetVehiclesByParams(vehicle);
                result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent($"{JsonSerializer.Serialize(v)}") };
            }
            catch (ArgumentNullException e)
            {
				result = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(e.Message) };
			}
            catch (Exception e)
            {
				result = new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(e.Message) };
			}

            return result;
        }
    }


}
