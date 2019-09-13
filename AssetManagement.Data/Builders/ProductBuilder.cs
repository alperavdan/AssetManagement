using AssetManagement.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Data.Builders
{
   public class ProductBuilder
    {
        public ProductBuilder(EntityTypeBuilder<Product> entityBuilder)

        {

            entityBuilder.HasKey(p => p.Id);

            entityBuilder.Property(p => p.Title).IsRequired().HasMaxLength(200);

            entityBuilder.HasOne(p => p.Category).WithMany(c => c.Products)

            .HasForeignKey(p => p.CategoryId);

        }
    }
}
