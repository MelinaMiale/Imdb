using Proyect_Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    //aqui implemento mi interfaz reposity
    public class InMemoryStorage : IStorage

    {

        List<Movie> moviesInStorage = new List<Movie>();
        List<Actor> actorsInStorage = new List<Actor>();
        List<Rol> rolsInStorage = new List<Rol>();

        public InMemoryStorage() {

            //instancio peliculas

            //Pelicula 2
            Movie movie2 = new Movie(2, "Escape Plan");
            DateTime Movie2ReleaseDate = new DateTime(2013, 10, 31);
            movie2.ReleaseDate = Movie2ReleaseDate;
            movie2.FlyerUrl = @"img\bridgetJonesPoster.jpg";
            movie2.Nationality = Nationality.american;
            

            //Pelicula 1
            Movie movie1 = new Movie(1, "Bridget Jones Diary");
            DateTime Movie1ReleaseDate = new DateTime(2001, 4, 4);
            movie1.ReleaseDate = Movie1ReleaseDate;
            movie1.FlyerUrl = @"\img\EscapePlanPoster.jpg";
            movie1.Nationality = Nationality.american;

            
            moviesInStorage.Add(movie1); moviesInStorage.Add(movie2);
            // ------------------------------------------------------------------------------------------------------------------------

            // instancio roles y actores

            //Pelicula 1: Bridget Jones's Diary

            //roles
            Rol rol1 = new Rol(1, "BridgetJones", movie1);
            Rol rol2 = new Rol(2, "Mark Darcy", movie1);
            Rol rol3 = new Rol(3, "Daniel Cleaver", movie1);
            Rol rol4 = new Rol(4, "Bridget's Mum", movie1);
            
           //Actores

            var RenéeZellweger = new Actor(1, "Renée", "Zellweger", Nationality.american);
            actorsInStorage.Add(RenéeZellweger);
            RenéeZellweger.RolsPlayed.Add(rol1);
            rol1.Actor = RenéeZellweger; 
            movie1.Characters.Add(rol1);
            

            var ColinFirth = new Actor(2, "Colin", "Firth", Nationality.british);
            actorsInStorage.Add(ColinFirth);
            ColinFirth.RolsPlayed.Add(rol2);
            rol2.Actor = ColinFirth;
            movie1.Characters.Add(rol2);

            var HughGrant = new Actor(3, "Hugh", "Grant", Nationality.british);
            actorsInStorage.Add(HughGrant);
            HughGrant.RolsPlayed.Add(rol3);
            rol3.Actor = HughGrant;
            movie1.Characters.Add(rol3);

            var GemmaJones = new Actor(4, "Gemma", "Jones", Nationality.british);
            actorsInStorage.Add(GemmaJones);
            GemmaJones.RolsPlayed.Add(rol4);
            rol4.Actor = GemmaJones;
            movie1.Characters.Add(rol4);
            //-------------------------------------------------------------------------

            //pelicula 2: Escape Plan

            //Roles
            Rol rol6 = new Rol(5, "Emil Rottmayer", movie2);
            Rol rol5 = new Rol(6, "Ray Breslin", movie2);
            Rol rol7 = new Rol(7, "Hobbes", movie2);
            Rol rol8 = new Rol(8, "Dr. Kyrie", movie2);

            //Actores
            var SylvesterStallone = new Actor(5, "Sylvester", "Stallone", Nationality.american);
            actorsInStorage.Add(SylvesterStallone);
            SylvesterStallone.RolsPlayed.Add(rol5);
          //  rol5.ID_Actor = SylvesterStallone.ID_Actor;
            movie2.Characters.Add(rol5);

            var ArnoldSchwarzenegger = new Actor(6, "Arnold", "Schwarzenegger", Nationality.austrian);
            actorsInStorage.Add(ArnoldSchwarzenegger);
            ArnoldSchwarzenegger.RolsPlayed.Add(rol6);
          //  rol6.ID_Actor = ArnoldSchwarzenegger.ID_Actor;
            movie2.Characters.Add(rol6);

            var JimCaviezel = new Actor(7, "Jim", "Caviezel", Nationality.american);
            actorsInStorage.Add(JimCaviezel);
            JimCaviezel.RolsPlayed.Add(rol7);
          //  rol7.ID_Actor = JimCaviezel.ID_Actor;
            movie2.Characters.Add(rol7);

            var SamNeill = new Actor(7, "Sam", "Neill", Nationality.american);
            actorsInStorage.Add(SamNeill);
            SamNeill.RolsPlayed.Add(rol8);
          //  rol8.ID_Actor = SamNeill.ID_Actor;
            movie2.Characters.Add(rol8);


            //-------------------------------------------------------------------------

            rolsInStorage.Add(rol1); rolsInStorage.Add(rol2); rolsInStorage.Add(rol3); rolsInStorage.Add(rol4);
            rolsInStorage.Add(rol5); rolsInStorage.Add(rol6); rolsInStorage.Add(rol7); rolsInStorage.Add(rol8);
   
            //-------------------------------------------------------------------------------------------------------------------------

        }



        public long SetMovieID ()
        {
            var maxID = moviesInStorage.Max(movie => movie.ID_movie);// busco el id mas grande en mi lista de movies
            
            return (maxID = maxID + 1);
        }

        public List<Movie> GetAllMovies()
        {
            return moviesInStorage;
        }

        public Movie GetMovieById(long Id)
        {
            List<Movie> movies = GetAllMovies();
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

        public void SaveMovie(Movie editedMovie)
        {
            editedMovie.ID_movie = SetMovieID();
            moviesInStorage.Add(editedMovie);
        } 
        
        public Movie UpdateMovie(Movie editedMovie)
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
            var movieTodelete = GetMovieById(deletedMovie.ID_movie);
            moviesInStorage.Remove(movieTodelete);
        }

        public List<Actor> GetAllActors()
        {
            return actorsInStorage;
        }

        public Actor GetActorbyId(long id)
        {
            List <Actor> actorsInStorage = GetAllActors();
            var actorById = new Actor();

            foreach(var actor in actorsInStorage)
            {
                if(actor.ID_Actor == id)
                {
                    actorById = actor;
                }
            }

            return actorById;
        }

        public List<Rol> GetAllRols()
        {
            return rolsInStorage;
        }

        /*public String GetActorNameByRolId (long rolId)
        {
            String actorNameByRolId = "";
            var actorsInMovie = GetAllActors();
            var rolsInMovies = GetAllRols();
            
            foreach(var rol in rolsInMovies)
            {
                foreach(var actor in actorsInMovie)
                {
                    if( rol.ID_Actor == actor.ID_Actor)
                    {
                        actorNameByRolId = actor.Name;
                    }
                }
            }

            return actorNameByRolId;
        }*/

        public String GetActorNameByRolId(long rolId)
        {
            var role = rolsInStorage.FirstOrDefault(r => r.ID_Rol == rolId);
            if (role != null) {
                var actor = actorsInStorage.FirstOrDefault(a => a.ID_Actor == role.Actor.ID_Actor);
                if (actor != null) {
                    return actor.Name;
                }
            }

            throw new System.InvalidOperationException("");
            

        }

        public void SaveActor(Actor editedOrNewActor)
        {
            editedOrNewActor.ID_Actor = SetActorID();
            actorsInStorage.Add(editedOrNewActor);

        }

        public long SetActorID()
        {
            var maxID = actorsInStorage.Max(actor => actor.ID_Actor);// busco el id mas grande en mi lista de movies
            return (maxID = maxID + 1);
        }



    }

}

