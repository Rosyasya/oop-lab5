using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassConlsole
{
    class Product
    {
        protected string Name;
        protected double Price;
        protected Currency Cost;
        protected int Quantity;
        protected string Producer;
        protected int Weight;

        public Product() { }

        public Product(string n)
        {
            Name = n;
        }

        public Product(string n, double p, Currency c)
        {
            Name = n;
            Price = p;
            Cost = c;
        }

        public Product(Product objProduct)
        {
            Name = objProduct.Name;
            Price = objProduct.Price;
            Cost = objProduct.Cost;
            Quantity = objProduct.Quantity; 
            Producer = objProduct.Producer;
            Weight = objProduct.Weight;
        }

        public string GSName
        {
            get { return Name; }
            set { Name = value; }
        }

        public double GSPrice
        {
            get { return Price; }
            set { Price = value; }
        }

        public Currency GSCost
        {
            get { return Cost; }
            set { Cost = value; }
        }

        public int GSQuantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        public string GSProducer
        {
            get { return Producer; }
            set { Producer = value; }
        }

        public int GSWeight
        {
            get { return Weight; }
            set { Weight = value; }
        }

        public double GetPriceInUAH() 
        {
            return Price * Cost.GSExRate;
        }

        public double GetTotalPriceInUAH()
        {
            return Price * Cost.GSExRate * Quantity;
        }

        public double GetTotalWeight()
        {
            return Weight * Quantity;
        }
    }
}
