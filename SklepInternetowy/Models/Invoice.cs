using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy.Models
{
    public class Invoice
    {
		public int InvoiceID { get; set; }

		public DateTime Date { get; set; }

		public bool Cash { get; set; }


		public string UserId { get; set; }

		public virtual ApplicationUser User { get; set; }

		public virtual ICollection<Sale> Sales { get; set; }
	}
}