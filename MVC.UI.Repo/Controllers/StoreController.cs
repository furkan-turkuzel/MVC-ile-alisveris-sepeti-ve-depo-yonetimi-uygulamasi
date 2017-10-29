using BLL.Abstract;
using DAL.Concrete.DBContext;
using Models.Entities;
using MVC.UI.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Repo.Controllers
{
    public class StoreController : Controller
    {
        private IStoreService _StoreService;
        public StoreController(IStoreService StoreService)
        {
            _StoreService = StoreService;
        }
        public StoreController()
        { }

        public ActionResult InComing(int page = 1)
        {
            int PageSize = 10;
            var store = _StoreService.GetAll(0);
            StoreListViewModel model = new StoreListViewModel
            {
                OrderInStore = store,
                PageCount = (int)(Math.Ceiling(store.Count / (double)PageSize)),
                PageSize = PageSize,
                CurrentPage = page
            };

            return View(model);
        }

        public ActionResult Processing(int page = 1)
        {
            int PageSize = 10;
            var store = _StoreService.GetAll(0);
            StoreListViewModel model = new StoreListViewModel
            {
                OrderInStore = store,
                PageCount = (int)(Math.Ceiling(store.Count / (double)PageSize)),
                PageSize = PageSize,
                CurrentPage = page
            };

            return View(model);
        }

        public ActionResult Done(int page = 1)
        {
            int PageSize = 10;
            var store = _StoreService.GetAll(0);
            StoreListViewModel model = new StoreListViewModel
            {
                OrderInStore = store,
                PageCount = (int)(Math.Ceiling(store.Count / (double)PageSize)),
                PageSize = PageSize,
                CurrentPage = page
            };

            return View(model);
        }

        public ActionResult InProcess(int ID)
        {
            Store store = _StoreService.Get(ID);
            store.IsProcessing = true;
            _StoreService.Update(store);
            return RedirectToAction("Processing","Store");
        }

        public ActionResult Delete(int ID)
        {
            Store store = _StoreService.Get(ID);
            _StoreService.Delete(store);

            return RedirectToAction("InComing", "Store");
        }

        public ActionResult InDone(int ID)
        {
            Store store = _StoreService.Get(ID);
            store.IsDone = true;
            _StoreService.Update(store);

            return RedirectToAction("Done", "Store");
        }
    }
}