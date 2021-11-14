using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassConlsole
{
    class Currency
    {
        protected string Name;
        protected double ExRate;

        public Currency() { }

        public Currency(string n) 
        {
            Name = n;
        }

        public Currency(string n, double er)
        {
            Name = n;
            ExRate = er;
        }

        public Currency(Currency objCurrency)
        {
            Name = objCurrency.Name;
            ExRate = objCurrency.ExRate;
        }

        public string GSName
        {
            get { return Name; }
            set { Name = value; }
        }

        public double GSExRate
        {
            get { return ExRate; }
            set { ExRate = value; }
        }
    }
}
