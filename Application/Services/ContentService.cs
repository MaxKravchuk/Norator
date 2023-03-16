using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
                includeProperties: "Content_Genres.Genre, Content_Actors.Actor");

            if(content == null)
            {
                throw new NotFoundExeption();
            }

            return content;
        }

        public async Task<Content> GetContentByNameAsync(string name)
        {
            var content = await _contentRepository.GetByNameAsync(name,
                includeProperties: "Content_Genres.Genre, Content_Actors.Actor");

            if (content == null)
            {
                throw new NotFoundExeption();
            }

            return content;
        }

        public async Task<IEnumerable<Content>> GetContentsAsync()
        {
            var contents = await _contentRepository.GetAsync(
                includeProperties: "Content_Genres.Genre, Content_Actors.Actor");

            return contents;
        }

        public async Task UpdateContentAsync(Content content, IEnumerable<int> actorsId, IEnumerable<int> genresId)
        {
            try
            {
                await UpdateContentPropertiesAsync(content, actorsId, genresId);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            _contentRepository.Update(content);
            await _contentRepository.SaveChangesAsync();
        }

        private async Task UpdateContentPropertiesAsync(Content content, IEnumerable<int> actorsId, IEnumerable<int> genresId)
        {
            var exActors = await _content_ActorRepository.GetAsync(
                filter: con => con.ContentId == content.Id);
            var exGenres = await _content_GenreRepository.GetAsync(
                filter: con => con.ContentId == content.Id);

            foreach (var actor in exActors)
            {
                _content_ActorRepository.Delete(actor);
            }
            foreach(var genres in exGenres)
            {
                _content_GenreRepository.Delete(genres);
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

            await _content_ActorRepository.SaveChangesAsync();
            await _content_GenreRepository.SaveChangesAsync();
        }
    }
}
