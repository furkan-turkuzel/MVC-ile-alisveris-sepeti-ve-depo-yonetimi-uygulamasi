using Core.Entites;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ICategoryService
    {
        void Add(Categories entity);
        void Delete(Categories entity);
        void Update(Categories entity);
        Categories Get(int ID);
        List<Categories> GetAll(int ID);
    }
}
