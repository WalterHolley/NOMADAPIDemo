using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.db
{
	public partial class Parts
	{
		[Key]
		public int id { get; set; }
		public string part_number { get; set; }
		public string part_name { get; set; }
		public string description { get; set; }
		public string img_url {get; set; }
	}
}
