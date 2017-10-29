using Core.Entites;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IStoreService
    {
        void Add(Store entity);
        void Delete(Store entity);
        void Update(Store entity);
        Store Get(int? ID);
        Store GetByOrderDetailID(int ID);
        List<Store> GetAll(int ID);
    }
}
