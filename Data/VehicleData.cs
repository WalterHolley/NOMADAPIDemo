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

		public List<Vehicles> GetVehiclesByParams(Vehicles veh)
		{
			List<Vehicles> result = new List<Vehicles>();

			using (var db = new NOMADContext())
			{
				var q = db.DBVehicles.Where(x => veh.make == String.Empty? x.make.Any() : x.make.Contains(veh.make))
					.Where(x => veh.model == String.Empty? x.model.Any() : x.make.Contains(x.model))
					.Where(x => veh.year == DateTime.MinValue? x.year >= veh.year : x.year == veh.year);

				result = q.ToList();
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

		public Vehicles update(Vehicles veh)
		{
			using (var db = new NOMADContext())
			{
				var q = from v in db.DBVehicles where veh.id == v.id select v;
				if (q.Count() != 1)
				{
					throw new ArgumentException("Vehicle Entry not found");
				}
				else
				{
					q.First().model = veh.model;
					q.First().year = veh.year;
					q.First().trim = veh.trim;
					q.First().make = veh.make;
					db.SaveChanges();
				}
			}
			return veh;
		}



		//TODO:  List retrieval w/paging?
	}
}
