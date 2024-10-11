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
