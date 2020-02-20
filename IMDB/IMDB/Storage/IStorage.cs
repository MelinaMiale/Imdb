using Proyect_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Role> GetAllRols();
        public void SaveRol(Role newOrEditedRol, int movieId, int actorId);
        public long SetRolID();
        public Role GetRolById(long id);
        public void DeleteRol(Role rol, int movieId);

    }


}
