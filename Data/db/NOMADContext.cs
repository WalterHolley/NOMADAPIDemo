using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.db
{
	public partial class NOMADContext : DbContext
	{
		public NOMADContext() : base("name=NOMADContext"){ var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance; }
		public virtual DbSet<Parts> DBParts { get; set; }
		public virtual DbSet<Fitment> DBFitment { get; set; }
		public virtual DbSet<Vehicles> DBVehicles { get; set; }
	}
}
