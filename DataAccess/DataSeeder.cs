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
                new Actor() {Id = 1, Name = "Leonardo DiCaprio", DateOfBirth = new DateTime(1974, 11, 11)},
                new Actor() {Id = 2, Name = "Johnny Depp", DateOfBirth = new DateTime(1963, 6, 9)},
                new Actor() {Id = 3, Name = "Steve Carell", DateOfBirth = new DateTime(1962, 8, 16)},
                new Actor() {Id = 4, Name = "Millie Bobby Brown", DateOfBirth = new DateTime(2004, 2, 19)},
                new Actor() {Id = 5, Name = "Justin Roiland", DateOfBirth = new DateTime(1980, 2, 21)},
                new Actor() {Id = 6, Name = "Auli'i Cravalho", DateOfBirth = new DateTime(2000, 11, 22)},
                new Actor() {Id = 7, Name = "Craig T. Nelson", DateOfBirth = new DateTime(1944, 4, 4)},
                new Actor() {Id = 8, Name = "Edward Asner", DateOfBirth = new DateTime(1929, 11, 15)},
                new Actor() {Id = 9, Name = "Jennifer Hale", DateOfBirth = new DateTime(1972, 1, 1)},
                new Actor() {Id = 10, Name = "Charlie Hunnam", DateOfBirth = new DateTime(1980, 4, 10)},
                new Actor() {Id = 11, Name = "Henry Cavill", DateOfBirth = new DateTime(1983, 5, 5)},
                new Actor() {Id = 12, Name = "Gregory Peck", DateOfBirth = new DateTime(1916, 4, 5)},
                new Actor() {Id = 13, Name = "Tom Hardy", DateOfBirth = new DateTime(1977, 9, 15)},
                new Actor() {Id = 14, Name = "Daniel Radcliffe", DateOfBirth = new DateTime(1989, 7, 23)},
                new Actor() {Id = 15, Name = "John Travolta", DateOfBirth = new DateTime(1954, 2, 18)},
                new Actor() {Id = 16, Name = "Tim Robbins", DateOfBirth = new DateTime(1958, 10, 16)},
                new Actor() {Id = 17, Name = "Matthew McConaughey", DateOfBirth = new DateTime(1969, 11, 4)},
                new Actor() {Id = 18, Name = "Robert Downey Jr.", DateOfBirth = new DateTime(1965, 4, 4)},
                new Actor() {Id = 19, Name = "Marlon Brando", DateOfBirth = new DateTime(1924, 4, 3)},
                new Actor() {Id = 20, Name = "Bryce Dallas Howard", DateOfBirth = new DateTime(1981, 3, 2)},
                new Actor() {Id = 21, Name = "Bryan Cranston", DateOfBirth = new DateTime(1956, 3, 7)},
                new Actor() {Id = 22, Name = "Kit Harington", DateOfBirth = new DateTime(1986, 12, 26)},
                new Actor() {Id = 23, Name = "Emilia Clarke", DateOfBirth = new DateTime(1986, 10, 23)},
                new Actor() {Id = 24, Name = "Liam Neeson", DateOfBirth = new DateTime(1952, 6, 7)},
                new Actor() {Id = 25, Name = "Gal Gadot", DateOfBirth = new DateTime(1985, 4, 30)}

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
                    ReleaseDate = new DateTime(2021,1,1)},
                new Content(){Id = 2,Name = "Charlie and the Chocolate Factory", ContentCategoryId = 1, NumberOfSubscribers = 0,
                    ReleaseDate = new DateTime(2005,1,1)},
                new Content() {Id = 3, Name = "The Office", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2005, 3, 24)},
                new Content() {Id = 4, Name = "Stranger Things", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2016, 7, 15)},
                new Content() {Id = 5, Name = "Rick and Morty", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2013, 12, 2)},
                new Content() {Id = 6, Name = "Moana", ContentCategoryId = 3, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2016, 11, 23)},
                new Content() {Id = 7, Name = "The Incredibles", ContentCategoryId = 3, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2004, 11, 5)},
                new Content() {Id = 8, Name = "Up", ContentCategoryId = 3, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2009, 5, 29)},
                new Content() {Id = 9, Name = "Mass Effect Legendary Edition", ContentCategoryId = 4, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2021, 5, 14)},
                new Content() {Id = 10, Name = "The Legend of Zelda: Breath of the Wild", ContentCategoryId = 4, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2017, 3, 3)},
                new Content() {Id = 11, Name = "The Witcher 3: Wild Hunt", ContentCategoryId = 4, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2015, 5, 19)},
                new Content() {Id = 12, Name = "To Kill a Mockingbird", ContentCategoryId = 5, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1960, 7, 11)},
                new Content() {Id = 13, Name = "1984", ContentCategoryId = 5, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1949, 6, 8)},
                new Content() {Id = 14, Name = "Harry Potter and the Philosopher's Stone", ContentCategoryId = 5, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1997, 6, 26)},
                new Content() {Id = 15, Name = "Pulp Fiction", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1994, 10, 14)},
                new Content() {Id = 16, Name = "The Shawshank Redemption", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1994, 9, 23)},
                new Content() {Id = 17, Name = "Interstellar", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2014, 11, 5)},
                new Content() {Id = 18, Name = "Avengers: Endgame", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2019, 4, 26)},
                new Content() {Id = 19, Name = "The Godfather", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1972, 3, 24)},
                new Content() {Id = 20, Name = "Black Mirror", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2011, 12, 4)},
                new Content() {Id = 21, Name = "Breaking Bad", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2008, 1, 20)},
                new Content() {Id = 22, Name = "Game of Thrones", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2011, 4, 17)},
                new Content() {Id = 23, Name = "Finding Nemo", ContentCategoryId = 3, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2003, 5, 30)},
                new Content() {Id = 24, Name = "Toy Story", ContentCategoryId = 3, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1995, 11, 22)},
                new Content() {Id = 25, Name = "Frozen", ContentCategoryId = 3, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2013, 11, 27)},
                new Content() {Id = 26, Name = "Red Dead Redemption 2", ContentCategoryId = 4, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2018, 10, 26)},
                new Content() {Id = 27, Name = "The Elder Scrolls V: Skyrim", ContentCategoryId = 4, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2011, 11, 11)},
                new Content() {Id = 28, Name = "Minecraft", ContentCategoryId = 4, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2011, 11, 18)},
                new Content() {Id = 30, Name = "The Great Gatsby", ContentCategoryId = 5, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1925, 4, 10)},
                new Content() {Id = 31, Name = "The Hangover", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2009, 6, 5)},
                new Content() {Id = 32, Name = "La La Land", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2016, 12, 9)},
                new Content() {Id = 33, Name = "Inception", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2010, 7, 16)},
                new Content() {Id = 34, Name = "The Notebook", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2004, 6, 25)},
                new Content() {Id = 35, Name = "The Big Bang Theory", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2007, 9, 24)},
                new Content() {Id = 36, Name = "Friends", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1994, 9, 22)},
                new Content() {Id = 37, Name = "Star Wars: Episode IV - A New Hope", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1977, 5, 25)},
                new Content() {Id = 38, Name = "Star Wars: Episode V - The Empire Strikes Back", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1980, 5, 17)},
                new Content() {Id = 39, Name = "Star Wars: Episode VI - Return of the Jedi", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1983, 5, 25)},
                new Content() {Id = 40, Name = "Star Wars: Episode I - The Phantom Menace", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(1999, 5, 19)},
                new Content() {Id = 41, Name = "Star Wars: Episode II - Attack of the Clones", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2002, 5, 16)},
                new Content() {Id = 42, Name = "Star Wars: Episode III - Revenge of the Sith", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2005, 5, 19)},
                new Content() {Id = 43, Name = "Star Wars: Episode VII - The Force Awakens", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2015, 12, 18)},
                new Content() {Id = 44, Name = "Star Wars: Episode VIII - The Last Jedi", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2017, 12, 15)},
                new Content() {Id = 45, Name = "Star Wars: Episode IX - The Rise of Skywalker", ContentCategoryId = 1, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2019, 12, 20)},
                new Content() {Id = 46, Name = "Star Wars: The Clone Wars", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2008, 8, 15)},
                new Content() {Id = 47, Name = "Star Wars Rebels", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2014, 10, 3)},
                new Content() {Id = 48, Name = "The Mandalorian", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2019, 11, 12)},
                new Content() {Id = 49, Name = "Star Wars: The Bad Batch", ContentCategoryId = 2, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2021, 5, 4)},
                new Content() {Id = 50, Name = "Among Us", ContentCategoryId = 4, NumberOfSubscribers = 0, ReleaseDate = new DateTime(2018, 6, 15)},
            });

            builder.Entity<Content_Actor>().HasData(new[]
            {
                new Content_Actor() {ContentId = 1, ActorId = 1},
                new Content_Actor() {ContentId = 2, ActorId = 2},
                new Content_Actor() {ContentId = 3, ActorId = 3},
                new Content_Actor() {ContentId = 4, ActorId = 4},
                new Content_Actor() {ContentId = 5, ActorId = 5},
                new Content_Actor() {ContentId = 6, ActorId = 6},
                new Content_Actor() {ContentId = 7, ActorId = 7},
                new Content_Actor() {ContentId = 8, ActorId = 8},
                new Content_Actor() {ContentId = 9, ActorId = 9},
                new Content_Actor() {ContentId = 12, ActorId = 12},
                new Content_Actor() {ContentId = 33, ActorId = 13},
                new Content_Actor() {ContentId = 14, ActorId = 14},
                new Content_Actor() {ContentId = 15, ActorId = 15},
                new Content_Actor() {ContentId = 16, ActorId = 16},
                new Content_Actor() {ContentId = 17, ActorId = 17},
                new Content_Actor() {ContentId = 18, ActorId = 18},
                new Content_Actor() {ContentId = 19, ActorId = 19},
                new Content_Actor() {ContentId = 21, ActorId = 21},
                new Content_Actor() {ContentId = 22, ActorId = 22},
                new Content_Actor() {ContentId = 22, ActorId = 23},
                new Content_Actor() {ContentId = 40, ActorId = 24},
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
                
                new Content_Genre(){ContentId = 2, GenreId = 4},
                new Content_Genre(){ContentId = 2, GenreId = 5},
                
                new Content_Genre() { ContentId = 2, GenreId = 1 },
                
                new Content_Genre() { ContentId = 3, GenreId = 2 },
                new Content_Genre() { ContentId = 4, GenreId = 3 },
                new Content_Genre() { ContentId = 4, GenreId = 4 },
                new Content_Genre() { ContentId = 5, GenreId = 1 },
                new Content_Genre() { ContentId = 5, GenreId = 2 },
                new Content_Genre() { ContentId = 6, GenreId = 3 },
                new Content_Genre() { ContentId = 7, GenreId = 1 },
                new Content_Genre() { ContentId = 8, GenreId = 4 },
                new Content_Genre() { ContentId = 9, GenreId = 2 },
                new Content_Genre() { ContentId = 10, GenreId = 3 },
                new Content_Genre() { ContentId = 11, GenreId = 1 },
                new Content_Genre() { ContentId = 12, GenreId = 4 },
                new Content_Genre() { ContentId = 13, GenreId = 2 },
                new Content_Genre() { ContentId = 14, GenreId = 3 },
                new Content_Genre() { ContentId = 15, GenreId = 1 },
                new Content_Genre() { ContentId = 16, GenreId = 2 },
                new Content_Genre() { ContentId = 17, GenreId = 4 },
                new Content_Genre() { ContentId = 18, GenreId = 3 },
                new Content_Genre() { ContentId = 19, GenreId = 1 },
                new Content_Genre() { ContentId = 20, GenreId = 2 },
                new Content_Genre() { ContentId = 21, GenreId = 4 },
                new Content_Genre() { ContentId = 22, GenreId = 3 },
                new Content_Genre() { ContentId = 23, GenreId = 1 },
                new Content_Genre() { ContentId = 24, GenreId = 2 },
                new Content_Genre() { ContentId = 25, GenreId = 3 },
                new Content_Genre() { ContentId = 26, GenreId = 4 },
                new Content_Genre() { ContentId = 27, GenreId = 2 },
                new Content_Genre() { ContentId = 28, GenreId = 1 },
                new Content_Genre() { ContentId = 29, GenreId = 4 },
                new Content_Genre() { ContentId = 30, GenreId = 3 },
                new Content_Genre() { ContentId = 31, GenreId = 2 },
                new Content_Genre() { ContentId = 32, GenreId = 1 },
                new Content_Genre() { ContentId = 33, GenreId = 3 },
                new Content_Genre() { ContentId = 34, GenreId = 4 },
                new Content_Genre() { ContentId = 35, GenreId = 2 },
                new Content_Genre() { ContentId = 36, GenreId = 1 },
                new Content_Genre() { ContentId = 37, GenreId = 4 },
                new Content_Genre() { ContentId = 38, GenreId = 3 },
                new Content_Genre() { ContentId = 39, GenreId = 1 },
                new Content_Genre() { ContentId = 39, GenreId = 5 },
                new Content_Genre() { ContentId = 40, GenreId = 5 }
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
