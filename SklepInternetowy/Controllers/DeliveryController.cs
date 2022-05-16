using Microsoft.AspNet.Identity;
using SklepInternetowy.Interface;
using SklepInternetowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepInternetowy.Controllers
{
    public class DeliveryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IOrderProcessor orderProcessor = new EmailOrderProcessor();
        Cart cart;
        // GET: Delivery
        [Authorize]
        public ActionResult Index()
        {
            return View(db.DeliveryAddresses.ToList());
        }

        public ActionResult Create(Cart c)
        {
            cart = c;
            ViewBag.cart = c.Lines.Count();

            return View();
        }

        // POST: Delivery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryAddressID,UserName,UserSurname,Country,City,Street,Address,PostalCode")] DeliveryAddress deliveryAddress, Cart ca)
        {
            if(ca.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Koszyk jest pusty!");
            }
            if (ModelState.IsValid)
            {
                deliveryAddress.ApplicationUserId = User.Identity.GetUserId();
                db.DeliveryAddresses.Add(deliveryAddress);
                db.SaveChanges();
                orderProcessor.ProcessOrder(cart, deliveryAddress);
                cart.Clear();
                return RedirectToAction("ZamowienieZlozone");
            }
            return View(deliveryAddress);

        }
        public ActionResult ZamowienieZlozone()
        {
            return View();
        }
    }
}