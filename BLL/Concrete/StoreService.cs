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
    public class StoreService : IStoreService
    {
        private IStoreDAL _StoreDAL;

        public StoreService(IStoreDAL StoreDAL)
        {
            _StoreDAL = StoreDAL;
        }

        public void Add(Store entity)
        {
            _StoreDAL.Add(entity);
        }

        public void Delete(Store entity)
        {
            _StoreDAL.Delete(entity);
        }

        public Store Get(int? ID)
        {
            return _StoreDAL.Get(x => x.ID == ID);
        }

        public List<Store> GetAll(int ID)
        {
            return ID == 0
                 ? _StoreDAL.GetAll(null)
                 : _StoreDAL.GetAll(x => x.ID == ID);
        }

        public Store GetByOrderDetailID(int ID)
        {
            return _StoreDAL.Get(x => x.OrderDetailID == ID);
        }

        public void Update(Store entity)
        {
            _StoreDAL.Update(entity);
        }
    }
}
