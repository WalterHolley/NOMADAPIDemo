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

		public part GetPart(int id)
		{
			part result = null;

			using (var db = new NOMADEntities())
			{
				var res = from p in db.parts
						  where p.id == id
						  select p;

				result = res.FirstOrDefault();
			}

			return result;
		}

		public part Add(part p)
		{
			part result = null;

			using (var db = new NOMADEntities())
			{
				db.parts.Add(p);
				db.SaveChanges();
			}

			return result;
		}
	}
}
