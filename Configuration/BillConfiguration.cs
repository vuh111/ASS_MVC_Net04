using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASS_MVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASS_MVC.Configuration
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("HoaDon"); // Đặt tên bảng
            builder.HasKey(p => new {p.Id});// Thiết lập khóa chính
            // Thiết lập cho các thuộc tính
            builder.Property(p=>p.Status).HasColumnType("int").
                IsRequired(); // int not null
            builder.HasOne(p => p.User).WithMany(p => p.Bills).HasForeignKey(p=>p.UserId);
        }
    }
}