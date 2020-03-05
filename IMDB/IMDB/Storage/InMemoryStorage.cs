/*using IMDB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;

Namespace Repository
{
    //aqui implemento mi interfaz reposity
    public class InMemoryStorage : IStorage

    {
        private List<Movie> moviesInStorage = new List<Movie>();
        private List<Actor> actorsInStorage = new List<Actor>();
        private List<Serie> seriesInStorage = new List<Serie>();
        // to do:
        /**
         * No duplicar colecciones de datos que ya estamos manteniendo como parte
         * de otras entidades, en este caso los roles de las peliculas estan dentro de la entidad Movie
         */
// private List<Character> rolsInStorage = new List<Character>();
/*
public InMemoryStorage()
{
    //instancio peliculas

    //Pelicula 2
    Movie movie2 = new Movie { Id = 2, Name = "Escape Plan" };
    DateTime Movie2ReleaseDate = new DateTime(2013, 10, 31);
    movie2.ReleaseDate = Movie2ReleaseDate;
    movie2.Poster = @"\img\EscapePlanPoster.jpg";
    movie2.Nationality = Nationality.American;

    //Pelicula 1
    Movie movie1 = new Movie { Id = 1, Name = "Bridget Jones Diary" };
    DateTime Movie1ReleaseDate = new DateTime(2001, 4, 4);
    movie1.ReleaseDate = Movie1ReleaseDate;
    movie1.Poster = @"\img\bridgetJonesPoster.jpg";
    movie1.Nationality = Nationality.American;

    moviesInStorage.Add(movie1); moviesInStorage.Add(movie2);
    // ------------------------------------------------------------------------------------------------------------------------

    // instancio roles y actores----------------------------------------------------------------------------------------------

    //Pelicula 1: Bridget Jones's Diary

    //roles
    Character rol1 = new Character { Id = 1, Name = "BridgetJones", Movie = movie1 };
    Character rol2 = new Character { Id = 2, Name = "Mark Darcy", Movie = movie1 };
    Character rol3 = new Character { Id = 3, Name = "Daniel Cleaver", Movie = movie1 };
    Character rol4 = new Character { Id = 4, Name = "Bridget's Mum", Movie = movie1 };

    var RenéeZellweger = new Actor { Id = 1, FirstName = "Renée", LastName = "Zellweger", Nationality = Nationality.American };
    RenéeZellweger.Characters.Add(rol1);
    RenéeZellweger.ProfileFoto = @"\img\Renée_Zellweger.jpg";
    actorsInStorage.Add(RenéeZellweger);
    rol1.Actor = RenéeZellweger;
    movie1.Characters.Add(rol1);

    var ColinFirth = new Actor { Id = 2, FirstName = "Colin", LastName = "Firth", Nationality = Nationality.British };
    ColinFirth.Characters.Add(rol2);
    ColinFirth.ProfileFoto = @"\img\ColinFirth.jpg";
    actorsInStorage.Add(ColinFirth);
    rol2.Actor = ColinFirth;
    movie1.Characters.Add(rol2);

    var HughGrant = new Actor { Id = 3, FirstName = "Hugh", LastName = "Grant", Nationality = Nationality.British };
    HughGrant.ProfileFoto = @"\img\HughGrant.jpg";
    HughGrant.Characters.Add(rol3);
    actorsInStorage.Add(HughGrant);
    rol3.Actor = HughGrant;
    movie1.Characters.Add(rol3);

    var GemmaJones = new Actor { Id = 4, FirstName = "Gemma", LastName = "Jones", Nationality = Nationality.British };
    GemmaJones.Characters.Add(rol4);
    GemmaJones.ProfileFoto = @"\img\GemmaJones.jpg";
    actorsInStorage.Add(GemmaJones);
    rol4.Actor = GemmaJones;
    movie1.Characters.Add(rol4);
    //-------------------------------------------------------------------------

    //pelicula 2: Escape Plan

    //Roles
    Character rol6 = new Character { Id = 5, Name = "Emil Rottmayer", Movie = movie2 };
    Character rol5 = new Character { Id = 6, Name = "Ray Breslin", Movie = movie2 };
    Character rol7 = new Character { Id = 7, Name = "Hobbes", Movie = movie2 };
    Character rol8 = new Character { Id = 8, Name = "Dr. Kyrie", Movie = movie2 };

    //Actores
    var SylvesterStallone = new Actor { Id = 5, FirstName = "Sylvester", LastName = "Stallone", Nationality = Nationality.American };
    SylvesterStallone.Characters.Add(rol5);
    SylvesterStallone.ProfileFoto = @"\img\SylvesterStallone.jpg";
    actorsInStorage.Add(SylvesterStallone);
    rol5.Actor = SylvesterStallone;
    movie2.Characters.Add(rol5);

    var ArnoldSchwarzenegger = new Actor { Id = 6, FirstName = "Arnold", LastName = "Schwarzenegger", Nationality = Nationality.Austrian };
    ArnoldSchwarzenegger.Characters.Add(rol6);
    ArnoldSchwarzenegger.ProfileFoto = @"\img\ArnoldSchwarzenegger.jpg";
    actorsInStorage.Add(ArnoldSchwarzenegger);
    rol6.Actor = ArnoldSchwarzenegger;
    movie2.Characters.Add(rol6);

    var JimCaviezel = new Actor { Id = 7, FirstName = "Jim", LastName = "Caviezel", Nationality = Nationality.American };
    JimCaviezel.ProfileFoto = @"\img\JimCaviezel.jpg";
    JimCaviezel.Characters.Add(rol7);
    actorsInStorage.Add(JimCaviezel);
    rol7.Actor = JimCaviezel;
    movie2.Characters.Add(rol7);

    var SamNeill = new Actor { Id = 8, FirstName = "Sam", LastName = "Neill", Nationality = Nationality.American };
    SamNeill.Characters.Add(rol8);
    SamNeill.ProfileFoto = @"\img\SamNeill.jpg";
    actorsInStorage.Add(SamNeill);
    rol8.Actor = SamNeill;
    movie2.Characters.Add(rol8);

    //-------------------------------------------------------------------------

    //rolsInStorage.Add(rol1); rolsInStorage.Add(rol2); rolsInStorage.Add(rol3); rolsInStorage.Add(rol4);
    //rolsInStorage.Add(rol5); rolsInStorage.Add(rol6); rolsInStorage.Add(rol7); rolsInStorage.Add(rol8);

    //serie WorkinMoms
    var WorkinMoms = new Serie { Id = 1, Name = "Workin' Moms", Nationality = Nationality.American };
    seriesInStorage.Add(WorkinMoms);

    var CatherineReitman = new Actor { Id = 9, FirstName = "Catherine", LastName = "Reitman", Nationality = Nationality.American };
    var DaniKind = new Actor { Id = 10, FirstName = "Dani", LastName = "Kind", Nationality = Nationality.American };
    var JunoRinaldi = new Actor { Id = 11, FirstName = "Juno", LastName = "Rinaldi", Nationality = Nationality.American };
    var PhilipSternberg = new Actor();

    var KateFoster = new Character();
    var AnneCarlson = new Character();
    var FrankeCoyne = new Character();
    var NathanFoster = new Character();

    // serie AVeryEnglishScandal
    var AVeryEnglishScandal = new Serie { Id = 2, Name = "A Very English Scandal", Nationality = Nationality.British };
    seriesInStorage.Add(AVeryEnglishScandal);

    /*

                var BenWhishaw = new Actor();
                var NormanScott = new Character();
                BenWhishaw.Characters.Add(NormanScott);
                actorsInStorage.Add(BenWhishaw);
                NormanScott.Serie = AVeryEnglishScandal;
                AVeryEnglishScandal.Characters.Add(NormanScott);

                var JeremyThorpe = new Character();//personaje de hug grant
                HughGrant.Characters.Add(JeremyThorpe);
                JeremyThorpe.Actor = HughGrant;
                AVeryEnglishScandal.Characters.Add(JeremyThorpe);

                var AlexJennings = new Actor();
                var PeterBessell = new Character();
                AlexJennings.Characters.Add(PeterBessell);
                actorsInStorage.Add(AlexJennings);
                PeterBessell.Serie = AVeryEnglishScandal;
                AVeryEnglishScandal.Characters.Add(PeterBessell);
                */
