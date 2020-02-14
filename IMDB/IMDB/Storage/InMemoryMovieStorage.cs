using Proyect_Models;
using System;
using System.Collections.Generic;

namespace Repository
{
    //aqui implemento mi interfaz reposity
    public class InMemoryMovieStorage : IStorage

    {

        List<Movie> moviesInStorage = new List<Movie>();

        public InMemoryMovieStorage() {

            //Pelicula 2
            /*Rol rol5 = new Rol(5, "Emil Rottmayer");
            Rol rol6 = new Rol(6, "Ray Breslin");
            Rol rol7 = new Rol(7, "Hobbes");
            Rol rol8 = new Rol(8, "Dr. Kyrie");
            List<Rol> CastMovie2 = new List<Rol>();
            CastMovie2.Add(rol5); CastMovie2.Add(rol6); CastMovie2.Add(rol7); CastMovie2.Add(rol8);*/
            Movie movie2 = new Movie(2, "Escape Plan");
            DateTime Movie2ReleaseDate = new DateTime(2013, 10, 31);
            movie2.ReleaseDate = Movie2ReleaseDate;
            movie2.FlyerUrl = @"img\bridgetJonesPoster.jpg";
            movie2.Nationality = Nationality.american;
            //movie2.Cast = CastMovie2;

            //Pelicula 1
           /* Rol rol1 = new Rol(1, "BridgetJones");
            Rol rol2 = new Rol(2, "Mark Darcy");
            Rol rol3 = new Rol(3, "Daniel Cleaver");
            Rol rol4 = new Rol(4, "Bridget's Mum");
            List<Rol> CastMovie1 = new List<Rol>();
            CastMovie1.Add(rol1); CastMovie1.Add(rol2); CastMovie1.Add(rol3); CastMovie1.Add(rol4);*/
            Movie movie1 = new Movie(1, "Bridget Jones Diary");
            DateTime Movie1ReleaseDate = new DateTime(2001, 4, 4);
            movie1.ReleaseDate = Movie1ReleaseDate;
            movie1.FlyerUrl = @"\img\EscapePlanPoster.jpg";
            movie1.Nationality = Nationality.american;
         //   movie1.Cast = CastMovie1;

            //Pelicula 3
           /*Rol rol9 = new Rol(5, "Sally");
            Rol rol10 = new Rol(6, "Harry");
            Rol rol11 = new Rol(7, "Marie");
            Rol rol12 = new Rol(8, "Jess");
            List<Rol> CastMovie3 = new List<Rol>();
            CastMovie3.Add(rol9); CastMovie3.Add(rol10); CastMovie3.Add(rol11); CastMovie3.Add(rol12);*/
            Movie movie3 = new Movie(2, "When Harry met Sally");
            DateTime Movie3ReleaseDate = new DateTime(1989, 07, 12);
            movie3.ReleaseDate = Movie3ReleaseDate;
            movie3.FlyerUrl = @"img\HarrySallyPoster.jpg";
            movie3.Nationality = Nationality.american;
           // movie3.Cast = CastMovie3;

            moviesInStorage.Add(movie1); moviesInStorage.Add(movie2); moviesInStorage.Add(movie3);

        }

        public List<Movie> GetAll()
        {
            return moviesInStorage;
        }

        public Movie GetById(long Id)
        {
            List<Movie> movies = GetAll();
            var movieById = new Movie();

            foreach (var movie in movies)
            {
                if(movie.ID_movie == Id)
                {
                    movieById = movie;
                }
                
            }

            return movieById;
        }

        public void Save(Movie editedMovie)
        {
            
             moviesInStorage.Add(editedMovie);
            
        } 
        
        public Movie Update(Movie editedMovie)
        {
            var newMovie = new Movie();
            if(editedMovie != null)
            {
                newMovie.Name = editedMovie.Name;
                newMovie.Nationality = editedMovie.Nationality;
                newMovie.ReleaseDate = editedMovie.ReleaseDate;
                newMovie.FlyerUrl = editedMovie.FlyerUrl;
            }

            return newMovie;
        }

        public void Delete(Movie deletedMovie)
        {
            var movieTodelete = GetById(deletedMovie.ID_movie);
            moviesInStorage.Remove(movieTodelete);
        }

    }

}

