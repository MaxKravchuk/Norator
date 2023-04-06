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
        private readonly IActorService _actorService;
        private readonly IGenreService _genreService;
        private readonly IContent_GenreRepository _content_GenreRepository;
        private readonly IContent_ActorRepository _content_ActorRepository;

        public ContentService(
            IContentRepository contentRepository,
            IActorService actorService,
            IGenreService genreService,
            IContent_GenreRepository content_GenreRepository,
            IContent_ActorRepository content_ActorRepository
            )
        {
            _contentRepository = contentRepository;
            _actorService = actorService;
            _genreService = genreService;
            _content_ActorRepository = content_ActorRepository;
            _content_GenreRepository = content_GenreRepository;
        }

        public async Task CreateContentAsync(Content content, IEnumerable<int> actorsId, IEnumerable<int> genresId)
        {
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
            await _contentRepository.SaveChangesAsync();
        }

        public async Task DeleteContentAsync(int id)
        {
            var contenttoDelete = await GetContentByIdAsync(id);
            _contentRepository.Delete(contenttoDelete);
            await _contentRepository.SaveChangesAsync();
        }

        public async Task<Content> GetContentByIdAsync(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id,
                includeProperties: "Content_Actors.Actor,Content_Genres.Genre,ContentCategory");

            if (content == null)
            {
                throw new NotFoundException();
            }

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

            return contents;
        }

        public async Task UpdateContentAsync(Content content, IEnumerable<int> actorsId, IEnumerable<int> genresId)
        {
            try
            {
                await UpdateContentPropertiesAsync(content.Id, actorsId, genresId);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            _contentRepository.Update(content);
            await _contentRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Content>> GetTop20ContentAsync()
        {
            var contents = await _contentRepository.GetAsync(orderBy: con => con.OrderByDescending(x => x.NumberOfSubscribers), includeProperties:"ContentCategory");
            var top = contents.Take(20);
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
