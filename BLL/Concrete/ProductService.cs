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
    public class ProductService : IProductService
    {
        private IProductDAL _ProductDAL;

        public ProductService(IProductDAL ProductDAL)
        {
            _ProductDAL = ProductDAL;
        }

        public void Add(Products entity)
        {
            _ProductDAL.Add(entity);
        }

        public void Delete(Products entity)
        {
            _ProductDAL.Delete(entity);
        }

        public Products Get(int ID)
        {
            return _ProductDAL.Get(x => x.ID == ID);
        }

        public List<Products> GetAll(int ID)
        {
            return ID == 0
                ? _ProductDAL.GetAll(null)
                : _ProductDAL.GetAll(x => x.CategoryID == ID);
        }

        public void Update(Products entity)
        {
            _ProductDAL.Update(entity);
        }
    }
}
