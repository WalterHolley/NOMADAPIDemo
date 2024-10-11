using ServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class VehiclesController : ApiController
    {
        VerhicleService service = new VerhicleService();
        public HttpResponseMessage Get(int id)
        {
            return service.getVehicle(id);

        }


        // POST: Vehicles/
        public String Post([FromBody] String request)
        {
            return service.CreateVehicle(request);
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
