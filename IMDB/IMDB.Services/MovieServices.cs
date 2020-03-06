using IMDB.EntityModels;
using IMDB.Services.Contacts;
using IMDB.Services.Contacts.Dto;
using IMDB.Services.Mapping;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.Services
{
    public class MovieServices : IMovieService
    {
        private ISession session;
        private IEntityMapper<Movie, MovieDto> movieMapper;

        public MovieServices(ISession session, IEntityMapper<Movie, MovieDto> movieMapper)
        {
            this.session = session;
            this.movieMapper = movieMapper;
        }

        public IEnumerable<MovieDto> GetAllMovies()
        {
            var movies = this.session.Query<Movie>().ToList();
            var moviesDtos = movies.Select(movie => this.movieMapper.ToDto(movie, new MovieDto()));

            return moviesDtos;
        }

        public MovieDto GetMovieById(long idMovie)
        {
            var movie = this.session.Get<Movie>(idMovie);
            var movieDto = this.movieMapper.ToDto(movie, new MovieDto());

            return movieDto;
        }

        public long SaveMovie(MovieDto newmoviedto)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                //paso de dto a entity
                var movie = this.movieMapper.ToModel(newmoviedto, new Movie());

                //guardo en db
                this.session.Save(movie);
                this.session.Transaction.Commit();

                return movie.Id;
            }
        }
    }
}
