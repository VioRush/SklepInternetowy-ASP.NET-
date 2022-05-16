using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy.Models
{
	public class Sale
	{
		public int SaleID { get; set; }

		public int InvoiceID { get; set; }

		public int ProductID { get; set; }

		public virtual Invoice Invoice { get; set; }

		public virtual Product Product { get; set; }
	}
}