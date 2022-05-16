using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SklepInternetowy.Models
{
	public class Product
	{
		public int ProductID { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Category { get; set; }

		public float Price { get; set; }

		public virtual ICollection<Sale> Sales { get; set; }

	//	public int OkładkaID { get; set; }
		//public virtual Okładka Okładka { get; set; }
	}
}