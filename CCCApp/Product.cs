using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCCApp
{
    class Product
    {
        private string amount;

        public Product(string amount)
        {
            this.amount = amount;
        }

        public Product()
        {
            
        }

        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
      

    }
}
