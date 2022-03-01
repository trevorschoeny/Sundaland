using System;
using System.Collections.Generic;
using System.Linq;

namespace Sundaland.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Book book, int qty)
        {
            BasketLineItem lineItem = Items
                .Where(b => b.Book.Title == book.Title)
                .FirstOrDefault();

            if (lineItem == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                Items.FirstOrDefault(b => b.Book.Title == book.Title).Quantity += qty;
                //lineItem.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            //double total = Items.Sum(x => x.Quantity * x.Book.Price);

            double total = 0.0;

            foreach (BasketLineItem i in Items)
            {
                total += (i.Book.Price * i.Quantity);
            }

            return total;
        }
    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
