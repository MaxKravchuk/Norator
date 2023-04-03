using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.NickName)
                .HasMaxLength(16)
                .IsRequired();

            builder
                .HasIndex(x=>x.NickName)
                .IsUnique();

            builder
                .Property(x => x.Password)
                .HasMaxLength(16)
                .IsRequired();

            builder
                .Property(x => x.UserType)
                .IsRequired();
        }
    }
}
