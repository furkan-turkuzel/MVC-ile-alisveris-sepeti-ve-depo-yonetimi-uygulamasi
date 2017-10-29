using Core.Entites;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IOrderDetailService
    {
        void Add(OrderDetails entity);
        void Delete(OrderDetails entity);
        void Update(OrderDetails entity);
        OrderDetails Get(int ID);
        List<OrderDetails> GetAll(int ID);
    }
}
