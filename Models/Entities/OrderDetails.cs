using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class OrderDetails : IEntity
    {
        public OrderDetails()
        {
            Store = new List<Entities.Store>();
        }
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public virtual Products Product { get; set; }
        public virtual Orders Order { get; set; }
        public virtual List<Store> Store { get; set; }

    }
}
