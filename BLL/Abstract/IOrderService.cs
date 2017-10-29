using Core.Entites;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IOrderService
    {
        void Add(Orders entity);
        void Delete(Orders entity);
        void Update(Orders entity);
        Orders Get(int ID);
        List<Orders> GetAll(int ID);
    }
}
