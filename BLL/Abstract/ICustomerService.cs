using Core.Entites;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ICustomerService
    {
        Customers Add(Customers entity);
        void Delete(Customers entity);
        void Update(Customers entity);
        Customers Get(int ID);
        List<Customers> GetAll(int ID);
    }
}
