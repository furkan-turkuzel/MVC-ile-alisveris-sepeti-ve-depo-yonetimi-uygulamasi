using BLL.Abstract;
using DAL.Concrete.DBContext;
using Models.Entities;
using MVC.UI.Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Shopping.Controllers
{
    public class BasketController : Controller
    {
        private IBasketService _BasketService;
        private IProductService _ProductService;
        private IStoreService _StoreService;
        private IOrderService _OrderService;
        public BasketController(IBasketService BasketService, IProductService ProductService, IStoreService StoreService, IOrderService OrderService)
        {
            _BasketService = BasketService;
            _ProductService = ProductService;
            _StoreService = StoreService;
            _OrderService = OrderService;
        }
        public PartialViewResult Basket()
        {
            BasketSummaryListViewModel model = new BasketSummaryListViewModel
            {
                basket = _BasketService.Get(),
            };
            return PartialView(model);
        }

        
        public ActionResult AddToBasket(int ID)
        {
            var Product = _ProductService.Get(ID);
            var Basket = _BasketService.Get();

            if (Product.UnitInStock != 0)
            {
                _BasketService.AddToBasket(Basket,Product);
                _BasketService.Set(Basket);
                TempData.Add("message", String.Format("{0} isimli ürününüz başarıyla eklenmiştir.", Product.ProductName));
                TempData.Add("status", "success");
            }
            else
            {
                TempData.Add("message", String.Format("{0} isimli ürününüzün ekleme işlemi başarısız olmuştur.Bu üründen stokta bulunmuyor!!!", Product.ProductName));
                TempData.Add("status", "warning");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult List()
        {
            var Basket = _BasketService.Get();
            BasketOrderDetailsViewModel model = new BasketOrderDetailsViewModel
            {
                basket = Basket,
                OrderDetail = (List<OrderDetails>)Session["OrderDetails"]
            };
            return View(model);
        }

        public ActionResult RemoveToBasket(int ID)
        {
            var Product = _ProductService.Get(ID);
            var Basket = _BasketService.Get();
            _BasketService.RemoveToBasket(Basket, Product);
            _BasketService.Set(Basket);
            return RedirectToAction("List","Basket");
        }

        public ActionResult CancelOrder(int ID,BasketOrderDetailsViewModel model)
        {
            Store store = _StoreService.GetByOrderDetailID(ID);
            List<OrderDetails> list = model.OrderDetail;
            if (store.IsProcessing == false)
            {
                Orders orders = (from od in list where od.ID == ID select od.Order).SingleOrDefault();
                orders.IsActive = false;
                _OrderService.Update(orders);
                TempData.Add("message", "Siparişiniz iptal edilmiştir...");
                TempData.Add("status", "success");

            }
            else
            {
                TempData.Add("message", "Siparişiniz işleme alındığı için iptal edilememiştir!!!");
                TempData.Add("status", "danger");
            }

            return RedirectToAction("List", "Basket");
        }

    }
}