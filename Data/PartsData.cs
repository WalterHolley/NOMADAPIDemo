using Data.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class PartsData
	{

		public PartsData() { }

		public Parts GetPart(int id)
		{
			Parts result = null;

			using (var db = new NOMADContext())
			{
				var res = from p in db.DBParts
						  where p.id == id
						  select p;

				result = res.FirstOrDefault();
			}

			return result;
		}

		public List<Parts> SearchParts(Parts part)
		{
			List<Parts> result = null;

			using (var db = new NOMADContext())
			{
				var q = db.DBParts.Where(x => x.part_number.Contains(part.part_number))
					.Where(x => x.part_name == String.Empty ? x.part_name.Any() : x.part_name.Contains(part.part_name))
					.Where(x => x.description == String.Empty ? x.description.Any() : x.description.Contains(x.description));
				result = q.ToList();
			}

			return result;
		}

		public List<Parts> PartsByVehicleId(int vehicleId)
		{
			List<Parts> parts = null;

			using (var db = new NOMADContext())
			{
				var q = from p in db.DBParts
						join f in db.DBFitment on p.id equals f.part_id
						where f.vehicle_id == vehicleId
						select p;
				parts = q.ToList();
			}

			return parts;

		}



		public Parts Add(Parts p)
		{
			
			using (var db = new NOMADContext())
			{
				db.DBParts.Add(p);
				db.SaveChanges();
			}

			return p;
		}
	}
}
