using ServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Threading;
using System.Web.WebPages;
using ServiceDomain.models;
using System.Web.Helpers;


namespace API.Controllers
{
    public class VehiclesController : ApiController
    {
        VerhicleService service = new VerhicleService();
        public HttpResponseMessage GetVehicle(int id)
        {
            return service.getVehicle(id);

        }




        // POST: Vehicles/
 
        public HttpResponseMessage Post([FromBody]VehicleModel request)
        {
            HttpResponseMessage response;
            response = service.CreateVehicle(request);
			
            return response;
        }

        public HttpResponseMessage Put([FromBody] VehicleModel request)
        {
            HttpResponseMessage response;
            response = service.UpdateVehicle(request);

            return response;
        }


        // DELETE: Vehicles/5
        /*
        public String Delete(int id)
        {
            try
            {
                // TODO: Add update logic here

            }
            catch
            {
       
            }
        }
        */

    }
}
