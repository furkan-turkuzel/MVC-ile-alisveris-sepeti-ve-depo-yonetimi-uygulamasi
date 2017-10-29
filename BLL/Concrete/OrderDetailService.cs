using BLL.Abstract;
using DAL.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class OrderDetailService : IOrderDetailService
    {
        private IOrderDetailDAL _OrderDetailDAL;

        public OrderDetailService(IOrderDetailDAL OrderDetailDAL)
        {
            _OrderDetailDAL = OrderDetailDAL;
        }

        public void Add(OrderDetails entity)
        {
            _OrderDetailDAL.Add(entity);
        }

        public void Delete(OrderDetails entity)
        {
            _OrderDetailDAL.Delete(entity);
        }

        public OrderDetails Get(int ID)
        {
            return _OrderDetailDAL.Get(x => x.ID == ID);
        }

        public List<OrderDetails> GetAll(int ID)
        {
            return _OrderDetailDAL.GetAll(x => x.ID == ID);
        }

        public void Update(OrderDetails entity)
        {
            _OrderDetailDAL.Update(entity);
        }
    }
}
