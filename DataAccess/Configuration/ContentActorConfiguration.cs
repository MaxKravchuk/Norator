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
    public class ContentActorConfiguration : IEntityTypeConfiguration<Content_Actor>
    {
        public void Configure(EntityTypeBuilder<Content_Actor> builder)
        {
            builder
                .HasKey(x => new
                {
                    x.ActorId,
                    x.ContentId
                });

            builder
                .HasOne<Content>(x => x.Content)
                .WithMany(cont => cont.Content_Actors)
                .HasForeignKey(x => x.ContentId);

            builder
                .HasOne<Actor>(x => x.Actor)
                .WithMany(cont => cont.Content_Actors)
                .HasForeignKey(x => x.ActorId);
        }
    }
}
