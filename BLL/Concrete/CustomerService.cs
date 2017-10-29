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
    public class CustomerService : ICustomerService
    {
        private ICustomerDAL _CustomerDAL;

        public CustomerService(ICustomerDAL CustomerDAL)
        {
            _CustomerDAL = CustomerDAL;
        }

        public Customers Add(Customers entity)
        {
            try
            {
                var customer = _CustomerDAL.GetAll();
                var IsThere = (from c in customer where c.Email == entity.Email && c.FirstName == entity.FirstName && c.LastName == entity.LastName select c.ID).FirstOrDefault();
                if (IsThere == 0)
                {
                   _CustomerDAL.Add(entity);
                    return entity;
                }
                else
                {
                    return Get(IsThere);
                }
            }
            catch (Exception)
            {
                return entity;
            }
            
        }

        public void Delete(Customers entity)
        {
            _CustomerDAL.Delete(entity);
        }

        public Customers Get(int ID)
        {
            return _CustomerDAL.Get(x => x.ID == ID);
        }

        public List<Customers> GetAll(int ID)
        {
            return _CustomerDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Customers entity)
        {
            _CustomerDAL.Update(entity);
        }
    }
}
