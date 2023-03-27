using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASS_MVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASS_MVC.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.RoleId);
            builder.Property(p => p.RoleName).HasColumnType("varchar(100)");
            builder.Property(p=>p.Description).HasColumnType("nvarchar(1000)");
        }
    }
}