using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.UI.Shopping.Models
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
            Categories = new List<Categories>();
        }

        public List<Categories> Categories { get; set; }
        public int CurrentCategory { get; set; }
    }
}