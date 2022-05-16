using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepInternetowy.Models
{
    public class DeliveryAddress
    {
        public int DeliveryAddressID { get; set; }
        public String UserName { get; set; }
        public String UserSurname { get; set; }
        public String Country { get; set; }
        public String City { get; set; }
        public String Street { get; set; }
        public String Address { get; set; }
        public int PostalCode { get; set; }
        public string ApplicationUserId { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}