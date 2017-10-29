using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IBasketService
    {
        void AddToBasket(Basket basket, Products product);
        void RemoveToBasket(Basket basket, Products products);
        List<AddedProduct> GetList(Basket basket);
        Basket Get();
        void Set(Basket basket);
    }
}
