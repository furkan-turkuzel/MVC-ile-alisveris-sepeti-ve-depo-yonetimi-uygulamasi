using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.UI.Shopping.Models
{
    public class BasketOrderDetailsViewModel
    {
        public List<OrderDetails> OrderDetail { get; set; }
        public Basket basket { get; set; }
    }
}