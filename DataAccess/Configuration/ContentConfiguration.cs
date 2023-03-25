using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.ContentCategoryId)
                .IsRequired();

            builder
                .Property(x => x.ReleaseDate)
                .IsRequired();

            builder
                .HasOne<ContentCategory>(content=>content.ContentCategory)
                .WithMany(contentType=>contentType.Contents)
                .HasForeignKey(content=>content.ContentCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
