using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mapping
{
    public class CustomersMapping : EntityTypeConfiguration<Customers>
    {
        public CustomersMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.LastName)
                .HasMaxLength(40)
                .IsRequired();

            Property(x => x.Address)
                .IsRequired();

            Property(x => x.Email)
                .IsOptional();

            Property(x => x.Password)
                .IsOptional();

        }
    }
}
