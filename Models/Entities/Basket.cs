using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Basket
    {
        public Basket()
        {
            AddedProducts = new List<AddedProduct>();
        }
        public List<AddedProduct> AddedProducts { get; set; }

        public decimal Total
        {
            get { return AddedProducts.Sum(x => x.Product.UnitPrice * x.Quantity); }
        }
    }
}
