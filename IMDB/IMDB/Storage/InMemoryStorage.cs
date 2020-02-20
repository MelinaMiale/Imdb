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
        // todo:
        /**
         * No duplicar colecciones de datos que ya estamos manteniendo como parte
         * de otras entidades, en este caso los roles de las peliculas estan dentro de la entidad Movie
         */
        List<Role> rolsInStorage = new List<Role>();
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
            Role rol1 = new Role(1, "BridgetJones", movie1);
            Role rol2 = new Role(2, "Mark Darcy", movie1);
            Role rol3 = new Role(3, "Daniel Cleaver", movie1);
            Role rol4 = new Role(4, "Bridget's Mum", movie1);
            
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
            Role rol6 = new Role(5, "Emil Rottmayer", movie2);
            Role rol5 = new Role(6, "Ray Breslin", movie2);
            Role rol7 = new Role(7, "Hobbes", movie2);
            Role rol8 = new Role(8, "Dr. Kyrie", movie2);

            //Actores
            var SylvesterStallone = new Actor(5, "Sylvester", "Stallone", Nationality.american);
            actorsInStorage.Add(SylvesterStallone);
            SylvesterStallone.RolsPlayed.Add(rol5);
            rol5.Actor = SylvesterStallone;
            movie2.Characters.Add(rol5);

            var ArnoldSchwarzenegger = new Actor(6, "Arnold", "Schwarzenegger", Nationality.austrian);
            actorsInStorage.Add(ArnoldSchwarzenegger);
            ArnoldSchwarzenegger.RolsPlayed.Add(rol6);
            rol6.Actor = ArnoldSchwarzenegger;
            movie2.Characters.Add(rol6);

            var JimCaviezel = new Actor(7, "Jim", "Caviezel", Nationality.american);
            actorsInStorage.Add(JimCaviezel);
            JimCaviezel.RolsPlayed.Add(rol7);
            rol7.Actor = JimCaviezel;
            movie2.Characters.Add(rol7);

            var SamNeill = new Actor(7, "Sam", "Neill", Nationality.american);
            actorsInStorage.Add(SamNeill);
            SamNeill.RolsPlayed.Add(rol8);
            rol8.Actor = SamNeill;
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

            //todo: simplificar con Linq
            //var movie = movies.Find(movie => movie.ID_movie == Id);
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
                newMovie.Characters = editedMovie.Characters;
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
            var actorsInStorage = GetAllActors();
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

        public List<Role> GetAllRols()
        {
            return rolsInStorage;
        }

        
        public Role GetRolById(long id) {
            var rolsInStorage = GetAllRols();
            var role = rolsInStorage.FirstOrDefault(r => r.ID_Role == id);

            if (role == null)
                throw new ArgumentNullException("id not found");

            return role;
        }

        

        //public String GetActorNameByRolId(long rolId)
        //{
        //    var role = rolsInStorage.FirstOrDefault(r => r.ID_Role == rolId);
        //    if (role != null) {
        //        var actor = actorsInStorage.FirstOrDefault(a => a.ID_Actor == role.Actor.ID_Actor);
        //        if (actor != null) {
        //            return actor.Name;
        //        }
        //    }

        //    throw new System.InvalidOperationException("");


        //}

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

        public void DeleteActor (Actor actor)
        {
            var actorToDelete = GetActorbyId(actor.ID_Actor);
            actorsInStorage.Remove(actorToDelete);
        }

        public long SetRolID()
        {
            var maxID = rolsInStorage.Max(rol => rol.ID_Role);
            return (maxID + 1);
        }
        public void SaveRol(Role newRol, int movieId, int actorId)
        {
            //movie.Characters.Add(newRol);
            newRol.ID_Role = SetRolID();
            
            Movie movie = GetMovieById(movieId);
            movie.Characters.Add(newRol);
            Actor actor = GetActorbyId(actorId);
            
            rolsInStorage.Add(newRol);
            movie.Characters.Add(newRol);
            actor.RolsPlayed.Add(newRol);

        }
        public void DeleteRol (Role rol, int movieId)
        {
            var movie = GetMovieById(movieId);
            
            foreach(var roleInMovie in movie.Characters)
            {
                if(rol.ID_Role == roleInMovie.ID_Role)
                {
                    rolsInStorage.Remove(rol);
                    movie.Characters.Remove(rol);
                    rol.Actor.RolsPlayed.Remove(rol);
                    break;
                }
            }
        }

    }

}

