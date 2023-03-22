using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataSeeder
    {
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<Actor>().HasData(new[]
            {
                new Actor(){Id =1, Name = "Jonah Hill", DateOfBirth=new DateTime(1983,12,20)},
                new Actor(){Id =2, Name = "Johnny Depp", DateOfBirth = new DateTime(1963,6,9)}
            });

            builder.Entity<ContentCategory>().HasData(new[]
            {
                new ContentCategory(){Id =1,Name = "Film"},
                new ContentCategory(){Id =2,Name = "Series"},
                new ContentCategory(){Id =3,Name = "Cartoon"},
                new ContentCategory(){Id =4,Name = "Game"},
                new ContentCategory(){Id =5,Name = "Book"}
            });

            builder.Entity<Content>().HasData(new[]
            {
                new Content(){Id = 1,Name = "Don`t Look Up", ContentCategoryId = 1, NumberOfSubscribers = 1,
                    ReleaseDate = new DateTime(2021)},
                new Content(){Id = 2,Name = "Charlie and the Chocolate Factory", ContentCategoryId = 1, NumberOfSubscribers = 0,
                    ReleaseDate = new DateTime(2005)}
            });

            builder.Entity<Content_Actor>().HasData(new[]
            {
                new Content_Actor() {ContentId = 1, ActorId = 1},
                new Content_Actor(){ContentId = 2, ActorId = 2}
            });

            builder.Entity<Genre>().HasData(new[]
            {
                new Genre(){Id = 1,Name = "Comedy"},
                new Genre(){Id = 2,Name = "Drama"},
                new Genre(){Id = 3,Name = "Sci-fi"},
                new Genre(){Id = 4,Name = "Adventure"},
                new Genre(){Id = 5,Name = "Family"},
            });

            builder.Entity<Content_Genre>().HasData(new[]
            {
                new Content_Genre(){ContentId = 1, GenreId = 1},
                new Content_Genre(){ContentId = 1, GenreId = 2},
                new Content_Genre(){ContentId = 1, GenreId = 3},
                new Content_Genre(){ContentId = 2, GenreId = 1},
                new Content_Genre(){ContentId = 2, GenreId = 4},
                new Content_Genre(){ContentId = 2, GenreId = 5},
            });

            builder.Entity<User>().HasData(new[]
            {
                new User(){Id = 1, NickName = "Admin",UserType = Core.Enums.UserType.Admin, Password="123Admin#", DateOfBirth=new DateTime(2002,2,2)},
                new User(){Id = 2, NickName = "Tarakan",UserType = Core.Enums.UserType.Client, Password="123Tarakan#", DateOfBirth=new DateTime(2012,12,12)},
            });

            builder.Entity<User_Content>().HasData(new[]
            {
                new User_Content(){ContentId = 1, UserId = 2}
            });

        }
    }
}
