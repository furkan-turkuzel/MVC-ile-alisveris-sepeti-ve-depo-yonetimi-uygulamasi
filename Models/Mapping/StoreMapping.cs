using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mapping
{
    public class StoreMapping : EntityTypeConfiguration<Store>
    {
        public StoreMapping()
        {
            HasKey(x => x.ID);

            HasRequired(x => x.OrderDetail)
                .WithMany(x => x.Store)
                .HasForeignKey(x => x.OrderDetailID)
                .WillCascadeOnDelete(true);
        }
    }
}
