using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.db
{
	public partial class Vehicles
	{
		[Key]
		public Int64 id { get; set; }
		public string make { get; set; }
		public string model { get; set; }
		public DateTime year { get; set; }
		public string trim { get; set; }
	}
}
