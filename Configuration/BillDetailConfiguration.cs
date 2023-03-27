using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASS_MVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASS_MVC.Configuration
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p=>p.Quantity).IsRequired().
                HasColumnType("int");
            // Set khóa ngoại
            builder.HasOne(p=>p.Bill).WithMany(p => p.BillDetails).
                HasForeignKey(p=>p.IdHD).HasConstraintName("FK_HD");
            builder.HasOne(p => p.Product).WithMany(p => p.BillDetails).
                HasForeignKey(p => p.IdSP).HasConstraintName("FK_SP");
        }
    }
}