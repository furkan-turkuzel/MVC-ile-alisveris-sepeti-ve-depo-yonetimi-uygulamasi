using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using System.Web;

namespace BLL.Concrete
{
    public class BasketService : IBasketService
    {
        public IProductService _ProductService;
        public void AddToBasket(Basket basket, Products product)
        {
            try
            {
                AddedProduct addedProduct = basket.AddedProducts.FirstOrDefault(x => x.Product.ID == product.ID);

                if (addedProduct != null)
                {
                    addedProduct.Quantity++;
                }
                else
                {
                    basket.AddedProducts.Add(new AddedProduct { Product = product, Quantity = 1 });
                }
                product.UnitInStock--;
                _ProductService.Update(product);
            }
            catch (Exception)
            {
            }
        }

        public Basket Get()
        {
            Basket checkSession = (Basket)HttpContext.Current.Session["basket"];
            if (checkSession  == null)
            {
                HttpContext.Current.Session["basket"] = new Basket();
                checkSession = (Basket)HttpContext.Current.Session["basket"];
            }
            return checkSession;   
        }

        public List<AddedProduct> GetList(Basket basket)
        {
            return basket.AddedProducts;
        }

        public void RemoveToBasket(Basket basket, Products products)
        {
            try
            {
                basket.AddedProducts.Remove(basket.AddedProducts.FirstOrDefault(x => x.Product.ID == products.ID));
            }
            catch (Exception)
            {
            }
        }

        public void Set(Basket basket)
        {
            HttpContext.Current.Session["basket"] = basket;
        }
    }
}
