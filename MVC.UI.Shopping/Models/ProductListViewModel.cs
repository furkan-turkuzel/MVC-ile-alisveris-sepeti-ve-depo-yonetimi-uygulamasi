using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.UI.Shopping.Models
{
    public class ProductListViewModel
    {
        public int CurrentCategory { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public List<Products> Products { get; set; }
    }
}