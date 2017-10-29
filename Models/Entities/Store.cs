using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Store : IEntity
    {
        public int ID { get; set; }
        public int OrderDetailID { get; set; }
        public bool IsProcessing { get; set; }
        public bool IsDone { get; set; }
        public virtual OrderDetails OrderDetail { get; set; }
       

    }
}
