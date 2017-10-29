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
    public class CategoryService : ICategoryService
    {
        private ICategoryDAL _CategoryDAL;

        public CategoryService(ICategoryDAL CategoryDAL)
        {
            _CategoryDAL = CategoryDAL;
        }

        public void Add(Categories entity)
        {
            _CategoryDAL.Add(entity);
        }

        public void Delete(Categories entity)
        {
            _CategoryDAL.Delete(entity);
        }

        public Categories Get(int ID)
        {
            return _CategoryDAL.Get(x => x.ID == ID);
        }

        public List<Categories> GetAll(int ID)
        {
            return ID == 0
                ? _CategoryDAL.GetAll(null)
                : _CategoryDAL.GetAll(x => x.ID == ID);
        }

        public void Update(Categories entity)
        {
            _CategoryDAL.Update(entity);
        }
    }
}
