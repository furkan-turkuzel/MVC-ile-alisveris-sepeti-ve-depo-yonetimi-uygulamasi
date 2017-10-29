using Core.Entites;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IProductService
    {
        void Add(Products entity);
        void Delete(Products entity);
        void Update(Products entity);
        Products Get(int ID);
        List<Products> GetAll(int ID);
    }
}
