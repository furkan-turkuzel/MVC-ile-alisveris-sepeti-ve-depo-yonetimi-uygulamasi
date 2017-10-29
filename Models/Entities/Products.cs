using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Products : IEntity
    {
        public Products()
        {
            OrderDetails = new List<Entities.OrderDetails>();
        }
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public bool IsActive { get; set; }
        public virtual Categories Category { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
