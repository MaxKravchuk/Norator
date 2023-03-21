using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class NoratorContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Content_Actor> ContentActors { get; set; }
        public DbSet<Content_Genre> ContentGenres{ get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Content> UserContents { get; set; }
        public DbSet<ExceptionEntity> Exceptions { get; set; }

        public NoratorContext(DbContextOptions<NoratorContext> options) : base(options) 
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            builder.SeedData();
        }


    }
}
