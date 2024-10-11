using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.db
{
	public partial class Fitment
	{
		[Key] 
		public int Id { get; set; }
		public int part_id {get;set;}
		public int vehicle_id{get;set;}
	}
}
