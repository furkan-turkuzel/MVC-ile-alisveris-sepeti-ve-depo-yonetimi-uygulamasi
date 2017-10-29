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
    public class OrderService : IOrderService
    {
        private IOrderDAL _OrderDAL;

        public OrderService(IOrderDAL OrderDAL)
        {
            _OrderDAL = OrderDAL;
        }

        public void Add(Orders entity)
        {
            var order = _OrderDAL.GetAll();
            
            _OrderDAL.Add(entity);
        }

        public void Delete(Orders entity)
        {
            _OrderDAL.Delete(entity);
        }

        public Orders Get(int ID)
        {
            return _OrderDAL.Get(x => x.ID == ID);
        }

        public List<Orders> GetAll(int ID)
        {
            return _OrderDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Orders entity)
        {
            _OrderDAL.Update(entity);
        }
    }
}
