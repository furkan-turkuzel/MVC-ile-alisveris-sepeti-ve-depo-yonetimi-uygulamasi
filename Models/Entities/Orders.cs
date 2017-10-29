using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Orders : IEntity
    {
        public Orders()
        {
            OrderDetails = new List<Entities.OrderDetails>();
        }
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public bool IsActive { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
