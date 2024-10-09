using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class VehicleData
	{
		public vehicle GetVehicle(int id)
		{
			vehicle result;
			using (var db = new NOMADEntities())
			{
				var q = from v in db.vehicles where v.id == id select v;
				result = q.FirstOrDefault();
			}

			return result;
		}

		public vehicle add(vehicle v)
		{
			using (var db = new NOMADEntities())
			{
				db.vehicles.Add(v);
				db.SaveChanges();
			}

			return v;
		}

		//TODO:  List retrieval w/paging?
	}
}
