using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mapping
{
    public class CategoriesMapping : EntityTypeConfiguration<Categories>
    {
        public CategoriesMapping()
        {
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.CategoryName)
                .HasMaxLength(50)
                .IsRequired();
    }
    }
}
