using IMDB.EntityModels;
using IMDB.Services.Contacts.Dto;
using System;
using System.Collections.Generic;

namespace IMDB.Services.Contacts
{
    public interface IMovieService
    {
        IEnumerable<MovieDto> GetAllMovies();

        MovieDto GetMovieById(long idMovie);

        public long SaveMovie(MovieDto newMovie);
    }
}
