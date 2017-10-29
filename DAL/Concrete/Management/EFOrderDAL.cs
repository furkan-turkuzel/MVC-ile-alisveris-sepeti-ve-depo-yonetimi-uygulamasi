using Core.DataAccess.EntityFramework;
using DAL.Abstract;
using DAL.Concrete.DBContext;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Management
{
    public class EFOrderDAL : EFEntityRepositoryBase<TrendyolDBContext, Orders>,IOrderDAL
    {
    }
}
