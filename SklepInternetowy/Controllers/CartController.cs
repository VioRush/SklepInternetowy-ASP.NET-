using Microsoft.AspNet.Identity;
using SklepInternetowy.Interface;
using SklepInternetowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SklepInternetowy.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IOrderProcessor orderProcessor;
        // GET: Cart
        public ActionResult Index()
        {
            //Cart cart = GetCart();
            return View(new CartIndexViewModel { Cart = GetCart() });
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            GetCart().AddItem(product, 1);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            GetCart().RemoveLine(product);
            return RedirectToAction("Index");
        }

      //  public ActionResult Summary(Cart cart)
        //{
          //  return View(cart);
        //}
        public ActionResult Checkout()
        {
            Cart cart = GetCart();
            ViewBag.Lines = cart.Lines.Count();
            return View(new DeliveryAddress());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout([Bind(Include = "DeliveryAddressID,UserName,UserSurname,Country,City,Street,Address,PostalCode")] DeliveryAddress deliveryAddress)
        {
            Cart cart = GetCart();
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Koszyk jest pusty!");
            }
            if (ModelState.IsValid)
            {
                deliveryAddress.ApplicationUserId = User.Identity.GetUserId();
                db.DeliveryAddresses.Add(deliveryAddress);
                db.SaveChanges();
                Invoice invoice = new Invoice();
                invoice.Date = DateTime.Today;
                invoice.Cash = true ;
                invoice.UserId = User.Identity.GetUserId();
                db.Invoices.Add(invoice);
                db.SaveChanges();
                //orderProcessor.ProcessOrder(cart, deliveryAddress);

                Sale sale;
                foreach (var line in cart.Lines)
                {
                    sale = new Sale();
                    sale.InvoiceID = invoice.InvoiceID;
                    sale.ProductID = line.product.ProductID;
                    db.Sales.Add(sale);
                    db.SaveChanges();
                }
                cart.Clear();
               // return RedirectToAction("ZamowienieZlozone");
                return RedirectToAction("Index");
            }
            return View(deliveryAddress);

        }
        public ActionResult ZamowienieZlozone()
        {
            return View();
        }

    }
}