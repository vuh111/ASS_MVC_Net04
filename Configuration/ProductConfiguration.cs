using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASS_MVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASS_MVC.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Supplier).IsUnicode(true).
            IsFixedLength().HasMaxLength(100);
        }
    }
}