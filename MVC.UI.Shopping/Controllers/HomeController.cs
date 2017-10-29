using BLL.Abstract;
using DAL.Concrete.DBContext;
using MVC.UI.Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Shopping.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _ProductService;
        public HomeController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        TrendyolDBContext db = new TrendyolDBContext();
        [HttpGet]
        public ActionResult Index(int page = 1,int category = 0)
        {
            int pageSize = 10;
            var products = _ProductService.GetAll(category);

            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageSize = pageSize,
                PageCount = (int)(Math.Ceiling(products.Count / (double)pageSize)),
                CurrentCategory = category,
                CurrentPage = page
            };

            TempData.Add("category", "category");
            
            return View(model);
        }
      

    }
}