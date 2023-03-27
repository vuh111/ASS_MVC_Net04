using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASS_MVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASS_MVC.Configuration
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
             builder.HasKey(x => x.Id);
            builder.HasOne(p=>p.Cart).WithMany(p=>p.CartDetails).
                HasForeignKey(p=>p.UserId);
            builder.HasOne(p => p.Product).WithMany(p => p.CartDetails).
                HasForeignKey(p => p.IdSP);
        }
    }
}