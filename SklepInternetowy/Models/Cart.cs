using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public class CartLine
        {
            public Product product { get; set; }
            public int Quantity { get; set; }
        }

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.product.ProductID == product.ProductID);
        }

        public float ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.product.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}