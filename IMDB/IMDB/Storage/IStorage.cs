using IMDB.Web.EntityModel;
using System.Collections.Generic;

namespace Repository
{
    public interface IStorage

    {
        //lista todos las peliculas
        public List<Movie> GetAllMovies();

        public Movie GetMovieById(long Id);

        public Movie UpdateMovie(Movie updatedMovie);

        public void SaveMovie(Movie editedMovie);

        public void Delete(Movie deletedMovie);

        public List<Actor> GetAllActors();

        public Actor GetActorbyId(long id);

        public void SaveActor(Actor editedOrNewActor);

        public long SetActorID();

        public void DeleteActor(Actor actorToDelete);

        public List<Character> GetAllRols();

        public void SaveRol(Character newOrEditedRol, int movieId, int actorId);

        public long SetRolID();

        public Character GetRolById(long id);

        public void DeleteRol(Character rol, int movieId);

        public Actor UpdateActor(Actor editedActor);
    }
}
