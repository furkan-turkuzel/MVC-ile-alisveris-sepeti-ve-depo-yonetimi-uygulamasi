using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Categories : IEntity
    {
        public Categories()
        {
            Products = new List<Entities.Products>();
        }
        public int ID { get; set; }
        public string CategoryName{ get; set; }
        public bool IsActive { get; set; }
        public virtual List<Products> Products { get; set; }
    }
}
