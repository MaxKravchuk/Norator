using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.Paginator.Parameters;
using Core.ViewModels;
using Core.ViewModels.ContentViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContentService : IContenService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IContentCategoryRepository _categoryRepository;
        private readonly IActorService _actorService;
        private readonly IGenreService _genreService;
        private readonly IContent_GenreRepository _content_GenreRepository;
        private readonly IContent_ActorRepository _content_ActorRepository;
        private readonly ILoggerManager _loggerManager;

        public ContentService(
            IContentRepository contentRepository,
            IContentCategoryRepository categoryRepository,
            IActorService actorService,
            IGenreService genreService,
            IContent_GenreRepository content_GenreRepository,
            IContent_ActorRepository content_ActorRepository,
            ILoggerManager loggerManager)
        {
            _contentRepository = contentRepository;
            _categoryRepository = categoryRepository;
            _actorService = actorService;
            _genreService = genreService;
            _content_ActorRepository = content_ActorRepository;
            _content_GenreRepository = content_GenreRepository;
            _loggerManager = loggerManager;
        }

        public async Task CreateContentAsync(Content content, IEnumerable<int> actorsId, IEnumerable<int> genresId)
        {
            if(actorsId.Count() > 10)
            {
                throw new BadRequestException("Maximus 10 actors per content");
            }
            foreach (var actorId in actorsId)
            {
                content.Content_Actors.Add(new Content_Actor()
                {
                    Content = content,
                    Actor = await _actorService.GetActorByIdAsync(actorId)
                });
            }
            foreach (var genreId in genresId)
            {
                content.Content_Genres.Add(new Content_Genre()
                {
                    Content = content,
                    Genre = await _genreService.GetGenreByIdAsync(genreId)
                });
            }

            await _contentRepository.InsertAsync(content);
            try
            {
                await _contentRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Adding content {content.Name} successful");
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Adding content {content.Name} error {ex.Message}");
            }
        }

        public async Task DeleteContentAsync(int id)
        {
            var contenttoDelete = await GetContentByIdAsync(id);
            _contentRepository.Delete(contenttoDelete);
            try
            {
                await _contentRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Deleting content {id} successful");
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Deleting content {id} error {ex.Message}");
            }
        }

        public async Task<Content> GetContentByIdAsync(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id,
                includeProperties: "Content_Actors.Actor,Content_Genres.Genre,ContentCategory");

            
            if (content == null)
            {
                _loggerManager.LogError($"Getting content {id} error. Content is null");
                throw new NotFoundException();
            }

            _loggerManager.LogInfo($"Getting content {id} successful");
            return content;
        }

        public async Task<PagedList<Content>> GetContentsAsync(ContentParameters contentParameters)
        {
            var filterQuery = GetFilterQuery(contentParameters.FilterParam, contentParameters.ActorName);

            var contents = await _contentRepository.GetAllAsync(
                parameters: contentParameters,
                filter: filterQuery,
                includeProperties: q => q
                .Include(c => c.ContentCategory));
            
            _loggerManager.LogInfo($"Getting content array {contents.Count}");

            return contents;
        }

        public async Task UpdateContentAsync(Content content, IEnumerable<int> actorsId, IEnumerable<int> genresId)
        {
            if (actorsId.Count() > 10)
            {
                throw new BadRequestException("Maximus 10 actors per content");
            }
            try
            {
                await UpdateContentPropertiesAsync(content.Id, actorsId, genresId);
                _loggerManager.LogInfo($"Updated content`s properties successful");
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Failed to update content`s properties: {ex.Message}");
                throw new BadRequestException();
            }
            _contentRepository.Update(content);
            try
            {
                await _contentRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Updated content successful");
            }
            catch(Exception ex)
            {
                _loggerManager.LogError($"Failed to update content: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Content>> GetTop20ContentAsync()
        {
            var contents = await _contentRepository.GetAsync(orderBy: con => con.OrderByDescending(x => x.NumberOfSubscribers), includeProperties:"ContentCategory");
            var top = contents.Take(20);

            _loggerManager.LogInfo("Getted top 20 content");

            return top;
        }

        public async Task<IEnumerable<Content>> GetTop20ContentByCategoryAsync(int catId)
        {
            var catogory = await _categoryRepository.GetByIdAsync(catId);
            var contents = await _contentRepository.GetAsync(
                filter: c => c.ContentCategory.Id == catId,
                orderBy: con => con.OrderByDescending(x => x.NumberOfSubscribers), includeProperties: "ContentCategory");
            var top = contents.Take(20);

            _loggerManager.LogInfo("Getted top 20 content by category");

            return top;
        }

        private async Task UpdateContentPropertiesAsync(int contentId, IEnumerable<int> actorsId, IEnumerable<int> genresId)
        {
            var exActors = await _content_ActorRepository.GetAsync(
                filter: con => con.ContentId == contentId);
            var exGenres = await _content_GenreRepository.GetAsync(
                filter: con => con.ContentId == contentId);

            foreach (var actor in exActors)
            {
                _content_ActorRepository.Delete(actor);
            }
            foreach (var genres in exGenres)
            {
                _content_GenreRepository.Delete(genres);
            }

            foreach (var actorId in actorsId)
            {
                await _content_ActorRepository.InsertAsync(new Content_Actor()
                {
                    ContentId = contentId,
                    ActorId = actorId
                });
            }
            foreach (var genreId in genresId)
            {
                await _content_GenreRepository.InsertAsync(new Content_Genre()
                {
                    ContentId = contentId,
                    GenreId = genreId
                });
            }

            await _content_ActorRepository.SaveChangesAsync();
            await _content_GenreRepository.SaveChangesAsync();
        }
        private static Expression<Func<Content, bool>>? GetFilterQuery(string? filterParam, string? ActorName)
        {
            Expression<Func<Content, bool>>? filterQuery = null;

            if (filterParam is not null && ActorName is not null)
            {
                throw new ForbidException();
            }

            if (filterParam is not null)
            {
                string formatedFilter = filterParam.Trim().ToLower();

                filterQuery = u => u.Name!.ToLower().Contains(formatedFilter);
            }
            else if(ActorName is not null)
            {
                string ActorNameT = ActorName.Trim().ToLower();

                filterQuery = u => u.Content_Actors.Any(c => c.Actor.Name.ToLower().Contains(ActorNameT));
            }

            return filterQuery;
        }
    }
}
