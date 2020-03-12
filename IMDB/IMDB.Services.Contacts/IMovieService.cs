using IMDB.Services.Contacts.Dto;
using System;
using System.Collections.Generic;

namespace IMDB.Services.Contacts
{
    public interface IMovieService
    {
        IEnumerable<MovieDto> GetAllMovies();

        MovieDto GetMovieById(long idMovie);

        long SaveMovie(MovieDto newMovie);

        long UpdateMovie(MovieDto editedMovie);

        bool RemoveMovie(long movieId);
    }
}