//-------------------------------------------------------------------------------------------------------------------------
/*}

public long SetMovieID()
{
    var maxID = moviesInStorage.Max(movie => movie.Id);// busco el id mas grande en mi lista de movies

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
    //var movie = movies.Find(movie => movie.Id == Id);
    foreach (var movie in movies)
    {
        if (movie.Id == Id)
        {
            movieById = movie;
        }
    }

    return movieById;
}

public void SaveMovie(Movie editedMovie)
{
    editedMovie.Id = SetMovieID();
    moviesInStorage.Add(editedMovie);
}

public Movie UpdateMovie(Movie editedMovie)
{
    var newMovie = new Movie();
    if (editedMovie != null)
    {
        newMovie.Name = editedMovie.Name;
        newMovie.Nationality = editedMovie.Nationality;
        newMovie.ReleaseDate = editedMovie.ReleaseDate;
        newMovie.Poster = editedMovie.Poster;
        newMovie.Characters = editedMovie.Characters;
    }

    return newMovie;
}

public Actor UpdateActor(Actor editedActor)
{
    var newActor = new Actor();
    if (editedActor != null)
    {
        newActor.Age = editedActor.Age;
        newActor.FirstName = editedActor.FirstName;
        newActor.Id = editedActor.Id;
        newActor.Nationality = editedActor.Nationality;
        newActor.ProfileFoto = editedActor.ProfileFoto;
        newActor.Characters = editedActor.Characters;
    }

    return newActor;
}

public void Delete(Movie deletedMovie)
{
    var movieTodelete = GetMovieById(deletedMovie.Id);

    //borrar los personajes de la pelicula de la lista de personajes del actor
    foreach (var role in deletedMovie.Characters)
    {
        foreach (var actor in actorsInStorage)
        {
            if (actor.Id == role.Actor.Id)
            {
                actor.Characters.Remove(role);
            }
        }
    }

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

    foreach (var actor in actorsInStorage)
    {
        if (actor.Id == id)
        {
            actorById = actor;
        }
    }

    return actorById;
}

public List<Character> GetAllRols()
{
    var allCharacters = new List<Character>();
    allCharacters = GetAllMovies().SelectMany(movie => movie.Characters).ToList();

    return allCharacters;
}

public Character GetRolById(long id)
{
    var rolsInStorage = GetAllRols();
    var role = rolsInStorage.FirstOrDefault(r => r.Id == id);

    if (role == null)
        throw new ArgumentNullException("id not found");

    return role;
}

public void SaveActor(Actor editedOrNewActor)
{
    editedOrNewActor.Id = SetActorID();
    actorsInStorage.Add(editedOrNewActor);
}

public long SetActorID()
{
    var maxID = actorsInStorage.Max(actor => actor.Id);// busco el id mas grande en mi lista de movies
    return (maxID = maxID + 1);
}

public void DeleteActor(Actor actor)
{
    var actorToDelete = GetActorbyId(actor.Id);
    actorsInStorage.Remove(actorToDelete);
}

public long SetRolID()
{
    var maxID = GetAllRols().Max(rol => rol.Id);
    return (maxID + 1);
}

public void SaveRol(Character newRol, int movieId, int actorId)
{
    //var character = new Character();
    //character = newRol;
    newRol.Id = SetRolID();
    //  newRol.Actor = GetActorbyId(newRol.IdActor);
    newRol.Movie = GetMovieById(movieId);
    Movie movie = GetMovieById(movieId);
    movie.Characters.Add(newRol);
    Actor actor = GetActorbyId(actorId);
    // rolsInStorage.Add(newRol);
    actor.Characters.Add(newRol);
}

public void DeleteRol(Character rol, int movieId)
{
    var movie = GetMovieById(movieId);

    foreach (var roleInMovie in movie.Characters)
    {
        if (rol.Id == roleInMovie.Id)
        {
            //  rolsInStorage.Remove(rol);
            movie.Characters.Remove(rol);
            rol.Actor.Characters.Remove(rol);
            break;
        }
    }
}

public List<Serie> GetAllSeries()
{
    return seriesInStorage;
}
}
}
*/
