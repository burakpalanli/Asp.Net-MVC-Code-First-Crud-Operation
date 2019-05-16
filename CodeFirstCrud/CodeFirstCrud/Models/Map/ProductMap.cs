using CodeFirstCrud.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CodeFirstCrud.Models.Map
{
    public class ProductMap :EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Products");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProductName).HasMaxLength(50).IsRequired();
            Property(x => x.Description).HasMaxLength(300).IsRequired();
            Property(x => x.Price).HasColumnName("money").IsRequired();
            Property(x => x.Stock).IsRequired();
        
        }


    }
}