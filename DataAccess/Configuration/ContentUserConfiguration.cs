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
    public class ContentUserConfiguration : IEntityTypeConfiguration<User_Content>
    {
        public void Configure(EntityTypeBuilder<User_Content> builder)
        {
            builder
                .HasKey(x => new
                {
                    x.UserId,
                    x.ContentId
                });

            builder
                .HasOne<Content>(x => x.Content)
                .WithMany(cont => cont.User_Contents)
                .HasForeignKey(x => x.ContentId);

            builder
                .HasOne<User>(x => x.User)
                .WithMany(cont => cont.User_Contents)
                .HasForeignKey(x => x.UserId);
        }
    }
}
