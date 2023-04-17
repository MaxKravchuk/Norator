using Application.Services;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Paginator.Parameters;
using Core.Paginator;
using log4net.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Test
{
    public class ContentServiceTests
    {
        private readonly Mock<IContentRepository> _contentRepositoryMock;
        private readonly Mock<ILoggerManager> _loggerManagerMock;
        private readonly ContentService _contentService;
        private readonly Mock<IContentCategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IActorService> _actorServiceMock;
        private readonly Mock<IGenreService> _genreServiceMock;
        private readonly Mock<IContent_GenreRepository> _content_GenreRepositoryMock;
        private readonly Mock<IContent_ActorRepository> _content_ActorRepositoryMock;

        public ContentServiceTests()
        {
            _contentRepositoryMock = new Mock<IContentRepository>();
            _loggerManagerMock = new Mock<ILoggerManager>();
            _categoryRepositoryMock = new Mock<IContentCategoryRepository>();
            _actorServiceMock = new Mock<IActorService>();
            _genreServiceMock = new Mock<IGenreService>();
            _content_GenreRepositoryMock = new Mock<IContent_GenreRepository>();
            _content_ActorRepositoryMock = new Mock<IContent_ActorRepository>();
            _contentService = new ContentService(
                _contentRepositoryMock.Object,
                _categoryRepositoryMock.Object,
                _actorServiceMock.Object,
                _genreServiceMock.Object,
                _content_GenreRepositoryMock.Object,
                _content_ActorRepositoryMock.Object,
                _loggerManagerMock.Object);
        }

        [Fact]
        public async Task CreateGameAsync_ShouldCreateAndLog()
        {
            // Arrange
            var content = new Content { Name = "Test Content" };
            var actorsId = new List<int> { 1, 2, 3 };
            var genresId = new List<int> { 4, 5 };

            _actorServiceMock.Setup(s => s.GetActorByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Actor { Id = 1, Name = "Actor 1" }); // mock GetActorByIdAsync method

            _genreServiceMock.Setup(s => s.GetGenreByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Genre { Id = 4, Name = "Genre 4" }); // mock GetGenreByIdAsync method

            _contentRepositoryMock.Setup(r => r.InsertAsync(It.IsAny<Content>()))
                .Callback<Content>(c => c.Id = 1) // set the Id property to 1 after insertion
                .Returns(Task.CompletedTask);

            // Act
            await _contentService.CreateContentAsync(content, actorsId, genresId);

            // Assert
            _contentRepositoryMock.Verify(r => r.InsertAsync(content), Times.Once);
            _contentRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(l => l.LogInfo(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task DeleteContentAsync_ShouldDeleteAndLog()
        {
            // Arrange
            int contentIdToDelete = 1;
            var content = new Content { Id = contentIdToDelete };

            _contentRepositoryMock
                .Setup(x => x
                    .GetByIdAsync(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(content);

            _contentRepositoryMock
                .Setup(x => x
                    .Delete(It.IsAny<Content>())).Verifiable();

            // Act
            await _contentService.DeleteContentAsync(contentIdToDelete);

            // Assert
            _contentRepositoryMock.Verify(x => x.Delete(It.IsAny<Content>()), Times.Once);
            _contentRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(x => x.LogInfo($"Deleting content {contentIdToDelete} successful"), Times.Once);
        }

        [Fact]
        public async Task GetContentByIdAsync_ShouldReturnContent_WhenContentExists()
        {
            // Arrange
            var content = new Content
            {
                Id = 1,
                Name = "Test Content",
                ContentCategory = new ContentCategory
                {
                    Id = 1,
                    Name = "Test Category"
                },
                Content_Actors = new List<Content_Actor>
                {
                    new Content_Actor
                    {
                        ContentId = 1,
                        Actor = new Actor
                        {
                            Id = 1,
                            Name = "Test Actor 1"
                        }
                    },
                    new Content_Actor
                    {
                        ContentId = 1,
                        Actor = new Actor
                        {
                            Id = 2,
                            Name = "Test Actor 2"
                        }
                    }
                },
                Content_Genres = new List<Content_Genre>
                {
                    new Content_Genre
                    {
                        ContentId = 1,
                        Genre = new Genre
                        {
                            Id = 1,
                            Name = "Test Genre 1"
                        }
                    },
                    new Content_Genre
                    {
                        ContentId = 1,
                        Genre = new Genre
                        {
                            Id = 2,
                            Name = "Test Genre 2"
                        }
                    }
                }
            };

            _contentRepositoryMock.Setup(x => x.GetByIdAsync(content.Id, "Content_Actors.Actor,Content_Genres.Genre,ContentCategory"))
                .ReturnsAsync(content);

            // Act
            var result = await _contentService.GetContentByIdAsync(content.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(content.Id, result.Id);
            Assert.Equal(content.Name, result.Name);
            Assert.Equal(content.ContentCategory.Id, result.ContentCategory.Id);
            Assert.Equal(content.ContentCategory.Name, result.ContentCategory.Name);
            Assert.Equal(content.Content_Actors.Count, result.Content_Actors.Count);
            Assert.Equal(content.Content_Genres.Count, result.Content_Genres.Count);
            Assert.Equal(content.Content_Actors.Select(x => x.Actor.Id), result.Content_Actors.Select(x => x.Actor.Id));
            Assert.Equal(content.Content_Genres.Select(x => x.Genre.Id), result.Content_Genres.Select(x => x.Genre.Id));

            _contentRepositoryMock.Verify(x => x.GetByIdAsync(content.Id, "Content_Actors.Actor,Content_Genres.Genre,ContentCategory"), Times.Once);
        }

        [Fact]
        public async Task GetContentsAsync_ReturnsPagedListOfContents()
        {
            // Arrange
            var contentParameters = new ContentParameters
            {
                PageNumber = 1,
                PageSize = 10,
                FilterParam = "Drama"
            };

            var contents = new List<Content>
            {
                new Content { Id = 1, Name = "Content 1", ContentCategory = new ContentCategory { Id = 1, Name = "Drama" } },
                new Content { Id = 2, Name = "Content 2", ContentCategory = new ContentCategory { Id = 2, Name = "Action" } }
            };

            _contentRepositoryMock
                .Setup(repo => repo
                    .GetAllAsync(
                        It.IsAny<ContentParameters>(),
                        It.IsAny<Expression<Func<Content, bool>>>(),
                        It.IsAny<Func<IQueryable<Content>, IOrderedQueryable<Content>>>(),
                        It.IsAny<Func<IQueryable<Content>, IIncludableQueryable<Content, object>>>()))
                .ReturnsAsync(new PagedList<Content>(contents, contents.Count, contentParameters.PageNumber, contentParameters.PageSize));

            // Act
            var result = await _contentService.GetContentsAsync(contentParameters);

            // Assert
            Assert.IsType<PagedList<Content>>(result);
            Assert.Equal(2, result.TotalCount);
            Assert.Equal("Content 1", result.First().Name);
            Assert.Equal("Drama", result.First().ContentCategory.Name);
            _contentRepositoryMock.Verify(repo => repo.GetAllAsync(
                It.IsAny<ContentParameters>(),
                        It.IsAny<Expression<Func<Content, bool>>>(),
                        It.IsAny<Func<IQueryable<Content>, IOrderedQueryable<Content>>>(),
                        It.IsAny<Func<IQueryable<Content>, IIncludableQueryable<Content, object>>>()), Times.Once);
            _loggerManagerMock.Verify(logger => logger.LogInfo(It.IsAny<string>()), Times.Once);
        }
    }
}
