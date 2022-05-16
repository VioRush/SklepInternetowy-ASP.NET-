using SklepInternetowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy.Interface
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, DeliveryAddress deliveryAddress);
    }
}