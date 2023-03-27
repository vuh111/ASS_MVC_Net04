using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASS_MVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASS_MVC.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasColumnType("varchar(256)");
            builder.Property(x => x.Password).HasColumnType("varchar(256)");
            builder.HasOne(p => p.Role).WithMany(p => p.Users).
                HasForeignKey(p=>p.RoleId);
            builder.HasAlternateKey(p => p.Username); 
        }
    }
}