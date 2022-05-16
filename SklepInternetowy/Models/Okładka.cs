using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SklepInternetowy.Models
{
    public class Okładka
    {
        //[Key]
        public int OkładkaID { get; set; }

        //[ForeignKey("Product")]
        //public string ProductID { get; set; }

        //public virtual Product Product { get; set; }
    }
}