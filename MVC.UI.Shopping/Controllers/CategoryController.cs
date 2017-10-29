using BLL.Abstract;
using DAL.Abstract;
using MVC.UI.Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Shopping.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        public PartialViewResult CategoryList()
        {
            CategoryListViewModel model = new CategoryListViewModel
            {
                CurrentCategory = Convert.ToInt32(Session["category"]),
                Categories = _CategoryService.GetAll(0)
            };

            return PartialView(model);
        }
        
    }
}