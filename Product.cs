using System;
using System.Collections.Generic;
using System.Text;

namespace Basket_Of_Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }

        public Product(int id, string name, double price, int category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"Id: {Id}\t  Name: {Name}\t  Price: {Price}\t  Category: {Category}";
        }
    }
}

