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
    public class ContentGenreConfiguration : IEntityTypeConfiguration<Content_Genre>
    {
        public void Configure(EntityTypeBuilder<Content_Genre> builder)
        {
            builder
                .HasKey(x => new
                {
                    x.GenreId,
                    x.ContentId
                });

            builder
                .HasOne<Content>(x => x.Content)
                .WithMany(cont => cont.Content_Genres)
                .HasForeignKey(x => x.ContentId);

            builder
                .HasOne<Genre>(x => x.Genre)
                .WithMany(cont => cont.Content_Genres)
                .HasForeignKey(x => x.GenreId);
        }
    }
}
