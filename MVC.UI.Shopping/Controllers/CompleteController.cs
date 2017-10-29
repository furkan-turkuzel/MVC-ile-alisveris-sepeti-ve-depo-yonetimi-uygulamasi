using BLL.Abstract;
using Models.Entities;
using MVC.UI.Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Shopping.Controllers
{
    public class CompleteController : Controller
    {
        private IOrderService _OrderService;
        private IOrderDetailService _OrderDetailService;
        private ICustomerService _CustomerService;
        private IStoreService _StoreService;
        private IBasketService _BasketService;
        private IProductService _ProductService;

        public CompleteController(IOrderService OrderService, IOrderDetailService OrderDetailService, ICustomerService CustomerService, IStoreService StoreService, IBasketService BasketService, IProductService ProductService)
        {
            _OrderService = OrderService;
            _OrderDetailService = OrderDetailService;
            _CustomerService = CustomerService;
            _StoreService = StoreService;
            _BasketService = BasketService;
            _ProductService = ProductService;
        }
        public ActionResult Complete()
        {
            CustomerViewModel model = new CustomerViewModel
            {
                Customers = new Customers()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complete(CustomerViewModel model)
        {
            List<OrderDetails> list = new List<OrderDetails>();
            var basket = _BasketService.Get();
            if (ModelState.IsValid)
            {
                try
                {
                    Customers customer = new Customers();
                    customer.FirstName = model.Customers.FirstName;
                    customer.LastName = model.Customers.LastName;
                    customer.Email = model.Customers.Email;
                    customer.Address = model.Customers.Address;
                    var Customer = _CustomerService.Add(customer);

                    Orders orders = new Orders();
                    orders.CustomerID = Customer.ID;
                    orders.Customer = customer;
                    orders.OrderDate = DateTime.Now;
                    orders.Total = basket.Total;
                    orders.IsActive = true;
                    _OrderService.Add(orders);

                    foreach (var item in basket.AddedProducts)
                    {
                        OrderDetails orderDetail = new OrderDetails();
                        orderDetail.ProductID = item.Product.ID;
                        orderDetail.Product = _ProductService.Get(item.Product.ID);
                        orderDetail.OrderID = orders.ID;
                        orderDetail.Order = _OrderService.Get(orders.ID);
                        orderDetail.UnitPrice = item.Product.UnitPrice;
                        orderDetail.Quantity = item.Quantity;
                        _OrderDetailService.Add(orderDetail);

                        list.Add(orderDetail);

                        Store store = new Store();
                        store.OrderDetailID = orderDetail.ID;
                        store.OrderDetail = orderDetail;
                        store.IsDone = false;
                        store.IsProcessing = false;
                        _StoreService.Add(store);
                    }
                    Session["OrderDetails"] = list;
                    _BasketService.Set(null);

                    TempData.Add("complete", "complete");
                    TempData.Add("message", string.Format("Siparişiniz başarıyla depoya yollanmıştır."));
                    TempData.Add("status", "success");
                }
                catch (Exception ex)
                {
                    TempData.Add("message", string.Format("Bir hata oluştu : {0}",ex));
                    TempData.Add("status", "danger");
                }
            }
            else
            {
                TempData.Add("message", string.Format("Lütfen bütün bilgileri eksiksiz doldurunuz."));
                TempData.Add("status", "warning");
            }

            return View();
        }
    }
}