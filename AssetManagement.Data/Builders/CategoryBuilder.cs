using AssetManagement.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Data.Builders
{
    public class CategoryBuilder
    {
        public CategoryBuilder(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        }
    }
}
