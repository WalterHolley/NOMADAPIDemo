using Data.db;
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
		public Vehicles GetVehicle(int id)
		{
			Vehicles result;
			using (var db = new NOMADContext())
			{
				var q = from v in db.DBVehicles where v.id == id select v;
				result = q.FirstOrDefault();
			}

			return result;
		}

		public Vehicles add(Vehicles v)
		{
			using (var db = new NOMADContext())
			{
				db.DBVehicles.Add(v);
				db.SaveChanges();
			}

			return v;
		}

		//TODO:  List retrieval w/paging?
	}
}
