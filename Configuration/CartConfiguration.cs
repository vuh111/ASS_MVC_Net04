using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASS_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASS_MVC.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
             builder.HasKey(p => p.UserId);
            builder.Property(p => p.Description).
            HasColumnType("nvarchar(100)");
        }
    }
}